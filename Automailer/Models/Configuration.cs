using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automailer.Models
{
    public class Configuration
    {
        public Configuration()
        {
            ExcelParametersMap = new List<ExcelParameterMap>();
        }
        public const string FileName = "ConfigurationAutomailer.json";
        public string LatestExcelFilePath { get; set; }
        public string EmailLogin { get; set; }
        public string ClientEmailColumn { get; set; }
        public int SMTP_Port { get; set; }
        public string SMTP_Client { get; set; }
        public bool ActivateSSL { get; set; }
        public bool SkipHeader { get; set; }
        public List<ExcelParameterMap> ExcelParametersMap { get; set; }
    }
}
