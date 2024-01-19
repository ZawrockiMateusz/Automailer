﻿using Automailer.Controllers;
using Automailer.Models;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Automailer.Views
{
    public partial class MainView : Form
    {
        Configuration config;
        private string configFilePath = Path.Combine
            (Path.GetDirectoryName(Application.ExecutablePath), Configuration.FileName);
        List<string> invalidEmails;
        string[] allowedFileExtentions;
        public MainView()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            allowedFileExtentions = new[]{
                ".xlsx", ".xlsm", ".xlsb", ".xltx", ".xltm", ".xls",
                ".xlt", ".xls", ".xml", ".xlam", ".xla", ".xlw", ".xlr" };

            config = ConfigurationController
                .LoadConfiguration(configFilePath);

            fillInControls();
        }

        private void fillInControls()
        {
            btnExcelPath.Text = config.LatestExcelFilePath;
            txtEmailLogin.Text = config.EmailLogin;
            cmbClientEmail.Text = config.ClientEmailColumn;
            spinSMTPPort.Value = config.SMTP_Port;
            chkEnableSSL.Checked = config.ActivateSSL;
            chkSkipHeader.Checked = config.SkipHeader;
            txtSMTPClient.Text = config.SMTP_Client;

            gcExcelCellsMap.DataSource = config.ExcelParametersMap;
            gcExcelCellsMap.RefreshDataSource();
        }

        private void btnExcelPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Point the excel file path
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Wskaż plik Excel";
            ofd.Filter = "Pliki Excel (*.xls; *.xlsx)|*.xls;*.xlsx|Wszystkie pliki (*.*)|*.*";
            ofd.FilterIndex = 1;
            
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(ofd.FileName).ToLower();
                if (allowedFileExtentions.Contains(ext))
                {
                    btnExcelPath.Text = ofd.FileName;
                }
                else
                {
                    string mess = "Wskazany format pliku nie jest obsługiwany. \r\nLista dozwolonych formatów:\r\n\r\n";
                    foreach (string allowedExt in allowedFileExtentions)
                    {
                        mess += $"{allowedExt}, ";
                    };
                    //remove last comma and white space
                    mess = mess.Remove(mess.Length - 2);

                    MessageBox.Show(mess, "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
        }

        private void btnZamknij_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.LatestExcelFilePath = btnExcelPath.Text;
            config.EmailLogin = txtEmailLogin.Text;
            config.ClientEmailColumn = cmbClientEmail.Text;
            config.SMTP_Port = (int)spinSMTPPort.Value;
            config.ActivateSSL = chkEnableSSL.Checked;
            config.SkipHeader = chkSkipHeader.Checked;
            config.SMTP_Client = txtSMTPClient.Text;

            ConfigurationController.SaveConfiguration
                (config, configFilePath);
        }

        private void btnSendEmails_Click(object sender, EventArgs e)
        {
            SendEmailView sendEmailView = new SendEmailView();
            if(sendEmailView.ShowDialog() == DialogResult.OK)
            {
                //configure mail properties
                EmailContent emailContent = new EmailContent
                {
                    Body = sendEmailView.EmailBody,
                    Title = sendEmailView.EmailTitle
                };
                
                string excelPath = btnExcelPath.Text;

                string email = txtEmailLogin.Text;
                string password = txtEmailPassword.Text;

                SmtpClient client = new SmtpClient(txtSMTPClient.Text)
                {
                    Port = 587,
                    Credentials = new NetworkCredential(email, password),
                    EnableSsl = chkEnableSSL.Checked,
                };

                invalidEmails = new List<string>();
                //Open excel file
                using (var package = new ExcelPackage(new FileInfo(excelPath)))
                {
                    int startRowIndex = chkSkipHeader.Checked ? 2 : 1;
                    var worksheet = package.Workbook.Worksheets[0];

                    for (int row = startRowIndex; row <= worksheet.Dimension.End.Row; row++)
                    {
                        string localBody = emailContent.Body;
                        List<Attachment> attachments = new List<Attachment>();

                        foreach (ExcelParameterMap excelParam in config.ExcelParametersMap.Where(epm
                            => epm.ParamType == ParameterType.Default
                            || epm.ParamType == ParameterType.Text))
                        {
                            localBody = localBody.Replace(
                                $"<<{excelParam.Name}>>",
                                worksheet.Cells[excelParam.Cell + row.ToString()].Value.ToString());
                        }
                        foreach (ExcelParameterMap excelParam in config.ExcelParametersMap.Where(epm
                             => epm.ParamType == ParameterType.Image))
                        {
                            attachments.Add(new Attachment(excelParam.Name, MediaTypeNames.Image.Jpeg)
                            {
                                ContentId = excelParam.Name
                            });
                        }

                        string from = txtEmailLogin.Text;
                        string to = worksheet.Cells[cmbClientEmail.Text + row.ToString()].Value.ToString();
                        try
                        {
                            MailMessageController.SendMailMessage(
                                client,
                                from,
                                to,
                                emailContent.Title,
                                localBody,
                                attachments);
                        }
                        catch
                        {
                            invalidEmails.Add(to);
                        }
                    }
                }
                MessageBox.Show("Wiadomości zostały wysłane do adresatów.", 
                    "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (invalidEmails != null && invalidEmails.Count > 0)
                {
                    MessageBox.Show($"Nie udało się wysłać następującej liczby wiadomości: {invalidEmails.Count}.", 
                        "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            config.ExcelParametersMap.Add(new ExcelParameterMap());
            gcExcelCellsMap.RefreshDataSource();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            config.ExcelParametersMap
                .Remove(gvExcelCellsMap.GetRow(gvExcelCellsMap.FocusedRowHandle) as ExcelParameterMap);
            gcExcelCellsMap.RefreshDataSource();
        }

    }
}