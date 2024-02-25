using System.Security.AccessControl;
using HtmlAgilityPack;
using YelpMe.ViewModels;
using System.Text.RegularExpressions;
using YelpMe.Models;
using EmailValidation;
using System.Net.Mail;
using YelpMe.Forms;
using System.Linq.Expressions;
using CsvHelper;
using System.Globalization;
using YelpMe.Repositories;
using YelpMe.Forms.Accounts;
using ScrapeHero.Api;
using Microsoft.Identity.Client;
using System.Security.Principal;
using ScrapeHero.Models;
using ScrapeHero.Forms.Settings.Cloud_Servers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ScrapeHero.Repositories;
using ScrapeHero.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata;
using ScrapeHero.Constants;
using InstagramApiSharp.API;
using ScrapeHero.Forms.Intergations;

namespace YelpMe
{
    public partial class YelpMe : Form
    {
        private AppDbContext appDbContext = new AppDbContext();
        private List<MessageViewModels> messegeViewModels = new List<MessageViewModels>();
        private YellowPageRepo yellowPageRepo = new YellowPageRepo();
        private YelpRepo yelpRepo = new YelpRepo();
        private Models.Settings settings = new Models.Settings();
        private NameApiSettings nameApiSettings = new NameApiSettings();
        private ScrapeApi scrapeApi = new ScrapeApi();
        private NameAPIRepo nameAPIRepo = new NameAPIRepo();
        private AppConstant appConstant = new AppConstant();
        private WhatsAppApi WhatsAppApi = new WhatsAppApi();

        public YelpMe()
        {
            InitializeComponent();
        }

        private void YelpMe_Load(object sender, EventArgs e)
        {

            GetBusinessUpdates();

            settings = appDbContext.Settings.FirstOrDefault();

            nameApiSettings = appDbContext.NameApiSettings.FirstOrDefault();

            var templates = appDbContext.Templates.ToList();
            var accounts = appDbContext.Accounts.ToList();

            foreach (var temp in templates)
            {
                cboTemplates.Items.Add(temp.Name);
            }

            foreach (var account in accounts)
            {
                cboAccount.Items.Add(account.Email);
            }
        }

        private void dataControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void grpRevision_Enter(object sender, EventArgs e)
        {

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            SearchViewModels searchViewModels = new SearchViewModels();

            searchViewModels.Keywords = txtKeywords.Text;
            searchViewModels.Location = txtLocation.Text;
            searchViewModels.Page = int.Parse(txtPages.Text);
            searchViewModels.PersonalEmail = ckPersonalEmails.Checked;
            searchViewModels.SearchFacebookPixel = ckFacebook.Checked;
            searchViewModels.SearchYouTubeChannel = ckYouTubeChannel.Checked;
            searchViewModels.ContactPage = ckContactPage.Checked;
            searchViewModels.AccelerateMode = ckAccelerateMode.Checked;
            searchViewModels.CloudId = appDbContext.Clouds.FirstOrDefault().Id;

            searchViewModels.SearchOffline = settings.SearchOffline;

            if (settings.SearchOffline)
            {
                await GetYellowPageListings(searchViewModels);
            }
            else
            {
                scrapeApi.Post(searchViewModels);
            }
        }

