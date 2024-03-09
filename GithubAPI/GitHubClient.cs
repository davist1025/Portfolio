using GithubAPI.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GithubAPI
{
    /// <summary>
    /// Describes the HTTP client for Github and contains functions for getting information.
    /// </summary>
    internal class GitHubClient
    {
        private ILogger _thisLogger;
        private HttpClient _client;

        // setup data; appname, version and token are required (this is for non-authentication)
        private string _appName = "GitHubAPI-PortfolioApp";
        private string _appVersion = "1.0";
        private string _token = "vkvk 10bl";

        public GitHubClient(string token = "")
        {
            _thisLogger = Program.Factory.CreateLogger<GitHubClient>();

            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com")
            };
            _client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(_appName, _appVersion));
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", _token);

            if (!string.IsNullOrEmpty(token))
                _token = token;

            if (!string.IsNullOrEmpty(_token))
                _thisLogger.LogInformation("Token: {0}", _token);
            else
            {
                _thisLogger.LogCritical("A token has not been set, the bot cannot authenticate, closing...");
                Environment.Exit(0);
            }

            if (!_token.StartsWith("ghp_") || _token.Length < 40)
                _thisLogger.LogWarning("The given token: {0} may not be authorized to access some endpoints.", _token);
        }

        /// <summary>
        /// Requests the limit from the API for the authenticated token.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, IEnumerable<string>>> GetAPILimit()
        {
            HttpResponseMessage responseHeaders = await _client.GetAsync(_client.BaseAddress);
            Dictionary<string, uint> limits = new Dictionary<string, uint>();

            return responseHeaders.Headers.Where(h => h.Key.ToLower().Contains("ratelimit")).ToDictionary();
        }

        /// <summary>
        /// Returns a list of users based on the given search query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<UserSearch> GetUsers(string query)
        {
            HttpResponseMessage returnedQuery = await _client.GetAsync($"/search/users?q={query}");
            if (returnedQuery.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _thisLogger.LogError("Failed to search for users with query: {0}, status code returned: {1}", query, returnedQuery.StatusCode);
                return null;
            }

            string queryResponse = await returnedQuery.Content.ReadAsStringAsync();
            UserSearch uQuery = JsonConvert.DeserializeObject<UserSearch>(queryResponse);

            return uQuery;
        }

        /// <summary>
        /// Returns a user based on the given username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<User> GetUser(string username)
        {
            HttpResponseMessage returnedQuery = await _client.GetAsync($"/users/{username}");
            if (returnedQuery.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _thisLogger.LogError("Failed to search for the given user: {0}, status code returned: {1}", username, returnedQuery.StatusCode);
                return null;
            }

            string response = await returnedQuery.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(response);
        }
    }
}
