using Automailer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automailer.Controllers
{
    public static class ConfigurationController
    {
        public static Configuration LoadConfiguration(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Configuration>(json);
            }
            else
            {
                return new Configuration { ActivateSSL = true, SMTP_Port = 587, SkipHeader = true, SMTP_Client = "smtp.gmail.com" };
            }
        }
        public static void SaveConfiguration(Configuration config, string filePath)
        {
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText(filePath, json);
        }
    }
}
