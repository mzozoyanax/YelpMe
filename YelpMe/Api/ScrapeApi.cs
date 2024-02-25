using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ScrapeHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using YelpMe.Models;
using YelpMe.ViewModels;

namespace ScrapeHero.Api
{
    public class ScrapeApi
    {
        private AppDbContext appDbContext = new AppDbContext();
        public async void Post(SearchViewModels searchViewModels)
        {
            // The URL of the ASP.NET Web API endpoint you want to send the POST request to
            string apiUrl = appDbContext.Clouds.Where(x => x.Id == searchViewModels.CloudId).FirstOrDefault().Url + "api/SearchApi/";

            try
            {
                // Create an instance of HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Convert the data to a JSON string
                    string jsonContent = JsonConvert.SerializeObject(searchViewModels);

                    // Create a StringContent with the JSON data
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task<List<Business>> Get(Cloud cloud)
        {
            List<Business> businesses = new List<Business>();

            try
            {
                string apiUrl = cloud.Url + "/api/scrape";

                // Create an instance of HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Send the GET request
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and deserialize the response content into a list of Business objects
                        var responseContent = await response.Content.ReadAsStringAsync();

                        businesses = JsonConvert.DeserializeObject<List<Business>>(responseContent);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return businesses;
        }
    }
}
