using InstagramApiSharp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapeHero.Api
{
    public class InstagramApi
    {
        private readonly IInstaApi InstaApi;

        public InstagramApi(IInstaApi instaApi)
        {
            InstaApi = instaApi;
        }

        public async Task SendDirectMessage()
        {
            var currentUser = await InstaApi.GetCurrentUserAsync();

            var desireUsername = "rmt4006";
            var user = await InstaApi.UserProcessor.GetUserAsync(desireUsername);
            var userId = user.Value.Pk.ToString();
            var directText = await InstaApi.MessagingProcessor
                .SendDirectTextAsync(userId, null, "Hello Ramtin,\r\nHow are you today?");
        }
    }
}
