using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServer.Network
{
    public enum Gamemode : int
    {
        Survival = 0,
        Creative = 1
    }

    public enum Dimension : int
    {
        Nether = -1,
        Overworld = 0,
        End = 1
    }

    public enum Difficulty : byte
    {
        Peaceful = 0,
        Easy = 1,
        Normal = 2,
        Hard = 3
    }

    /// <summary>
    /// Represents a networked player.
    /// 
    /// This object is created after a successful handshaking.
    /// </summary>
    public class NetUser
    {
        public IPEndPoint Endpoint { get; init; }
        public string Username { get; private set; }
        public int EntityId = 0;
        public Gamemode Mode { get; set; } = Gamemode.Survival;
        public Dimension Dimension { get; set; } = Dimension.Overworld;
        public Difficulty Difficulty { get; set; } = Difficulty.Peaceful;

        public NetUser(string endPoint, string username)
        {
            string[] splitEp = endPoint.Split(':');

            try
            {
                Endpoint = new IPEndPoint(IPAddress.Parse(splitEp[0]), Convert.ToInt32(splitEp[1]));
                Username = username;
                Console.WriteLine($"{username} ({Endpoint}) is handshaking...");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Unable to create an IPEndPoint for connecting user: {endPoint}; {ex.Message}");
            }
        }
    }
}
