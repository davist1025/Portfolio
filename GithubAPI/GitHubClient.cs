using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        private string _token = "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";

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
    }
}
