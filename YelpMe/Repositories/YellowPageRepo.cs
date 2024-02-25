using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpMe.Models;
using YelpMe.ViewModels;
using HtmlAgilityPack;
using EmailValidation;
using System.Text.RegularExpressions;
using YelpMe.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace YelpMe.Repositories
{
    public class YellowPageRepo : IYelpMe
    {
        private AppDbContext appDbContext = new AppDbContext();
        private Models.Settings settings = new Models.Settings();

        public YellowPageRepo()
        {
            settings = null;
        }

        public async Task<string> ConvertWebsiteToHtml(string url)
        {
            try
            {
                // Create an instance of HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Send a GET request to the website
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the HTML content as a string
                        string htmlString = await response.Content.ReadAsStringAsync();

                        return htmlString;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> ConvertWebsiteToText(string url)
        {
            try
            {
                // Create an instance of HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Send a GET request to the website
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the HTML content as a string
                        string htmlString = await response.Content.ReadAsStringAsync();

                        const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
                        const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
                        const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
                        var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
                        var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
                        var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

                        var text = htmlString;
                        //Decode html specific characters
                        text = System.Net.WebUtility.HtmlDecode(text);
                        //Remove tag whitespace/line breaks
                        text = tagWhiteSpaceRegex.Replace(text, "><");
                        //Replace <br /> with line breaks
                        text = lineBreakRegex.Replace(text, Environment.NewLine);
                        //Strip formatting
                        text = stripFormattingRegex.Replace(text, string.Empty);

                        return text;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> GetBusinessWebsite(string profileUrl)
        {
            string linkUrl = "";

            try
            {
                string htmlContent = await ConvertWebsiteToHtml(profileUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                // "//a[contains(@class, 'css-1idmmu3')]"
                var anchorNodes = doc.DocumentNode.SelectNodes("//a[contains(@class, 'website-link dockable')]");

                if (anchorNodes != null)
                {
                    string url = anchorNodes[0].Attributes["href"].Value;

                    bool isWebsite = await ValidUrl(url);

                    // Extract the link URL and inner text of the <a> tag within the <p> tag
                    if (isWebsite == true)
                    {
                        linkUrl = url;

                        return linkUrl;
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }

            return linkUrl;
        }

        public async Task<string> GetCompanyName(string profileUrl)
        {
            try
            {
                string htmlContent = await ConvertWebsiteToHtml(profileUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                //h1[contains(@class, 'css-1se8maq')]
                var anchorNode = doc.DocumentNode.SelectSingleNode("//h1[contains(@class, 'dockable business-name')]");

                if (anchorNode != null)
                {
                    // Extract the inner text of the <a> tag
                    string name = anchorNode.InnerText;

                    return name;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public async Task<string> GetEmailAddress(string websiteUrl)
        {
            string email = "";

            try
            {
                string htmlContent = await ConvertWebsiteToHtml(websiteUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                //a
                var anchorNodes = doc.DocumentNode.SelectNodes("//a");

                if (anchorNodes != null)
                {
                    foreach (var anchorNode in anchorNodes)
                    {
                        string pageLink = anchorNode.Attributes["href"].Value;
                        string input = await ConvertWebsiteToHtml(pageLink);

                        // Define a regular expression pattern to match valid email addresses
                        string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

                        // Create a regular expression object and match the pattern in the input string
                        Regex regex = new Regex(pattern);
                        MatchCollection matches = regex.Matches(input);

                        // Report on each match.
                        foreach (Match match in matches)
                        {
                            bool validEmail = match.Value.Contains(".com");

                            if (validEmail == true)
                            {
                                email = match.Value;

                                return email;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }

            return email;
        }

        public async Task<string> GetOwnersName(string profileUrl)
        {
            try
            {
                string htmlContent = await ConvertWebsiteToHtml(profileUrl); 

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                //h1[contains(@class, 'css-1se8maq')]
                var anchorNode = doc.DocumentNode.SelectSingleNode("//dd[contains(@class, 'general-info')]");

                if (anchorNode != null)
                {
                    // Extract the inner text of the <a> tag
                    string name = anchorNode.InnerText.Substring(0, 15);

                    return name;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public async Task<string> GetPhoneNumber(string profileUrl)
        {
            string phoneNumber = "";
            try
            {
                string htmlContent = await ConvertWebsiteToHtml(profileUrl);

                // Load the HTML document
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                // Select the anchor tag with the specified class
                var anchorNode = doc.DocumentNode.SelectSingleNode("//a[@class='phone dockable']");

                if (anchorNode != null)
                {
                    // Get the href attribute value
                    string hrefValue = anchorNode.GetAttributeValue("href", "");

                    phoneNumber = "1" + hrefValue.Replace("tel:", "")
                        .Replace("(", "")
                        .Replace(")", "")
                        .Replace("-", "")
                        .Replace(" ", "");

                }

            }
            catch (Exception)
            {
                return "";
            }

            return phoneNumber;
        }

        public async Task<bool> ValidUrl(string url)
        {
            string pattern = @"^(http|https|ftp)://([\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?)$";
            return Regex.IsMatch(url, pattern);
        }

        public async Task<bool> ContainsFacebookPixelCode(string websiteUrl)
        {
            bool result = false;

            try
            {
                WebClient client = new WebClient();
                string pageSource = client.DownloadString(websiteUrl);

                if (pageSource.Contains("https://connect.facebook.net/en_US/fbevents.js"))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

                if (settings.FacebookPixelInstalled == result)
                {
                    result = settings.FacebookPixelInstalled;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return result;
        }

        public async Task<bool> ContainYouTubeChannel(string websiteUrl)
        {
            bool result = false;

            try
            {
                string htmlContent = await ConvertWebsiteToHtml(websiteUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                // Select all anchor tags <a> with href attributes containing "youtube.com/channel/"
                var aNodesWithYouTubeLink = doc.DocumentNode.SelectNodes("//a[contains(@href, 'youtube.com/')]");

                if (aNodesWithYouTubeLink != null && aNodesWithYouTubeLink.Count > 0)
                {
                    result = true;
                    // If at least one YouTube channel link is found, return true
                }
                else
                {
                    result = false;
                    // If no YouTube channel link is found, return false
                }

                var setup = settings.HasYouTubeChannel;

                if (setup == result)
                {
                    result = setup;
                }
                else 
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                // Handle exceptions gracefully and return false in case of any errors
                return false;
            }

            return result;
        }

        public async Task<string> GetFacebookPage(string websiteUrl)
        {
            string result = "";

            try
            {
                string htmlContent = await ConvertWebsiteToHtml(websiteUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                //a
                var anchorNodes = doc.DocumentNode.SelectNodes("//a");

                if (anchorNodes != null)
                {
                    foreach (var anchorNode in anchorNodes)
                    {
                        string pageLink = anchorNode.Attributes["href"].Value;

                        var web = new HtmlWeb();
                        var doc2 = web.Load(pageLink);

                        string xpathExpression = "//a[contains(@href, 'https://www.facebook.com/')]/@href";
                        HtmlNode facebookLinkNode = doc.DocumentNode.SelectSingleNode(xpathExpression);

                        if (facebookLinkNode != null)
                        {
                            result = facebookLinkNode.GetAttributeValue("href", "");

                            return result;
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }

            return result;
        }

        public async Task<string> GetYouTubeChannel(string websiteUrl)
        {
            string result = "";

            try
            {
                string htmlContent = await ConvertWebsiteToHtml(websiteUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                //a
                var anchorNodes = doc.DocumentNode.SelectNodes("//a");

                if (anchorNodes != null)
                {
                    foreach (var anchorNode in anchorNodes)
                    {
                        string pageLink = anchorNode.Attributes["href"].Value;

                        var web = new HtmlWeb();
                        var doc2 = web.Load(pageLink);

                        string xpathExpression = "//a[contains(@href, 'youtube.com')]/@href";
                        HtmlNode facebookLinkNode = doc.DocumentNode.SelectSingleNode(xpathExpression);

                        if (facebookLinkNode != null)
                        {
                            result = facebookLinkNode.GetAttributeValue("href", "");

                            return result;
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }

            return result;
        }

        public async Task<string> GetEmailAddressFromContactPage(string websiteUrl)
        {
            string email = "";

            try
            {
                string baseUrl = await ConvertWebsiteToText(websiteUrl);
                string htmlContent = baseUrl + "/contact";

                // Define a regular expression pattern to match valid email addresses
                string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

                // Create a regular expression object and match the pattern in the input string
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(htmlContent);

                // Report on each match.
                foreach (Match match in matches)
                {
                    bool validEmail = match.Value.Contains(".com");

                    if (validEmail == true)
                    {
                        email = match.Value.Split(".com")[0];
                        email = email + ".com";

                        return email;
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }

            return email;
        }

        public async Task<string> FindEmailAddress(string profileUrl, bool contactPage)
        {
            if (contactPage)
            {
                return await GetEmailAddressFromContactPage(profileUrl);
            }
            else
            {
                return await GetEmailAddress(profileUrl);
            }
        }

        public async Task<string> FindBusienssWebsite(string profileUrl, bool contactPage)
        {
            if (contactPage)
            {
                var baseUrl = await GetBusinessWebsite(profileUrl);
                var url = baseUrl.Split(".com")[0] + ".com/contact";

                return url;
            }
            else
            {
                return await GetBusinessWebsite(profileUrl);
            }
        }
    }
}
