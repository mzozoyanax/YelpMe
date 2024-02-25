using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScrapeHero.Constants
{
    public class AppConstant
    {
        public bool PersonalEmail(string email)
        {
            bool result = (
                email != "no-reply@" ||
                email != "admin@" ||
                email != "support@" ||
                email != "sales@" ||
                email != "info@" ||
                email != "contact@" ||
                email != "abuse@" ||
                email != "spam@" ||
                email != "webmaster@" ||
                email != "privacy@" ||
                email != "postmaster@" ||
                email != "unsubscribe@" ||
                email != "root@" ||
                email != "marketing@" ||
                email != "noreply@" ||
                email != "test@" ||
                email != "contactus@" ||
                email != "help@" ||
                email != "ceo@" ||
                email != "hello@" ||
                email != "contact@"
                );

            return result;
        }

        public string[] EmailCleaningPrograms()
        {
            string[] array = { 
                "Site24x7", 
                "ZeroBounce",
                "Verif.email",
                "SendBridge"
            };
            return array;

        }
    }
}
