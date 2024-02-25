using EmailValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YelpMe.Interfaces;
using YelpMe.Models;
using YelpMe.ViewModels;

namespace YelpMe.Repositories
{
    public class YelpRepo : IYelpMe
    {
        public AppDbContext appDbContext = new AppDbContext();


        public async Task<string> GetCompanyName(string profileUrl)
        {
            try
            {
                // Initialize an HttpClient to download the web page content.
                using (HttpClient client = new HttpClient())
                {
                    string htmlContent = await client.GetStringAsync(profileUrl);

                    // Load the HTML document using HtmlAgilityPack
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlContent);

                    // Now you can use HtmlAgilityPack to select and manipulate elements in the HTML.
                    // For example, to extract the text within an h1 element with class "css-1se8maq":
                    var h1Element = doc.DocumentNode.SelectSingleNode("//h1[contains(@class, 'css-1se8maq')]");

                    if (h1Element != null)
                    {
                        // Extract the inner text of the <h1> element
                        string name = h1Element.InnerText;

                        return name;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (HttpRequestException)
            {
                // Handle exceptions or log the error as needed.
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
                        string html = await ConvertWebsiteToHtml(pageLink);

                        // Define a regular expression pattern to match email addresses
                        string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

                        // Create a regular expression object and match the pattern in the input string
                        Regex regex = new Regex(pattern);
                        MatchCollection matches = regex.Matches(html);

                        // Report on each match.
                        foreach (Match match in matches)
                        {
                            bool validEmail = EmailValidator.Validate(match.Value);

                            if (validEmail)
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
                HttpClient httpClient = new HttpClient();
                string htmlContent = await httpClient.GetStringAsync(profileUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                //p[contains(@class, 'css-ux5mu6')]
                var anchorNode = doc.DocumentNode.SelectSingleNode("//p[contains(@class, 'css-ux5mu6')]");

                if (anchorNode != null)
                {
                    // Extract the inner text of the <a> tag
                    string name = anchorNode.InnerText.Split(" ")[0];

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
            try
            {
                HttpClient httpClient = new HttpClient();
                string htmlContent = await httpClient.GetStringAsync(profileUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                //p[contains(@class, 'css-1p9ibgf')]
                var anchorNode = doc.DocumentNode.SelectSingleNode("//p[contains(@class, 'css-1p9ibgf')]");

                if (anchorNode != null)
                {
                    // Extract the inner text of the <a> tag
                    string phone = anchorNode.InnerText;

                    return phone;
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

        public async Task<string> GetBusinessWebsite(string profileUrl)
        {
            string linkUrl = "";

            try
            {
                HttpClient httpClient = new HttpClient();
                string htmlContent = await httpClient.GetStringAsync(profileUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                // "//a[contains(@class, 'css-1idmmu3')]"
                //class="css-1idmmu3"
                var pNodesWithClass = doc.DocumentNode.SelectNodes("//a[contains(@class, 'css-1idmmu3')]");

                if (pNodesWithClass != null)
                {
                    foreach (var pNode in pNodesWithClass)
                    {
                        string baseURL = "https://";
                        string url = baseURL + pNode.InnerText;

                        bool isWebsite = await ValidUrl(url);

                        // Extract the link URL and inner text of the <a> tag within the <p> tag
                        if (isWebsite == true)
                        {
                            linkUrl = url;
                            break;
                        }
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

        public async Task<bool> ValidUrl(string url)
        {
            string pattern = @"^(http|https|ftp)://([\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?)$";
            return Regex.IsMatch(url, pattern);
        }

        public async Task<bool> ContainsFacebookPixelCode(string profileUrl)
        {
            bool result = false;

            try
            {
                HttpClient httpClient = new HttpClient();
                string htmlContent = await httpClient.GetStringAsync(profileUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                // a[contains(@class, 'css-1idmmu3')]"
                var pNodesWithClass = doc.DocumentNode.SelectNodes("//a[contains(@class, 'css-1idmmu3')]");

                if (pNodesWithClass != null)
                {
                    foreach (var pNode in pNodesWithClass)
                    {
                        // Define patterns or keywords to identify Facebook Pixel code
                        string[] pixelKeywords = { "fbq('init',", "fbevents.js" };

                        foreach (var keyword in pixelKeywords)
                        {
                            if (pNode.InnerHtml.Contains(keyword))
                            {
                                result = true;

                                return result;
                            }
                        }

                        result = false;

                        return result;
                    }
                }
                else
                {
                    return false;
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
                    // If at least one YouTube channel link is found, return true
                    return true;
                }

                // If no YouTube channel link is found, return false
                return false;
            }
            catch (Exception)
            {
                // Handle exceptions gracefully and return false in case of any errors
                return false;
            }
        }

        public Task<string> GetFacebookPage(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetYouTubeChannel(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAddressFromContactPage(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFacebookPageFromContactPage(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetYouTubeChannelFromContactPage(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ContainsFacebookPixelCodeFromContactPage(string websiteUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> FindEmailAddress(string website, bool contactPage)
        {
            throw new NotImplementedException();
        }

        public Task<string> FindBusienssWebsite(string website, bool contactPage)
        {
            throw new NotImplementedException();
        }
    }
}
