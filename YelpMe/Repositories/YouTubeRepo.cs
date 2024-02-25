using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpMe.Interfaces;

namespace ScrapeHero.Repositories
{
    public class YouTubeRepo : IYelpMe
    {
        public Task<bool> ContainsFacebookPixelCode(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ContainYouTubeChannel(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> ConvertWebsiteToHtml(string url)
        {
            throw new NotImplementedException();
        }

        public Task<string> ConvertWebsiteToText(string url)
        {
            throw new NotImplementedException();
        }

        public Task<string> FindBusienssWebsite(string profileUrl, bool contactPage)
        {
            throw new NotImplementedException();
        }

        public Task<string> FindEmailAddress(string profileUrl, bool contactPage)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBusinessWebsite(string profileUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCompanyName(string profileUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAddress(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAddressFromContactPage(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFacebookPage(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetOwnersName(string profileUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhoneNumber(string profileUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetYouTubeChannel(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
