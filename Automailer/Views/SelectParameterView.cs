using Automailer.Models;
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
    public partial class SelectParameterView : Form
    {
        public ExcelParameterMap ExcelParameter { get; set; }
        private Configuration _config;
        public SelectParameterView(Configuration config)
        {
            InitializeComponent();
            _config = config;

            lookupParameters.Properties.DataSource = _config.ExcelParametersMap;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ExcelParameter = _config.ExcelParametersMap
                .FirstOrDefault(p => p.Name == lookupParameters.EditValue.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
