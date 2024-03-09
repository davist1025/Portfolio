using MinecraftServer.Util;
using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServer.Network
{
    public static class NetworkManager
    {
        private static SimpleTcpServer _server;

        private static List<NetUser> _onlineUsers;

        public static void Initialize()
        {
            _server = new SimpleTcpServer("127.0.0.1:25565");

            // set events
            _server.Events.ClientConnected += OnClientConnected;
            _server.Events.ClientDisconnected += OnClientDisconnected;
            _server.Events.DataReceived += OnDataReceived;

            _onlineUsers = new List<NetUser>();

            // todo: asynchronous start.
            _server.Start();

            Console.WriteLine($"Started the server on {_server.Port}");
        }

        /// <summary>
        /// Each packet begins with a single-byte ID.
        /// 
        /// Parses the packet id.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnDataReceived(object? sender, DataReceivedEventArgs e)
            => PacketProcessor.Read(e.Data.Array, e.IpPort);

        private static void OnClientDisconnected(object? sender, ConnectionEventArgs e)
        {
        }

        private static void OnClientConnected(object? sender, ConnectionEventArgs e)
        {
        }

        public static void SendTo(string ipPort, byte[] buffer)
        {
            // todo: asynchronous send.
            _server.Send(ipPort, buffer);
            Console.WriteLine($"Sent packet size {buffer.Length} to {ipPort}.");
        }

        public static NetUser CreateUser(string ipPort, string username) 
        {
            NetUser newUser = new NetUser(ipPort, username);
            _onlineUsers.Add(newUser);

            return newUser;
        }

        /// <summary>
        /// Checks if the given user is online.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool IsUserOnline(string username)
        {
            return _onlineUsers.Any(u => u.Username.EqualsIgnoreCase(username));
        }

        public static bool TryGetUser(string username, out NetUser user)
        {
            user = _onlineUsers.Find(u => u.Username.EqualsIgnoreCase(username));
            if (user != null)
                return true;
            return false;
        }
    }
}
