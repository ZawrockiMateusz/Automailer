using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automailer.Models
{
    /// <summary>
    /// Class represents a recipient of the email message
    /// </summary>
    public class Recipient
    {
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
