using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapeHero.Models
{
    public class NameApiSettings
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SelectApiKeyId { get; set; } 

        public bool UseMultipleKeys { get; set; }

        public bool ValidEmail { get; set; }

        public bool HumanNameEmails { get; set; }
    }
}
