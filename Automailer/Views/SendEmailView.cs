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
    public partial class SendEmailView : Form
    {
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }
        public SendEmailView()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            EmailTitle = txtEmailTitle.Text;
            EmailBody = rTxtEmailBodt.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
