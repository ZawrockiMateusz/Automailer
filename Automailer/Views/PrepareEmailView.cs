using Automailer.Models;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public PrepareEmailView(Configuration config)
        {
            InitializeComponent();
            _config = config;

            this.Text = $"Treść wiadomości | {config.LatestExcelFilePath}";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Czy na pewno chcesz wysłać wiadomość?", "Uwaga!", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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
    }
}
