using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YelpMe.Models
{
    public class Accounts
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string ImapHost { get; set; }
        public int ImapPort { get; set; }
        public bool StmpSsl { get; set; }
        public bool ImapSsl { get; set; }
        public string? Signature { get; set; }
    }
}
