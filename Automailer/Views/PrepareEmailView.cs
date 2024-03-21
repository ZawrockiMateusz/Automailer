using Automailer.Controllers;
using Automailer.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automailer.Views
{
    public partial class PrepareEmailView : Form
    {
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }
        private Configuration _config;
        public PrepareEmailView(Configuration config, List<Recipient> recipients)
        {
            InitializeComponent();
            _config = config;

            initializeGvRecipients(recipients);

            this.Text = $"Treść wiadomości | {_config.LatestExcelFilePath}";
        }

        private void initializeGvRecipients(List<Recipient> recipients)
        {
            gcRecipients.DataSource = recipients;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(
                $"Czy na pewno chcesz wysłać wiadomość?", "Uwaga!", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // opcjonalny zapis treści do pliku
                if (XtraMessageBox.Show(
                    "Czy chcesz zapisać wzór wiadomości do pliku?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveEmailToFile();
                }

                EmailTitle = txtEmailTitle.Text;
                EmailBody = rTxtEmailBody.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnInsertParam_Click(object sender, EventArgs e)
        {
            SelectParameterView selectParameterView = new SelectParameterView(_config);
            if (selectParameterView.ShowDialog() == DialogResult.OK)
            {
                DocumentPosition currentPosition = rTxtEmailBody.Document.CaretPosition;
                ExcelParameterMap excelParameter = selectParameterView.ExcelParameter;
                if(excelParameter != null && currentPosition != null)
                {
                    string openingTag = String.Empty;
                    string closingTag = String.Empty;
                    if(excelParameter.ParamType == ParameterType.Default 
                        || excelParameter.ParamType == ParameterType.Text)
                    {
                        openingTag = "<<";
                        closingTag = ">>";
                    }
                    else if(excelParameter.ParamType == ParameterType.Image)
                    {
                        openingTag = "[[";
                        closingTag = "]]";
                    }
                    rTxtEmailBody.Document.InsertText(currentPosition, $"{openingTag}{excelParameter.Name}{closingTag}");
                }
                
            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            using (XtraOpenFileDialog ofd = new XtraOpenFileDialog())
            {
                ofd.Title = "Wybierz plik importu";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = ofd.SafeFileName;
                    string filePath = ofd.FileName;
                    if (!String.IsNullOrEmpty(filePath))
                    {
                        string fileContent = FileStreamController.ReadFileContent(filePath);
                        if (!String.IsNullOrEmpty(fileContent))
                        {
                            txtEmailTitle.Text = Path.ChangeExtension(fileName, null);
                            rTxtEmailBody.Text = fileContent;
                        }
                    }
                }
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            saveEmailToFile();
        }

        private void saveEmailToFile()
        {
            string emailTitle = txtEmailTitle.Text;
            string content = rTxtEmailBody.Text;

            if (!String.IsNullOrEmpty(content))
            {
                using (XtraSaveFileDialog sfd = new XtraSaveFileDialog())
                {
                    sfd.Title = "Wskaż ścieżkę zapisu.";
                    sfd.Filter = "Pliki tekstowe (*.txt)|*.txt";
                    sfd.FileName = !String.IsNullOrEmpty(emailTitle)
                        ? $"{emailTitle}.txt"
                        : "MojaWiadomoscEmail.txt";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = sfd.FileName;
                        bool result = FileStreamController.SaveFile(fileName, content);

                        if (result)
                        {
                            XtraMessageBox.Show($"Zapisano plik {fileName}", "Sukces!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show($"Wystąpił błąd podczas zapisu pliku.", "Błąd!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Wiadomość jest pusta...", "Uwaga",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
