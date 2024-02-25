using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YelpMe.Models
{
    public class Settings
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }    

        public bool SearchOffline { get; set; }

        public bool UseNameApi { get; set; }

        public bool FacebookPixelInstalled { get; set; }

        public bool HasYouTubeChannel { get; set; } 

    }
}
