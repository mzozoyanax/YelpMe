using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YelpMe.ViewModels
{
    public class MessageViewModels
    {
        [Key]
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string EmailFrom { get; set; }

        public string EmailTo { get; set; }

        public string Phone { get; set; } 

        public bool Html { get; set; }

        public string Host { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public bool Ssl { get; set; }
    }
}
