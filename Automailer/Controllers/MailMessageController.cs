using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Automailer.Controllers
{
    static class MailMessageController
    {
        public static void SendMailMessage(SmtpClient client, string from, string to, string subject, string body, List<Attachment> attachments)
        {
            MailMessage message = new MailMessage(from, to, subject, body)
            {
                IsBodyHtml = true,
            };
            if (attachments != null)
            {
                foreach (Attachment att in attachments)
                {
                    message.Attachments.Add(att);
                    message.Body = message.Body.Replace(
                        $"[[{att.ContentId}]]",
                        $"<img src='cid:{att.ContentId}'>");
                }
            }
            client.Send(message);
        }
    }
}
