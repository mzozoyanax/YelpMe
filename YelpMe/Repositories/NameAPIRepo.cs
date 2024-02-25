using Newtonsoft.Json;
using ScrapeHero.Interfaces;
using ScrapeHero.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapeHero.Repositories
{
    public class NameAPIRepo : INameAPI
    {
        public async Task<EmailValidationResponse> DisposableEmaiAddressDetector(string email, string apiKey)
        {
            try
            {
                var client = new HttpClient();
                var requestUri = $"https://api.nameapi.org/rest/v5.3/email/disposableemailaddressdetector?apiKey={apiKey}&emailAddress={email}";
                var response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    EmailValidationResponse deserializedResponse = JsonConvert.DeserializeObject<EmailValidationResponse>(jsonResponse);

                    return deserializedResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<NameApiViewModels> EmailNameParser(string email, string apiKey)
        {
            try
            {
                var client = new HttpClient();
                var requestUri = $"https://api.nameapi.org/rest/v5.3/email/emailnameparser?apiKey={apiKey}&emailAddress={email}";
                var response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    NameApiViewModels deserializedResponse = JsonConvert.DeserializeObject<NameApiViewModels>(jsonResponse);

                    return deserializedResponse;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex) 
            {
                return null;
            }
        }
    }
}
