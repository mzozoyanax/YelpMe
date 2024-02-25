using ScrapeHero.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapeHero.Interfaces
{
    public interface INameAPI
    {
        Task<NameApiViewModels> EmailNameParser(string email, string apiKey);

        Task<EmailValidationResponse> DisposableEmaiAddressDetector(string email, string apiKey);
    }
}
