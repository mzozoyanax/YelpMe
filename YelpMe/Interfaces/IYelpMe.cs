using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpMe.Models;
using YelpMe.ViewModels;

namespace YelpMe.Interfaces
{
    public interface IYelpMe
    {
        Task<string> GetOwnersName(string profileUrl);

        Task<string> FindEmailAddress(string profileUrl, bool contactPage);

        Task<string> FindBusienssWebsite(string profileUrl, bool contactPage);

        Task<string> GetEmailAddress(string websiteUrl);

        Task<string> GetEmailAddressFromContactPage(string websiteUrl);

        Task<string> GetPhoneNumber(string profileUrl);

        Task<string> GetBusinessWebsite(string profileUrl);

        Task<string> GetCompanyName(string profileUrl);

        Task<string> ConvertWebsiteToHtml(string url);

        Task<string> ConvertWebsiteToText(string url);

        Task<string> GetFacebookPage(string websiteUrl);

        Task<string> GetYouTubeChannel(string websiteUrl);

        Task<bool> ContainsFacebookPixelCode(string websiteUrl);

        Task<bool> ContainYouTubeChannel(string websiteUrl);

        Task<bool> ValidUrl(string url);
    }
}
