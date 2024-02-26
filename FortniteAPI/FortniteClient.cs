using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteAPI
{
    internal class FortniteClient
    {
        private HttpClient _client;

        // setup data; appname, version and token are required (this is for non-authentication)
        private string _appName = "FortniteAPI-PortfolioApp";
        private string _appVersion = "1.0";
        private string _token = "my_token";

        public FortniteClient(string token = "")
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://fortnite-api.com")
            };

            _client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(_appName, _appVersion));


            /// Endpoints requiring an authorization header:
            /// 
            /// v2/stats/br/v2

            //_client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", _token);

            //if (!string.IsNullOrEmpty(token))
            //    _token = token;

            //if (!string.IsNullOrEmpty(_token))
            //    _thisLogger.LogInformation("Token: {0}", _token);
            //else
            //{
            //    _thisLogger.LogCritical("A token has not been set, the bot cannot authenticate, closing...");
            //    Environment.Exit(0);
            //}

            //if (!_token.StartsWith("ghp_") || _token.Length < 40)
            //    _thisLogger.LogWarning("The given token: {0} may not be authorized to access some endpoints.", _token);
        }

        /// <summary>
        /// Returns playlist data for the current patch.
        /// </summary>
        /// <returns></returns>
        public async Task GetPlaylists()
        {
            HttpResponseMessage responseMsg = await _client.GetAsync("/v1/playlists?language=en");
            var data = await responseMsg.Content.ReadAsStringAsync();

            Debug.WriteLine(data);
        }

        /// <summary>
        /// Returns BR shop data for the current patch.
        /// </summary>
        /// <returns></returns>
        public async Task GetShop()
        {
            HttpResponseMessage responseMsg = await _client.GetAsync("/v2/shop/br?language=en");
            var data = await responseMsg.Content.ReadAsStringAsync();

            Debug.WriteLine(data);
        }
    }
}
