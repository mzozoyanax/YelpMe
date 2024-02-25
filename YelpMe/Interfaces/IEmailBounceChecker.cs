using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpMe.Models;

namespace ScrapeHero.Interfaces
{
    public interface IEmailBounceChecker
    {
        bool UseSite24();

        bool UseZeroBounce();

        bool UseVerifDotEmail();

        bool UseSendBridge();
    }
}
