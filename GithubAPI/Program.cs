using GithubAPI.Model;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace GithubAPI
{
    internal class Program
    {
        // logging variables.
        public static ILoggerFactory Factory;
        private static ILogger _thisLogger;

        private static Dictionary<string, MethodInfo> _commandFunctions = new Dictionary<string, MethodInfo>();

        private static string _tokenArg = "";
        public static GitHubClient API;

        // controls the loop flow.
        private bool _isRunning = false;

        private static User[] _queriedUsers;

        /// <summary>
        /// Instantiates a new <see cref="GitHubClient"/> API access point, using an optional token given at startup.
        /// </summary>
        /// <returns></returns>
        private async Task Initialize()
        {
            API = new GitHubClient(_tokenArg);
            _isRunning = true;

            while (_isRunning)
            {
                string command = Console.ReadLine();
                string[] parameters = command.Contains(' ') ? command.Split(' ') : new[] { command };

                if (!string.IsNullOrEmpty(parameters[0]))
                {
                    if (_commandFunctions.TryGetValue(parameters[0], out MethodInfo function))
                    {
                        if (parameters.Length > 0)
                            function.Invoke(null, parameters[1..]);
                        else
                            function.Invoke(null, null);
                    }
                }
            }
        }

        static async Task Main(string[] args)
        {
            Factory = LoggerFactory.Create(
                builder => builder
                    .AddConsole()
                    .SetMinimumLevel(LogLevel.Debug)
            );
            _thisLogger = Factory.CreateLogger<Program>();

            // argument at index 0 should be the classic token if used.
            if (args.Length == 1) _tokenArg = args[0];
            else if (args.Length > 1)
                _thisLogger.LogWarning("Arguments are greater than expected; cannot access the given API token, using default...");

            if (!string.IsNullOrEmpty(_tokenArg))
                _thisLogger.LogInformation("Using token: {0}", _tokenArg);

            // load commands.
            MethodInfo[] rawCmdFunctions = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(t => t.GetCustomAttribute(typeof(CommandAttribute), false) != null)
                .ToArray();

            for (int i = 0; i < rawCmdFunctions.Length; i++)
            {
                MethodInfo function = rawCmdFunctions[i];
                CommandAttribute commandData = function.GetCustomAttribute(typeof(CommandAttribute), false) as CommandAttribute;

                _commandFunctions.Add(commandData.Name.ToLower(), function);
            }

            _thisLogger.LogInformation("Loaded {0} command functions.", _commandFunctions.Count);

            await new Program().Initialize();
        }

        /// <summary>
        /// Simple http GET request to retrieve the limit infomration for this session.
        /// </summary>
        /// <returns></returns>
        [Command("getapilimit", "Returns the API request limit for this token.")]
        public static async Task Cmd_GetRequestLimit()
        {
            Dictionary<string, IEnumerable<string>> limitInformation = await API.GetAPILimit();

            foreach (var pair in limitInformation)
                Console.WriteLine($"{pair.Key}: {pair.Value.First()}");
            Console.WriteLine();
        }

        [Command("searchuser", "Returns an array of users based on criteria.")]
        public static async Task Cmd_SearchUsers(string query)
        {
            UserSearch uQuery = await API.GetUserSearchQuery(query);

            if (uQuery != null && uQuery.Count > 0)
            {
                _thisLogger.LogInformation($"Search query returned {uQuery.Count} results.");
                _queriedUsers = uQuery.Users;
            }
        }

        [Command("clear", "Clears the console window.")]
        public static void Cmd_ClearConsole()
        {
            Console.Clear();
        }
    }
}
