namespace GithubAPI
{
    internal class Program
    {
        private HttpClient _client;

        private string _appName = "GitHubAPI-PortfolioApp";
        private string _appVersion = "1.0";
        private string _token = "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";

        private Uri _baseUri = new Uri("https://api.github.com");

        private bool _isRunning = false;

        public Program()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.github.com");
            _client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(_appName, _appVersion));
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", _token);

            _isRunning = true;

            Initialize();
            // Look into executing get's synchronously. we don't need to update any UI elements or run anything in paralell.
            // API/general commands can be executed synchronously and can block the main thread.
        }

        private void Initialize()
        {
            Console.WriteLine("Gathering token data...");
            Console.WriteLine();

            // how can this be standardized into a function?
            var getResponseMessage = _client.GetAsync(_baseUri);
            getResponseMessage.Wait();

            var responseMsg = getResponseMessage.Result;

            Console.WriteLine(responseMsg.Headers.FirstOrDefault(h => h.Key.Equals("X-RateLimit-Limit")).Value.ToArray()[0]);
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