        public void GetBusinessUpdates()
        {
            var business = appDbContext.Business.ToList();

            txtAllContacts.Text = business.Count.ToString();
            txtUniqueContact.Text = business.GroupBy(x => x.Email).ToList().Count.ToString();
            txtSentContacts.Text = business.Where(x => x.Sent == true).ToList().Count.ToString();
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
                        return "";
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public async Task<bool> GetYelpListings(SearchViewModels searchViewModel)
        {
            try
            {
                int index = 0;

                string baseURL = "https://www.yelp.com/";
                string keywords = searchViewModel.Keywords;
                string location = searchViewModel.Location;
                bool facebookPixel = searchViewModel.SearchFacebookPixel;
                bool youtubeChannel = searchViewModel.SearchYouTubeChannel;
                bool accelerateModel = searchViewModel.AccelerateMode;
                bool noFilter = (searchViewModel.SearchFacebookPixel == false && searchViewModel.SearchYouTubeChannel == false);
                int page = searchViewModel.Page;

                for (var i = 0; i < page; i++)
                {
                    string url = $"{baseURL}search?find_desc={keywords.Replace("+", " ")}&find_loc={location.Replace("+", " ")}&start={index}";
                    lstResults.Items.Add($"Fetching data for page {i + 1} from URL: {url}");

                    string htmlContent = await ConvertWebsiteToHtml(url);
                    lstResults.Items.Add("HTML content fetched successfully.");

                    // Load the HTML document using HtmlAgilityPack
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlContent);
                    lstResults.Items.Add("HTML document loaded successfully.");

                    // Select anchor nodes
                    var anchorNodes = doc.DocumentNode.SelectNodes("//a[contains(@class, 'css-19v1rkv')]");

                    if (anchorNodes != null)
                    {
                        foreach (var anchorNode in anchorNodes)
                        {
                            if (anchorNode.Attributes["href"].Value.Contains("/biz"))
                            {
                                string profileUrl = baseURL + anchorNode.Attributes["href"].Value;
                                string websiteUrl = await yelpRepo.GetBusinessWebsite(profileUrl);

                                lstResults.Items.Add($"Fetched website URL: {websiteUrl}");

                                string email = await yelpRepo.GetEmailAddress(websiteUrl);

                                if (accelerateModel == true)
                                {
                                    lstResults.Items.Add($"Fetched email: {email}");

                                    Business business = new Business();

                                    business.Keywords = keywords;
                                    business.Location = location;
                                    business.Name = await yelpRepo.GetOwnersName(profileUrl);
                                    business.Email = email;
                                    business.Phone = await yelpRepo.GetPhoneNumber(profileUrl);
                                    business.Profile = profileUrl;
                                    business.Website = websiteUrl;
                                    business.Company = await yelpRepo.GetCompanyName(profileUrl);
                                    business.PersonalLine = "";
                                    business.Sent = false;
                                    business.AddedDate = DateTime.Now;

                                    appDbContext.Business.Add(business);
                                    appDbContext.SaveChanges();

                                    lstResults.Items.Add("Business data saved to the database.");

                                    GetBusinessUpdates();
                                }
                                else
                                {
                                    if (email != "")
                                    {
                                        var query = appDbContext.Business.Where(x => x.Email == email).FirstOrDefault();

                                        if (query == null)
                                        {
                                            if (noFilter == true)
                                            {
                                                lstResults.Items.Add($"Fetched email: {email}");

                                                Business business = new Business();

                                                business.Keywords = keywords;
                                                business.Location = location;
                                                business.Name = await yelpRepo.GetOwnersName(profileUrl);
                                                business.Email = email;
                                                business.Phone = await yelpRepo.GetPhoneNumber(profileUrl);
                                                business.Profile = profileUrl;
                                                business.Website = websiteUrl;
                                                business.Company = await yelpRepo.GetCompanyName(profileUrl);
                                                business.PersonalLine = "";
                                                business.Sent = false;
                                                business.AddedDate = DateTime.Now;

                                                appDbContext.Business.Add(business);
                                                appDbContext.SaveChanges();

                                                lstResults.Items.Add("Business data saved to the database.");

                                                GetBusinessUpdates();
                                            }
                                            else
                                            {
                                                if (facebookPixel == true)
                                                {
                                                    lstResults.Items.Add($"Fetched email: {email}");

                                                    bool hasFacebookPixel = await yelpRepo.ContainsFacebookPixelCode(websiteUrl);

                                                    lstResults.Items.Add($"Checking if website: {websiteUrl} - has a Facebook Pixel.");

                                                    if (hasFacebookPixel)
                                                    {
                                                        lstResults.Items.Add($"Facebook Pixel found.");

                                                        Business business = new Business();

                                                        business.Keywords = keywords;
                                                        business.Location = location;
                                                        business.Name = await yelpRepo.GetOwnersName(profileUrl);
                                                        business.Email = email;
                                                        business.Phone = await yelpRepo.GetPhoneNumber(profileUrl);
                                                        business.Profile = profileUrl;
                                                        business.Website = websiteUrl;
                                                        business.Company = await yelpRepo.GetCompanyName(profileUrl);
                                                        business.PersonalLine = "";
                                                        business.Sent = false;
                                                        business.AddedDate = DateTime.Now;

                                                        appDbContext.Business.Add(business);
                                                        appDbContext.SaveChanges();

                                                        lstResults.Items.Add("Business data saved to the database.");

                                                        GetBusinessUpdates();
                                                    }
                                                }
                                                if (facebookPixel == false)
                                                {
                                                    lstResults.Items.Add($"Fetched email: {email}");

                                                    Business business = new Business();

                                                    business.Keywords = keywords;
                                                    business.Location = location;
                                                    business.Name = await yelpRepo.GetOwnersName(profileUrl);
                                                    business.Email = email;
                                                    business.Phone = await yelpRepo.GetPhoneNumber(profileUrl);
                                                    business.Profile = profileUrl;
                                                    business.Website = websiteUrl;
                                                    business.Company = await yelpRepo.GetCompanyName(profileUrl);
                                                    business.PersonalLine = "";
                                                    business.Sent = false;
                                                    business.AddedDate = DateTime.Now;

                                                    appDbContext.Business.Add(business);
                                                    appDbContext.SaveChanges();

                                                    lstResults.Items.Add("Business data saved to the database.");

                                                    GetBusinessUpdates();
                                                }

                                                if (youtubeChannel == true)
                                                {
                                                    lstResults.Items.Add($"Fetched email: {email}");

                                                    bool hasYouTubeChannel = await yelpRepo.ContainYouTubeChannel(websiteUrl);

                                                    lstResults.Items.Add($"Checking if website: {websiteUrl} - has a YouTube Channel.");

                                                    if (hasYouTubeChannel)
                                                    {
                                                        lstResults.Items.Add($"YouTube Channel found.");

                                                        Business business = new Business();

                                                        business.Keywords = keywords;
                                                        business.Location = location;
                                                        business.Name = await yelpRepo.GetOwnersName(profileUrl);
                                                        business.Email = email;
                                                        business.Phone = await yelpRepo.GetPhoneNumber(profileUrl);
                                                        business.Profile = profileUrl;
                                                        business.Website = websiteUrl;
                                                        business.Company = await yelpRepo.GetCompanyName(profileUrl);
                                                        business.PersonalLine = "";
                                                        business.Sent = false;
                                                        business.AddedDate = DateTime.Now;

                                                        appDbContext.Business.Add(business);
                                                        appDbContext.SaveChanges();

                                                        lstResults.Items.Add("Business data saved to the database.");

                                                        GetBusinessUpdates();
                                                    }
                                                }
                                                if (youtubeChannel == false)
                                                {
                                                    lstResults.Items.Add($"Fetched email: {email}");

                                                    Business business = new Business();

                                                    business.Keywords = keywords;
                                                    business.Location = location;
                                                    business.Name = await yelpRepo.GetOwnersName(profileUrl);
                                                    business.Email = email;
                                                    business.Phone = await yelpRepo.GetPhoneNumber(profileUrl);
                                                    business.Profile = profileUrl;
                                                    business.Website = websiteUrl;
                                                    business.Company = await yelpRepo.GetCompanyName(profileUrl);
                                                    business.PersonalLine = "";
                                                    business.Sent = false;
                                                    business.AddedDate = DateTime.Now;

                                                    appDbContext.Business.Add(business);
                                                    appDbContext.SaveChanges();

                                                    lstResults.Items.Add("Business data saved to the database.");

                                                    GetBusinessUpdates();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            lstResults.Items.Add("Skiping this business becaus it is already saved to the database.");
                                        }
                                    }
                                }
                            }
                        }

                        index = 10 * i;
                    }
                    else
                    {
                        lstResults.Items.Add("No anchor nodes found in the HTML content.");
                        return false;
                    }
                }

                GetBusinessUpdates();
            }
            catch (Exception ex)
            {
                lstResults.Items.Add(ex.Message);
            }

            return true;
        }

        public async Task<bool> GetYellowPageListings(SearchViewModels searchViewModel)
        {
            try
            {
                //Check the current page...
                int index = 0;

                string baseURL = "https://www.yellowpages.com";
                string keywords = searchViewModel.Keywords;
                string location = searchViewModel.Location;
                bool facebookPixel = searchViewModel.SearchYouTubeChannel;
                bool youTubeChannel = searchViewModel.SearchYouTubeChannel;
                bool accerelateModel = searchViewModel.AccelerateMode;
                bool noFilter = (searchViewModel.SearchFacebookPixel == false || searchViewModel.SearchYouTubeChannel == false);
                int page = searchViewModel.Page;
                bool peronalEmail = searchViewModel.PersonalEmail;

                bool useContactPage = searchViewModel.ContactPage;

                int nameApiKeyRowIndex = 0;

                for (var i = 0; i < page; i++)
                {
                    try
                    {
                        string url = $"{baseURL}/search?search_terms={keywords.Replace(" ", "+")}&geo_location_terms={location.Replace(" ", "+")}&page={index}";
                        lstResults.Items.Add($"Fetching data for page {i + 1} from URL: {url}");

                        string htmlContent = await yellowPageRepo.ConvertWebsiteToHtml(url);
                        lstResults.Items.Add("HTML content fetched successfully.");

                        // Load the HTML document using HtmlAgilityPack
                        var doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(htmlContent);
                        lstResults.Items.Add("HTML document loaded successfully.");

                        // Select anchor nodes
                        var anchorNodes = doc.DocumentNode.SelectNodes("//a[contains(@class, 'business-name')]");

                        if (anchorNodes != null)
                        {
                            foreach (var anchorNode in anchorNodes)
                            {
                                if (anchorNode.Attributes["href"].Value.Contains("/mip"))
                                {
                                    string profileUrl = baseURL + anchorNode.Attributes["href"].Value;
                                    string websiteUrl = await yellowPageRepo.FindBusienssWebsite(profileUrl, useContactPage);

                                    lstResults.Items.Add($"Fetched website URL: {websiteUrl}");

                                    string email = await yellowPageRepo.FindEmailAddress(websiteUrl, useContactPage);

                                    if (accerelateModel == true)
                                    {
                                        var query = appDbContext.Business.Where(x => x.Email == email).FirstOrDefault();

                                        if (query == null)
                                        {
                                            lstResults.Items.Add($"Fetched email: {email}");

                                            Business business = new Business();

                                            business.Keywords = keywords;
                                            business.Location = location;
                                            business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                            business.Email = email;
                                            business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                            business.Profile = profileUrl;
                                            business.Website = websiteUrl;
                                            business.FacebookPage = "";
                                            business.YouTubeChannel = "";
                                            business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                            business.PersonalLine = "";
                                            business.Sent = false;
                                            business.AddedDate = DateTime.Now;

                                            if (facebookPixel == true)
                                            {
                                                business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                            }

                                            if (youTubeChannel == true)
                                            {
                                                business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                            }

                                            appDbContext.Business.Add(business);
                                            appDbContext.SaveChanges();

                                            lstResults.Items.Add("Business data saved to the database.");

                                            GetBusinessUpdates();
                                        }
                                        else
                                        {
                                            lstResults.Items.Add("Skiping this business becaus it is already saved to the database.");
                                        }
                                    }
                                    else
                                    {
                                        if (email != "")
                                        {
                                            var query = appDbContext.Business.Where(x => x.Email == email).FirstOrDefault();

                                            if (query == null)
                                            {
                                                if (peronalEmail)
                                                {
                                                    bool isPersonalEmail = appConstant.PersonalEmail(email);

                                                    if (isPersonalEmail)
                                                    {
                                                        if (settings.UseNameApi == true)
                                                        {
                                                            /*
                                                            Disabled: no
                                                            Credits/Month: 10000
                                                            Credits/Day: 1000
                                                            Credits/Hour: 300
                                                            Credits/Minute: 30
                                                            Simultaneous: 1
                                                            Min Response Time: 500ms
                                                            Interval: 2023-10-19
                                                            Credits spent: 12
                                                            Total requests: 7
                                                            Successful requests: 6
                                                            */

                                                            //Get the properties for getting information about the email validation...
                                                            EmailValidationResponse validEmail = new EmailValidationResponse();

                                                            //Get the properties for getting information about the persons name that is using the email...
                                                            NameApiViewModels emailRealName = new NameApiViewModels();

                                                            //If you want to use multiple api to increase your NAME API procedures without request limitation, use this...
                                                            if (nameApiSettings.UseMultipleKeys == true)
                                                            {
                                                                //Get all the NAME API Keys that you saved into your database...
                                                                List<NameApiKeys> apiKeys = appDbContext.NameApiKeys.ToList();

                                                                //Check these this option are enabled so you don't the API request carelessily...
                                                                bool enableEmailValidate = nameApiSettings.ValidEmail;
                                                                bool enableEmailRealName = nameApiSettings.HumanNameEmails;

                                                                //Just the prospects name holder here, once you have found their real name using NAME API.
                                                                string userName = null;

                                                                //The NAME API Key that the machine has selected to use to verify this current lead...
                                                                string selectedApiKey = apiKeys[nameApiKeyRowIndex].ApiKey;

                                                                //If this option is true, you are free to use the NAME API requests
                                                                if (enableEmailValidate == true)
                                                                {
                                                                    validEmail = await nameAPIRepo.DisposableEmaiAddressDetector(email, selectedApiKey);

                                                                    if (validEmail.disposable == "NO")
                                                                    {
                                                                        if (enableEmailRealName == true)
                                                                        {
                                                                            emailRealName = await nameAPIRepo.EmailNameParser(email, selectedApiKey);

                                                                            if (emailRealName.ResultType == "PERSON_NAME")
                                                                            {
                                                                                userName = emailRealName.NameMatches[0].GivenNames[0].Name;

                                                                                lstResults.Items.Add($"Fetched email: {email}");

                                                                                Business business = new Business();

                                                                                business.Keywords = keywords;
                                                                                business.Location = location;
                                                                                business.Name = userName;
                                                                                business.Email = email;
                                                                                business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                                business.Profile = profileUrl;
                                                                                business.Website = websiteUrl;
                                                                                business.FacebookPage = "";
                                                                                business.YouTubeChannel = "";
                                                                                business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                                business.PersonalLine = "";
                                                                                business.Sent = false;
                                                                                business.AddedDate = DateTime.Now;

                                                                                if (facebookPixel == true)
                                                                                {
                                                                                    business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                                }

                                                                                if (youTubeChannel == true)
                                                                                {
                                                                                    business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                                }

                                                                                appDbContext.Business.Add(business);
                                                                                appDbContext.SaveChanges();

                                                                                lstResults.Items.Add("Business data saved to the database.");

                                                                                GetBusinessUpdates();
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            lstResults.Items.Add($"Fetched email: {email}");

                                                                            Business business = new Business();

                                                                            business.Keywords = keywords;
                                                                            business.Location = location;
                                                                            business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                            business.Email = email;
                                                                            business.Phone = await yellowPageRepo.GetPhoneNumber(websiteUrl);
                                                                            business.Profile = profileUrl;
                                                                            business.Website = websiteUrl;
                                                                            business.FacebookPage = "";
                                                                            business.YouTubeChannel = "";
                                                                            business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                            business.PersonalLine = "";
                                                                            business.Sent = false;
                                                                            business.AddedDate = DateTime.Now;

                                                                            if (facebookPixel == true)
                                                                            {
                                                                                business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                            }

                                                                            if (youTubeChannel == true)
                                                                            {
                                                                                business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                            }

                                                                            appDbContext.Business.Add(business);
                                                                            appDbContext.SaveChanges();

                                                                            lstResults.Items.Add("Business data saved to the database.");

                                                                            GetBusinessUpdates();
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (enableEmailRealName == true)
                                                                    {
                                                                        emailRealName = await nameAPIRepo.EmailNameParser(email, selectedApiKey);

                                                                        if (emailRealName.ResultType == "PERSON_NAME")
                                                                        {
                                                                            userName = emailRealName.NameMatches[0].GivenNames[0].Name;

                                                                            lstResults.Items.Add($"Fetched email: {email}");

                                                                            Business business = new Business();

                                                                            business.Keywords = keywords;
                                                                            business.Location = location;
                                                                            business.Name = userName;
                                                                            business.Email = email;
                                                                            business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                            business.Profile = profileUrl;
                                                                            business.Website = websiteUrl;
                                                                            business.FacebookPage = "";
                                                                            business.YouTubeChannel = "";
                                                                            business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                            business.PersonalLine = "";
                                                                            business.Sent = false;
                                                                            business.AddedDate = DateTime.Now;

                                                                            if (facebookPixel == true)
                                                                            {
                                                                                business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                            }

                                                                            if (youTubeChannel == true)
                                                                            {
                                                                                business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                            }

                                                                            appDbContext.Business.Add(business);
                                                                            appDbContext.SaveChanges();

                                                                            lstResults.Items.Add("Business data saved to the database.");

                                                                            GetBusinessUpdates();
                                                                        }
                                                                    }
                                                                }

                                                                nameApiKeyRowIndex = (nameApiKeyRowIndex + 1) % apiKeys.Count;
                                                            }
                                                            else
                                                            {
                                                                //Get all the NAME API Keys that you saved into your database...
                                                                List<NameApiKeys> apiKey = appDbContext.NameApiKeys.ToList();

                                                                //Check these this option are enabled so you don't the API request carelessily...
                                                                bool enableEmailValidate = nameApiSettings.ValidEmail;
                                                                bool enableEmailRealName = nameApiSettings.HumanNameEmails;

                                                                //Just the prospects name holder here, once you have found their real name using NAME API.
                                                                string userName = null;

                                                                //The NAME API Key that the machine has selected to use to verify this current lead...
                                                                string selectedApiKey = apiKey.Where(x => x.Id == nameApiSettings.SelectApiKeyId).FirstOrDefault().ApiKey;

                                                                //If this option is true, you are free to use the NAME API requests
                                                                if (enableEmailValidate == true)
                                                                {
                                                                    validEmail = await nameAPIRepo.DisposableEmaiAddressDetector(email, selectedApiKey);

                                                                    if (validEmail.disposable == "NO")
                                                                    {
                                                                        if (enableEmailRealName == true)
                                                                        {
                                                                            emailRealName = await nameAPIRepo.EmailNameParser(email, selectedApiKey);

                                                                            if (emailRealName.ResultType == "PERSON_NAME")
                                                                            {
                                                                                userName = emailRealName.NameMatches[0].GivenNames[0].Name;

                                                                                lstResults.Items.Add($"Fetched email: {email}");

                                                                                Business business = new Business();

                                                                                business.Keywords = keywords;
                                                                                business.Location = location;
                                                                                business.Name = userName;
                                                                                business.Email = email;
                                                                                business.Phone = await yellowPageRepo.GetPhoneNumber(websiteUrl);
                                                                                business.Profile = profileUrl;
                                                                                business.Website = websiteUrl;
                                                                                business.FacebookPage = "";
                                                                                business.YouTubeChannel = "";
                                                                                business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                                business.PersonalLine = "";
                                                                                business.Sent = false;
                                                                                business.AddedDate = DateTime.Now;

                                                                                if (facebookPixel == true)
                                                                                {
                                                                                    business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                                }

                                                                                if (youTubeChannel == true)
                                                                                {
                                                                                    business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                                }

                                                                                appDbContext.Business.Add(business);
                                                                                appDbContext.SaveChanges();

                                                                                lstResults.Items.Add("Business data saved to the database.");

                                                                                GetBusinessUpdates();
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            lstResults.Items.Add($"Fetched email: {email}");

                                                                            Business business = new Business();

                                                                            business.Keywords = keywords;
                                                                            business.Location = location;
                                                                            business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                            business.Email = email;
                                                                            business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                            business.Profile = profileUrl;
                                                                            business.Website = websiteUrl;
                                                                            business.FacebookPage = "";
                                                                            business.YouTubeChannel = "";
                                                                            business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                            business.PersonalLine = "";
                                                                            business.Sent = false;
                                                                            business.AddedDate = DateTime.Now;

                                                                            if (facebookPixel == true)
                                                                            {
                                                                                business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                            }

                                                                            if (youTubeChannel == true)
                                                                            {
                                                                                business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                            }

                                                                            appDbContext.Business.Add(business);
                                                                            appDbContext.SaveChanges();

                                                                            lstResults.Items.Add("Business data saved to the database.");

                                                                            GetBusinessUpdates();
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (enableEmailRealName == true)
                                                                    {
                                                                        emailRealName = await nameAPIRepo.EmailNameParser(email, selectedApiKey);

                                                                        if (emailRealName.ResultType == "PERSON_NAME")
                                                                        {
                                                                            userName = emailRealName.NameMatches[0].GivenNames[0].Name;

                                                                            lstResults.Items.Add($"Fetched email: {email}");

                                                                            Business business = new Business();

                                                                            business.Keywords = keywords;
                                                                            business.Location = location;
                                                                            business.Name = userName;
                                                                            business.Email = email;
                                                                            business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                            business.Profile = profileUrl;
                                                                            business.Website = websiteUrl;
                                                                            business.FacebookPage = "";
                                                                            business.YouTubeChannel = "";
                                                                            business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                            business.PersonalLine = "";
                                                                            business.Sent = false;
                                                                            business.AddedDate = DateTime.Now;

                                                                            if (facebookPixel == true)
                                                                            {
                                                                                business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                            }

                                                                            if (youTubeChannel == true)
                                                                            {
                                                                                business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                            }

                                                                            appDbContext.Business.Add(business);
                                                                            appDbContext.SaveChanges();

                                                                            lstResults.Items.Add("Business data saved to the database.");

                                                                            GetBusinessUpdates();
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (noFilter == true)
                                                            {
                                                                lstResults.Items.Add($"Fetched email: {email}");

                                                                Business business = new Business();

                                                                business.Keywords = keywords;
                                                                business.Location = location;
                                                                business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                business.Email = email;
                                                                business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                business.Profile = profileUrl;
                                                                business.Website = websiteUrl;
                                                                business.FacebookPage = "";
                                                                business.YouTubeChannel = "";
                                                                business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                business.PersonalLine = "";
                                                                business.Sent = false;
                                                                business.AddedDate = DateTime.Now;

                                                                if (facebookPixel == true)
                                                                {
                                                                    business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                }

                                                                if (youTubeChannel == true)
                                                                {
                                                                    business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                }

                                                                appDbContext.Business.Add(business);
                                                                appDbContext.SaveChanges();

                                                                lstResults.Items.Add("Business data saved to the database.");

                                                                GetBusinessUpdates();
                                                            }
                                                            else
                                                            {
                                                                if (facebookPixel == true)
                                                                {
                                                                    lstResults.Items.Add($"Fetched email: {email}");

                                                                    bool hasFacebookPixel = await yellowPageRepo.ContainsFacebookPixelCode(websiteUrl);

                                                                    lstResults.Items.Add($"Checking if website: {websiteUrl} - has a Facebook Pixel.");

                                                                    if (hasFacebookPixel)
                                                                    {
                                                                        lstResults.Items.Add($"Facebook Pixel found.");

                                                                        Business business = new Business();

                                                                        business.Keywords = keywords;
                                                                        business.Location = location;
                                                                        business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                        business.Email = email;
                                                                        business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                        business.Profile = profileUrl;
                                                                        business.Website = websiteUrl;
                                                                        business.FacebookPage = "";
                                                                        business.YouTubeChannel = "";
                                                                        business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                        business.PersonalLine = "";
                                                                        business.Sent = false;
                                                                        business.AddedDate = DateTime.Now;

                                                                        if (facebookPixel == true)
                                                                        {
                                                                            business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                        }

                                                                        if (youTubeChannel == true)
                                                                        {
                                                                            business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                        }

                                                                        appDbContext.Business.Add(business);
                                                                        appDbContext.SaveChanges();

                                                                        lstResults.Items.Add("Business data saved to the database.");

                                                                        GetBusinessUpdates();
                                                                    }
                                                                }
                                                                if (facebookPixel == false)
                                                                {
                                                                    lstResults.Items.Add($"Fetched email: {email}");

                                                                    Business business = new Business();

                                                                    business.Keywords = keywords;
                                                                    business.Location = location;
                                                                    business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                    business.Email = email;
                                                                    business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                    business.Profile = profileUrl;
                                                                    business.Website = websiteUrl;
                                                                    business.FacebookPage = "";
                                                                    business.YouTubeChannel = "";
                                                                    business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                    business.PersonalLine = "";
                                                                    business.Sent = false;
                                                                    business.AddedDate = DateTime.Now;

                                                                    if (facebookPixel == true)
                                                                    {
                                                                        business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                    }

                                                                    if (youTubeChannel == true)
                                                                    {
                                                                        business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                    }

                                                                    appDbContext.Business.Add(business);
                                                                    appDbContext.SaveChanges();

                                                                    lstResults.Items.Add("Business data saved to the database.");

                                                                    GetBusinessUpdates();
                                                                }

                                                                if (youTubeChannel == true)
                                                                {
                                                                    lstResults.Items.Add($"Fetched email: {email}");

                                                                    bool hasYoutubeChannel = await yellowPageRepo.ContainYouTubeChannel(websiteUrl);

                                                                    lstResults.Items.Add($"Checking if website: {websiteUrl} - has a YouTube Channel.");

                                                                    if (hasYoutubeChannel)
                                                                    {
                                                                        lstResults.Items.Add($"YouTube Channel found.");

                                                                        Business business = new Business();

                                                                        business.Keywords = keywords;
                                                                        business.Location = location;
                                                                        business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                        business.Email = email;
                                                                        business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                        business.Profile = profileUrl;
                                                                        business.Website = websiteUrl;
                                                                        business.FacebookPage = "";
                                                                        business.YouTubeChannel = "";
                                                                        business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                        business.PersonalLine = "";
                                                                        business.Sent = false;
                                                                        business.AddedDate = DateTime.Now;

                                                                        if (facebookPixel == true)
                                                                        {
                                                                            business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                        }

                                                                        if (youTubeChannel == true)
                                                                        {
                                                                            business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                        }

                                                                        appDbContext.Business.Add(business);
                                                                        appDbContext.SaveChanges();

                                                                        lstResults.Items.Add("Business data saved to the database.");

                                                                        GetBusinessUpdates();
                                                                    }
                                                                }
                                                                if (youTubeChannel == false)
                                                                {
                                                                    lstResults.Items.Add($"Fetched email: {email}");

                                                                    Business business = new Business();

                                                                    business.Keywords = keywords;
                                                                    business.Location = location;
                                                                    business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                    business.Email = email;
                                                                    business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                    business.Profile = profileUrl;
                                                                    business.Website = websiteUrl;
                                                                    business.FacebookPage = "";
                                                                    business.YouTubeChannel = "";
                                                                    business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                    business.PersonalLine = "";
                                                                    business.Sent = false;
                                                                    business.AddedDate = DateTime.Now;

                                                                    if (facebookPixel == true)
                                                                    {
                                                                        business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                    }

                                                                    if (youTubeChannel == true)
                                                                    {
                                                                        business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                    }

                                                                    appDbContext.Business.Add(business);
                                                                    appDbContext.SaveChanges();

                                                                    lstResults.Items.Add("Business data saved to the database.");

                                                                    GetBusinessUpdates();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (settings.UseNameApi == true)
                                                    {
                                                        /*
                                                        Disabled: no
                                                        Credits/Month: 10000
                                                        Credits/Day: 1000
                                                        Credits/Hour: 300
                                                        Credits/Minute: 30
                                                        Simultaneous: 1
                                                        Min Response Time: 500ms
                                                        Interval: 2023-10-19
                                                        Credits spent: 12
                                                        Total requests: 7
                                                        Successful requests: 6
                                                        */

                                                        //Get the properties for getting information about the email validation...
                                                        EmailValidationResponse validEmail = new EmailValidationResponse();

                                                        //Get the properties for getting information about the persons name that is using the email...
                                                        NameApiViewModels emailRealName = new NameApiViewModels();

                                                        //If you want to use multiple api to increase your NAME API procedures without request limitation, use this...
                                                        if (nameApiSettings.UseMultipleKeys == true)
                                                        {
                                                            //Get all the NAME API Keys that you saved into your database...
                                                            List<NameApiKeys> apiKeys = appDbContext.NameApiKeys.ToList();

                                                            //Check these this option are enabled so you don't the API request carelessily...
                                                            bool enableEmailValidate = nameApiSettings.ValidEmail;
                                                            bool enableEmailRealName = nameApiSettings.HumanNameEmails;

                                                            //Just the prospects name holder here, once you have found their real name using NAME API.
                                                            string userName = null;

                                                            //The NAME API Key that the machine has selected to use to verify this current lead...
                                                            string selectedApiKey = apiKeys[nameApiKeyRowIndex].ApiKey;

                                                            //If this option is true, you are free to use the NAME API requests
                                                            if (enableEmailValidate == true)
                                                            {
                                                                validEmail = await nameAPIRepo.DisposableEmaiAddressDetector(email, selectedApiKey);

                                                                if (validEmail.disposable == "NO")
                                                                {
                                                                    if (enableEmailRealName == true)
                                                                    {
                                                                        emailRealName = await nameAPIRepo.EmailNameParser(email, selectedApiKey);

                                                                        if (emailRealName.ResultType == "PERSON_NAME")
                                                                        {
                                                                            userName = emailRealName.NameMatches[0].GivenNames[0].Name;

                                                                            lstResults.Items.Add($"Fetched email: {email}");

                                                                            Business business = new Business();

                                                                            business.Keywords = keywords;
                                                                            business.Location = location;
                                                                            business.Name = userName;
                                                                            business.Email = email;
                                                                            business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                            business.Profile = profileUrl;
                                                                            business.Website = websiteUrl;
                                                                            business.FacebookPage = "";
                                                                            business.YouTubeChannel = "";
                                                                            business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                            business.PersonalLine = "";
                                                                            business.Sent = false;
                                                                            business.AddedDate = DateTime.Now;

                                                                            if (facebookPixel == true)
                                                                            {
                                                                                business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                            }

                                                                            if (youTubeChannel == true)
                                                                            {
                                                                                business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                            }

                                                                            appDbContext.Business.Add(business);
                                                                            appDbContext.SaveChanges();

                                                                            lstResults.Items.Add("Business data saved to the database.");

                                                                            GetBusinessUpdates();
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        lstResults.Items.Add($"Fetched email: {email}");

                                                                        Business business = new Business();

                                                                        business.Keywords = keywords;
                                                                        business.Location = location;
                                                                        business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                        business.Email = email;
                                                                        business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                        business.Profile = profileUrl;
                                                                        business.Website = websiteUrl;
                                                                        business.FacebookPage = "";
                                                                        business.YouTubeChannel = "";
                                                                        business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                        business.PersonalLine = "";
                                                                        business.Sent = false;
                                                                        business.AddedDate = DateTime.Now;

                                                                        if (facebookPixel == true)
                                                                        {
                                                                            business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                        }

                                                                        if (youTubeChannel == true)
                                                                        {
                                                                            business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                        }

                                                                        appDbContext.Business.Add(business);
                                                                        appDbContext.SaveChanges();

                                                                        lstResults.Items.Add("Business data saved to the database.");

                                                                        GetBusinessUpdates();
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (enableEmailRealName == true)
                                                                {
                                                                    emailRealName = await nameAPIRepo.EmailNameParser(email, selectedApiKey);

                                                                    if (emailRealName.ResultType == "PERSON_NAME")
                                                                    {
                                                                        userName = emailRealName.NameMatches[0].GivenNames[0].Name;

                                                                        lstResults.Items.Add($"Fetched email: {email}");

                                                                        Business business = new Business();

                                                                        business.Keywords = keywords;
                                                                        business.Location = location;
                                                                        business.Name = userName;
                                                                        business.Email = email;
                                                                        business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                        business.Profile = profileUrl;
                                                                        business.Website = websiteUrl;
                                                                        business.FacebookPage = "";
                                                                        business.YouTubeChannel = "";
                                                                        business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                        business.PersonalLine = "";
                                                                        business.Sent = false;
                                                                        business.AddedDate = DateTime.Now;

                                                                        if (facebookPixel == true)
                                                                        {
                                                                            business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                        }

                                                                        if (youTubeChannel == true)
                                                                        {
                                                                            business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                        }

                                                                        appDbContext.Business.Add(business);
                                                                        appDbContext.SaveChanges();

                                                                        lstResults.Items.Add("Business data saved to the database.");

                                                                        GetBusinessUpdates();
                                                                    }
                                                                }
                                                            }

                                                            nameApiKeyRowIndex = (nameApiKeyRowIndex + 1) % apiKeys.Count;
                                                        }
                                                        else
                                                        {
                                                            //Get all the NAME API Keys that you saved into your database...
                                                            List<NameApiKeys> apiKey = appDbContext.NameApiKeys.ToList();

                                                            //Check these this option are enabled so you don't the API request carelessily...
                                                            bool enableEmailValidate = nameApiSettings.ValidEmail;
                                                            bool enableEmailRealName = nameApiSettings.HumanNameEmails;

                                                            //Just the prospects name holder here, once you have found their real name using NAME API.
                                                            string userName = null;

                                                            //The NAME API Key that the machine has selected to use to verify this current lead...
                                                            string selectedApiKey = apiKey.Where(x => x.Id == nameApiSettings.SelectApiKeyId).FirstOrDefault().ApiKey;

                                                            //If this option is true, you are free to use the NAME API requests
                                                            if (enableEmailValidate == true)
                                                            {
                                                                validEmail = await nameAPIRepo.DisposableEmaiAddressDetector(email, selectedApiKey);

                                                                if (validEmail.disposable == "NO")
                                                                {
                                                                    if (enableEmailRealName == true)
                                                                    {
                                                                        emailRealName = await nameAPIRepo.EmailNameParser(email, selectedApiKey);

                                                                        if (emailRealName.ResultType == "PERSON_NAME")
                                                                        {
                                                                            userName = emailRealName.NameMatches[0].GivenNames[0].Name;

                                                                            lstResults.Items.Add($"Fetched email: {email}");

                                                                            Business business = new Business();

                                                                            business.Keywords = keywords;
                                                                            business.Location = location;
                                                                            business.Name = userName;
                                                                            business.Email = email;
                                                                            business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                            business.Profile = profileUrl;
                                                                            business.Website = websiteUrl;
                                                                            business.FacebookPage = "";
                                                                            business.YouTubeChannel = "";
                                                                            business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                            business.PersonalLine = "";
                                                                            business.Sent = false;
                                                                            business.AddedDate = DateTime.Now;

                                                                            if (facebookPixel == true)
                                                                            {
                                                                                business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                            }

                                                                            if (youTubeChannel == true)
                                                                            {
                                                                                business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                            }

                                                                            appDbContext.Business.Add(business);
                                                                            appDbContext.SaveChanges();

                                                                            lstResults.Items.Add("Business data saved to the database.");

                                                                            GetBusinessUpdates();
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        lstResults.Items.Add($"Fetched email: {email}");

                                                                        Business business = new Business();

                                                                        business.Keywords = keywords;
                                                                        business.Location = location;
                                                                        business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                        business.Email = email;
                                                                        business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                        business.Profile = profileUrl;
                                                                        business.Website = websiteUrl;
                                                                        business.FacebookPage = "";
                                                                        business.YouTubeChannel = "";
                                                                        business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                        business.PersonalLine = "";
                                                                        business.Sent = false;
                                                                        business.AddedDate = DateTime.Now;

                                                                        if (facebookPixel == true)
                                                                        {
                                                                            business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                        }

                                                                        if (youTubeChannel == true)
                                                                        {
                                                                            business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                        }

                                                                        appDbContext.Business.Add(business);
                                                                        appDbContext.SaveChanges();

                                                                        lstResults.Items.Add("Business data saved to the database.");

                                                                        GetBusinessUpdates();
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (enableEmailRealName == true)
                                                                {
                                                                    emailRealName = await nameAPIRepo.EmailNameParser(email, selectedApiKey);

                                                                    if (emailRealName.ResultType == "PERSON_NAME")
                                                                    {
                                                                        userName = emailRealName.NameMatches[0].GivenNames[0].Name;

                                                                        lstResults.Items.Add($"Fetched email: {email}");

                                                                        Business business = new Business();

                                                                        business.Keywords = keywords;
                                                                        business.Location = location;
                                                                        business.Name = userName;
                                                                        business.Email = email;
                                                                        business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                        business.Profile = profileUrl;
                                                                        business.Website = websiteUrl;
                                                                        business.FacebookPage = "";
                                                                        business.YouTubeChannel = "";
                                                                        business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                        business.PersonalLine = "";
                                                                        business.Sent = false;
                                                                        business.AddedDate = DateTime.Now;

                                                                        if (facebookPixel == true)
                                                                        {
                                                                            business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                        }

                                                                        if (youTubeChannel == true)
                                                                        {
                                                                            business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                        }

                                                                        appDbContext.Business.Add(business);
                                                                        appDbContext.SaveChanges();

                                                                        lstResults.Items.Add("Business data saved to the database.");

                                                                        GetBusinessUpdates();
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (noFilter == true)
                                                        {
                                                            lstResults.Items.Add($"Fetched email: {email}");

                                                            Business business = new Business();

                                                            business.Keywords = keywords;
                                                            business.Location = location;
                                                            business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                            business.Email = email;
                                                            business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                            business.Profile = profileUrl;
                                                            business.Website = websiteUrl;
                                                            business.FacebookPage = "";
                                                            business.YouTubeChannel = "";
                                                            business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                            business.PersonalLine = "";
                                                            business.Sent = false;
                                                            business.AddedDate = DateTime.Now;

                                                            if (facebookPixel == true)
                                                            {
                                                                business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                            }

                                                            if (youTubeChannel == true)
                                                            {
                                                                business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                            }

                                                            appDbContext.Business.Add(business);
                                                            appDbContext.SaveChanges();

                                                            lstResults.Items.Add("Business data saved to the database.");

                                                            GetBusinessUpdates();
                                                        }
                                                        else
                                                        {
                                                            if (facebookPixel == true)
                                                            {
                                                                lstResults.Items.Add($"Fetched email: {email}");

                                                                bool hasFacebookPixel = await yellowPageRepo.ContainsFacebookPixelCode(websiteUrl);

                                                                lstResults.Items.Add($"Checking if website: {websiteUrl} - has a Facebook Pixel.");

                                                                if (hasFacebookPixel)
                                                                {
                                                                    lstResults.Items.Add($"Facebook Pixel found.");

                                                                    Business business = new Business();

                                                                    business.Keywords = keywords;
                                                                    business.Location = location;
                                                                    business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                    business.Email = email;
                                                                    business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                    business.Profile = profileUrl;
                                                                    business.Website = websiteUrl;
                                                                    business.FacebookPage = "";
                                                                    business.YouTubeChannel = "";
                                                                    business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                    business.PersonalLine = "";
                                                                    business.Sent = false;
                                                                    business.AddedDate = DateTime.Now;

                                                                    if (facebookPixel == true)
                                                                    {
                                                                        business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                    }

                                                                    if (youTubeChannel == true)
                                                                    {
                                                                        business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                    }

                                                                    appDbContext.Business.Add(business);
                                                                    appDbContext.SaveChanges();

                                                                    lstResults.Items.Add("Business data saved to the database.");

                                                                    GetBusinessUpdates();
                                                                }
                                                            }
                                                            if (facebookPixel == false)
                                                            {
                                                                lstResults.Items.Add($"Fetched email: {email}");

                                                                Business business = new Business();

                                                                business.Keywords = keywords;
                                                                business.Location = location;
                                                                business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                business.Email = email;
                                                                business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                business.Profile = profileUrl;
                                                                business.Website = websiteUrl;
                                                                business.FacebookPage = "";
                                                                business.YouTubeChannel = "";
                                                                business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                business.PersonalLine = "";
                                                                business.Sent = false;
                                                                business.AddedDate = DateTime.Now;

                                                                if (facebookPixel == true)
                                                                {
                                                                    business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                }

                                                                if (youTubeChannel == true)
                                                                {
                                                                    business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                }

                                                                appDbContext.Business.Add(business);
                                                                appDbContext.SaveChanges();

                                                                lstResults.Items.Add("Business data saved to the database.");

                                                                GetBusinessUpdates();
                                                            }

                                                            if (youTubeChannel == true)
                                                            {
                                                                lstResults.Items.Add($"Fetched email: {email}");

                                                                bool hasYoutubeChannel = await yellowPageRepo.ContainYouTubeChannel(websiteUrl);

                                                                lstResults.Items.Add($"Checking if website: {websiteUrl} - has a YouTube Channel.");

                                                                if (hasYoutubeChannel)
                                                                {
                                                                    lstResults.Items.Add($"YouTube Channel found.");

                                                                    Business business = new Business();

                                                                    business.Keywords = keywords;
                                                                    business.Location = location;
                                                                    business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                    business.Email = email;
                                                                    business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                    business.Profile = profileUrl;
                                                                    business.Website = websiteUrl;
                                                                    business.FacebookPage = "";
                                                                    business.YouTubeChannel = "";
                                                                    business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                    business.PersonalLine = "";
                                                                    business.Sent = false;
                                                                    business.AddedDate = DateTime.Now;

                                                                    if (facebookPixel == true)
                                                                    {
                                                                        business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                    }

                                                                    if (youTubeChannel == true)
                                                                    {
                                                                        business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                    }

                                                                    appDbContext.Business.Add(business);
                                                                    appDbContext.SaveChanges();

                                                                    lstResults.Items.Add("Business data saved to the database.");

                                                                    GetBusinessUpdates();
                                                                }
                                                            }
                                                            if (youTubeChannel == false)
                                                            {
                                                                lstResults.Items.Add($"Fetched email: {email}");

                                                                Business business = new Business();

                                                                business.Keywords = keywords;
                                                                business.Location = location;
                                                                business.Name = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                business.Email = email;
                                                                business.Phone = await yellowPageRepo.GetPhoneNumber(profileUrl);
                                                                business.Profile = profileUrl;
                                                                business.Website = websiteUrl;
                                                                business.FacebookPage = "";
                                                                business.YouTubeChannel = "";
                                                                business.Company = await yellowPageRepo.GetCompanyName(profileUrl);
                                                                business.PersonalLine = "";
                                                                business.Sent = false;
                                                                business.AddedDate = DateTime.Now;

                                                                if (facebookPixel == true)
                                                                {
                                                                    business.FacebookPage = await yellowPageRepo.GetFacebookPage(websiteUrl);
                                                                }

                                                                if (youTubeChannel == true)
                                                                {
                                                                    business.YouTubeChannel = await yellowPageRepo.GetYouTubeChannel(websiteUrl);
                                                                }

                                                                appDbContext.Business.Add(business);
                                                                appDbContext.SaveChanges();

                                                                lstResults.Items.Add("Business data saved to the database.");

                                                                GetBusinessUpdates();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                lstResults.Items.Add("Skiping this business becaus it is already saved to the database.");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            lstResults.Items.Add("No anchor nodes found in the HTML content.");
                            return false;
                        }

                        index += 10;

                        GetBusinessUpdates();
                    }
                    catch (Exception ex)
                    {
                        lstResults.Items.Add(ex.Message);
                    }
                }

                lstResults.Items.Add("Extraction complete.");
            }
            catch (Exception ex)
            {
                lstResults.Items.Add(ex.Message);
            }

            return true;
        }

        private void dataControlsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Data_Controls data_Controls = new Data_Controls();

            data_Controls.Show();
        }

        private async void btnBatchSearch_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog class
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\"; // Set the initial directory for the dialog
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    using (var reader = new StreamReader(selectedFilePath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<SearchViewModels>();
                        // Process the records as needed

                        foreach (var item in records)
                        {
                            if (settings.SearchOffline == true)
                            {
                                await GetYellowPageListings(item);
                            }
                            else
                            {
                                scrapeApi.Post(item);
                            }
                        }
                    }
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerateSearchFile_Click(object sender, EventArgs e)
        {

        }
        private void btnDataControls_Click(object sender, EventArgs e)
        {
            Data_Controls data_Controls = new Data_Controls();

            data_Controls.Show();
        }

        public async Task ActiveMessengerType(MessageViewModels messageViewModels)
        {
            if (ckWhatsApp.Checked)
            {
                await SendWhatsappTextMessage(messageViewModels);
            }
            else
            {
                SendEmail(messageViewModels);
            }
        }

        private async void btnSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Procedure is now in progress, please wait for it to complete...");

            try
            {
                int a = 0;
                bool abTest = ckABTesting.Checked;
                bool splitAccount = ckSplitAccount.Checked;
                bool testMode = ckTestMode.Checked;

                var businesses = appDbContext.Business.Where(x => x.Sent == false).GroupBy(x => x.Email)
                            .Select(g => g.First()).ToList();

                if (testMode)
                {
                    MessageViewModels messgae = new MessageViewModels();

                    var account = appDbContext.Accounts.Where(x => x.Email == cboAccount.Text).FirstOrDefault();
                    var business = appDbContext.Business.FirstOrDefault();

                    string subject = MessageBuilding(txtSubject.Text, business, account);
                    string body = MessageBuilding(rtxtBody.Text, business, account);
                    bool htmlMode = ckHtmlMode.Checked;

                    messgae.Subject = subject;
                    messgae.Body = body;
                    messgae.EmailFrom = account.Email;
                    messgae.EmailTo = account.Email;
                    messgae.Phone = business.Phone;
                    messgae.Html = htmlMode;
                    messgae.Host = account.SmtpHost;
                    messgae.Password = account.Password;
                    messgae.Port = account.SmtpPort;
                    messgae.Ssl = account.StmpSsl;

                    await ActiveMessengerType(messgae);
                }
                else
                {
                    foreach (var business in businesses)
                    {
                        if (splitAccount == true)
                        {
                            if (abTest == true)
                            {
                                MessageViewModels messgae = new MessageViewModels();

                                var account = appDbContext.Accounts.ToList();

                                Random rMessage = new Random();
                                var r = rMessage.Next(0, messegeViewModels.Count);
                                var content = messegeViewModels;

                                string subject = MessageBuilding(content[r].Subject, business, account[a]);
                                string body = MessageBuilding(content[r].Body, business, account[a]);
                                bool htmlMode = content[r].Html;

                                messgae.Subject = subject;
                                messgae.Body = body;
                                messgae.EmailFrom = account[a].Email;
                                messgae.EmailTo = business.Email;
                                messgae.Phone = business.Phone;
                                messgae.Html = htmlMode;
                                messgae.Host = account[a].SmtpHost;
                                messgae.Password = account[a].Password;
                                messgae.Port = account[a].SmtpPort;
                                messgae.Ssl = account[a].StmpSsl;

                                lstResults.Items.Add($"A/B Test Message {r} selected...");

                                await ActiveMessengerType(messgae);

                                a = (a + 1) % account.Count;
                            }
                            else
                            {
                                MessageViewModels messgae = new MessageViewModels();

                                var account = appDbContext.Accounts.ToList();

                                string subject = MessageBuilding(txtSubject.Text, business, account[a]);
                                string body = MessageBuilding(rtxtBody.Text, business, account[a]);
                                bool htmlMode = ckHtmlMode.Checked;

                                messgae.Subject = subject;
                                messgae.Body = body;
                                messgae.EmailFrom = account[a].Email;
                                messgae.EmailTo = business.Email;
                                messgae.Phone = business.Phone;
                                messgae.Html = htmlMode;
                                messgae.Host = account[a].SmtpHost;
                                messgae.Password = account[a].Password;
                                messgae.Port = account[a].SmtpPort;
                                messgae.Ssl = account[a].StmpSsl;

                                await ActiveMessengerType(messgae);

                                a = (a + 1) % account.Count;
                            }
                        }
                        else
                        {
                            if (abTest == true)
                            {
                                MessageViewModels messgae = new MessageViewModels();

                                var account = appDbContext.Accounts.Where(x => x.Email == cboAccount.Text).FirstOrDefault();

                                Random rMessage = new Random();

                                var r = rMessage.Next(0, messegeViewModels.Count);

                                var content = messegeViewModels;

                                string subject = MessageBuilding(content[r].Subject, business, account);
                                string body = MessageBuilding(content[r].Body, business, account);
                                bool htmlMode = content[r].Html;

                                messgae.Subject = subject;
                                messgae.Body = body;
                                messgae.EmailFrom = account.Email;
                                messgae.EmailTo = business.Email;
                                messgae.Phone = business.Phone;
                                messgae.Html = htmlMode;
                                messgae.Host = account.SmtpHost;
                                messgae.Password = account.Password;
                                messgae.Port = account.SmtpPort;
                                messgae.Ssl = account.StmpSsl;

                                await ActiveMessengerType(messgae);
                            }
                            else
                            {
                                MessageViewModels messgae = new MessageViewModels();

                                var account = appDbContext.Accounts.Where(x => x.Email == cboAccount.Text).FirstOrDefault();

                                Random rAccount = new Random();

                                string subject = MessageBuilding(txtSubject.Text, business, account);
                                string body = MessageBuilding(rtxtBody.Text, business, account);
                                bool htmlMode = ckHtmlMode.Checked;

                                messgae.Subject = subject;
                                messgae.Body = body;
                                messgae.EmailFrom = account.Email;
                                messgae.EmailTo = business.Email;
                                messgae.Phone = business.Phone;
                                messgae.Html = htmlMode;
                                messgae.Host = account.SmtpHost;
                                messgae.Password = account.Password;
                                messgae.Port = account.SmtpPort;
                                messgae.Ssl = account.StmpSsl;

                                await ActiveMessengerType(messgae);
                            }
                        }
                    }
                }

                MessageBox.Show("Emails successfully sent...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<bool> ContainsYouTubeChannel(string websiteUrl)
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


        public async Task<string> GetEmailAddress(string websiteUrl)
        {
            string email = "";

            try
            {
                string htmlContent = await ConvertWebsiteToHtml(websiteUrl);

                // Load the HTML document using HtmlAgilityPack
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);

                var anchorNodes = doc.DocumentNode.SelectNodes("//a");

                lstResults.Items.Add($"{anchorNodes.Count} URLs found on website: {websiteUrl}");

                if (anchorNodes != null)
                {
                    for (int i = 0; i <= anchorNodes.Count; i++)
                    {
                        string pageLink = anchorNodes[i].Attributes["href"].Value;
                        string input = await ConvertWebsiteToHtml(pageLink);

                        // Define a regular expression pattern to match valid email addresses
                        string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

                        // Create a regular expression object and match the pattern in the input string
                        Regex regex = new Regex(pattern);
                        MatchCollection matches = regex.Matches(input);

                        // Report on each match.
                        foreach (Match match in matches)
                        {
                            bool validEmail = EmailValidation.EmailValidator.Validate(match.Value) && match.Value.Contains(".com");

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

        public string MessageBuilding(string text, Business bs, Accounts ac)
        {
            string result = text.Replace("[name]", bs.Name).
                Replace("[company]", bs.Company).
                Replace("[profile]", bs.Profile).
                Replace("[website]", bs.Website).
                Replace("[email]", bs.Email).
                Replace("[phone]", bs.Phone).
                Replace("[location]", bs.Location).
                Replace("[pline]", bs.PersonalLine).
                Replace("[user]", ac.UserName).
                Replace("[signature]", ac.Signature);

            return result;
        }

        public async Task SendWhatsappTextMessage(MessageViewModels messageViewModels)
        {
            WhatsAppViewModels whatsAppViewModels = new WhatsAppViewModels();

            whatsAppViewModels.chatId = $"{messageViewModels.Phone}@c.us";
            whatsAppViewModels.message = messageViewModels.Body;

            var result = await WhatsAppApi.SendTextMessage(whatsAppViewModels);

            if (result == true)
            {
                UpdateListing(messageViewModels.EmailTo);
            }
        }

        public void SendEmail(MessageViewModels messageViewModels)
        {
            try
            {
                lstResults.Items.Add("Using: " + messageViewModels.EmailFrom);

                Blocker blocker = new Blocker();

                blocker = appDbContext.Blockers.Where(x => x.Email == messageViewModels.EmailTo).FirstOrDefault();

                if (blocker == null)
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(messageViewModels.Host);

                    mail.From = new MailAddress(messageViewModels.EmailFrom);
                    mail.To.Add(messageViewModels.EmailTo);
                    mail.Subject = messageViewModels.Subject;
                    mail.Body = messageViewModels.Body;
                    mail.IsBodyHtml = messageViewModels.Html;

                    SmtpServer.Port = messageViewModels.Port;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(messageViewModels.EmailFrom, messageViewModels.Password);
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                    lstResults.Items.Add("Email sent to: " + messageViewModels.EmailTo);

                    UpdateListing(messageViewModels.EmailTo);

                    int delayer = Convert.ToInt32(txtDelay.Text);
                    Thread.Sleep(delayer);
                }
                else
                {
                    lstResults.Items.Add("Contact skipped because the email address is added to the blocked list...");
                }
            }
            catch (Exception ex)
            {
                lstResults.Items.Add("Error: " + ex.Message);
            }
        }

        public void UpdateListing(string emailAddress)
        {
            if (ckTestMode.Checked == false)
            {
                var query = appDbContext.Business.Where(x => x.Email == emailAddress).ToList();

                foreach (var item in query)
                {
                    item.Sent = true;
                    appDbContext.SaveChanges();
                }

                lstResults.Items.Add("Message marked as spent...");
            }
        }

        private void templateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Templates templates = new Forms.Templates();

            templates.Show();
        }

        private void blockedEmailAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlockedEmailAddresses blockedEmailAddresses = new BlockedEmailAddresses();

            blockedEmailAddresses.Show();
        }

        private void btnAddAB_Click(object sender, EventArgs e)
        {
            MessageViewModels ms = new MessageViewModels();

            ms.Id = messegeViewModels.Count;
            ms.Subject = txtSubject.Text;
            ms.Body = rtxtBody.Text;
            ms.Html = ckHtmlMode.Checked;

            messegeViewModels.Add(ms);
            cboABTest.Items.Add("Test - " + messegeViewModels.Count().ToString());

            MessageBox.Show($"A/B Test Message - {messegeViewModels.Count()} added...");
        }

        private void btnRemoveAB_Click(object sender, EventArgs e)
        {
            messegeViewModels.Clear();

            MessageBox.Show("A/B Test Messages Removed");
        }

        private void viewAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts_Manager accounts_Manager = new Accounts_Manager();

            accounts_Manager.Show();
        }

        private void addNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_New_Account add_New_Account = new Add_New_Account();

            add_New_Account.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var template = appDbContext.Templates.Where(x => x.Name == cboTemplates.Text).FirstOrDefault();

            txtSubject.Text = template.Subject;
            rtxtBody.Text = template.Body;
            ckHtmlMode.Checked = template.HtmlMode;
        }

        private void btnClearResults_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
        }

        private void ckNoFilter_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtSentContacts_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboABTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboABTest.SelectedIndex;

            var message = messegeViewModels.Where(x => x.Id == index).FirstOrDefault();

            txtSubject.Text = message.Subject;
            rtxtBody.Text = message.Body;
            ckHtmlMode.Checked = message.Html;
        }

        private void cloudServerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cloud_Server_Manager cloud_Server_Manager = new Cloud_Server_Manager();

            cloud_Server_Manager.Show();
        }

        private void generalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Settings settings = new Forms.Settings();
            settings.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetBusinessUpdates();
        }

        private void whatsappAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WhatsApp_API whatsApp_API = new WhatsApp_API();

            whatsApp_API.Show();
        }
    }
}