using Automailer.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automailer.Controllers
{
    public static class ExcelImportController
    {
        public static List<Recipient> downloadRecipients(string filePath, bool skipHeader, string emailCol)
        {
            List<Recipient> recipients = new List<Recipient>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                int startRowIndex = skipHeader ? 2 : 1;
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = startRowIndex; row <= worksheet.Dimension.End.Row; row++)
                {
                    string email = worksheet.Cells[emailCol + row.ToString()].Value?.ToString() ?? String.Empty;
                    if (!String.IsNullOrEmpty(email))
                        recipients.Add(new Recipient
                        {
                            Email = email
                        });
                }
            }
            return recipients;
        }
    }
}
