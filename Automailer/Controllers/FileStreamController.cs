using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automailer.Controllers
{
    public static class FileStreamController
    {
        public static string ReadFileContent(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else return String.Empty;
        }

        public static bool SaveFile(string fileName, string content)
        {
            try
            {
                File.WriteAllText(fileName, content);
                return true;
            }
            catch (Exception ex)
            {
                //dodać logger

                return false;
            }
        }
    }
}
