using Newtonsoft.Json;
using ScrapeHero.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpMe.Models;
using YelpMe.ViewModels;

namespace ScrapeHero.Api
{
    public class WhatsAppApi
    {
        private AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> SendTextMessage(WhatsAppViewModels whatsAppViewModels)
        { 
            try
            {
                var query = appDbContext.WhatsAppIntergations.FirstOrDefault();

                string instanceId = query.InstanceId;
                string apiTokenInstance = query.ApiTokenInstance;

                // The URL of the ASP.NET Web API endpoint you want to send the POST request to
                string apiUrl = $"https://api.green-api.com/waInstance{instanceId}/sendMessage/{apiTokenInstance}";

                // Create an instance of HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Convert the data to a JSON string
                    string jsonContent = JsonConvert.SerializeObject(whatsAppViewModels);

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
                return false;
            }

            return true;
        }
    }
}
