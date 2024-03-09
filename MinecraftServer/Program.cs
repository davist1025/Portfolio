using MinecraftServer.Network;
using MinecraftServer.Util;
using SuperSimpleTcp;
using System.Text;

namespace MinecraftServer
{
    internal class Program
    {
        public static int Protocol = 29;

        public Program()
        {
            PacketProcessor.Initialize();
            NetworkManager.Initialize();

            while (true)
            {
            }
        }

        [Handler(PacketTypes.KEEPALIVE)]
        public static void HandleKeepAlive(PacketReader reader, string ipPort)
        {
            int generatedId = reader.ReadInt32();

            using MemoryStream discStr = new();
            using PacketWriter writer = new(discStr);

            writer.Write((byte)PacketTypes.KEEPALIVE);
            writer.Write((int)new Random().Next(90000000));
            NetworkManager.SendTo(ipPort, discStr.ToArray());
        }

        [Handler(PacketTypes.LOGIN)]
        public static void HandleLoginRequest(PacketReader reader, string ipPort)
        {
            int clientProtocolVersion = reader.ReadInt32();
            string connectingUsername = reader.ReadString();

            // can we skip the unused data?

            Console.WriteLine($"{connectingUsername} is requesting to login; protocol = {clientProtocolVersion}");

            if (clientProtocolVersion != Protocol)
            {
                using MemoryStream discStr = new();
                using PacketWriter writer = new(discStr);

                writer.Write((byte)PacketTypes.SMSG_KICK);
                writer.WriteString($"Invalid protocol version; given = {clientProtocolVersion}, expected = {Protocol}");
                NetworkManager.SendTo(ipPort, discStr.ToArray());
                return;
            }

            if (NetworkManager.TryGetUser(connectingUsername, out NetUser user))
            {
                using MemoryStream loginStr = new();
                using PacketWriter writer = new(loginStr);
                user.EntityId = 1; // todo: generate an entity id (use EC/ECS?)

                writer.Write((byte)PacketTypes.LOGIN);
                writer.Write(user.EntityId);
                writer.WriteString(""); // unused?
                writer.WriteString("FLAT");
                writer.Write((int)user.Mode);
                writer.Write((int)user.Dimension);
                writer.Write((int)user.Difficulty);
                writer.Write((sbyte)0); // unused?
                writer.Write((sbyte)4); // max players.
                writer.Flush();

                NetworkManager.SendTo(user.Endpoint.ToString(), loginStr.ToArray());

                using MemoryStream spawnStr = new();
                using PacketWriter spawnWriter = new(spawnStr);

                spawnWriter.Write((byte)PacketTypes.SMSG_SPAWN_POSITION);
                spawnWriter.Write((int)117);
                spawnWriter.Write((int)70);
                spawnWriter.Write((int)-50);
                spawnWriter.Flush();

                NetworkManager.SendTo(user.Endpoint.ToString(), spawnStr.ToArray());
            }
        }

        [Handler(PacketTypes.HANDSHAKE)]
        public static void HandleHandshake(PacketReader reader, string ipPort)
        {
            string[] clientLogin = reader.ReadString().Split(';');
            string username = clientLogin[0];
            // index 1 is necessary if the server is using vhosting.

            // this is untested.
            if (NetworkManager.IsUserOnline(username))
            {
                Console.WriteLine($"User tried to login using an already existing username!");

                using MemoryStream newMemStr = new();
                using PacketWriter writer = new(newMemStr);

                writer.Write((byte)PacketTypes.SMSG_KICK);
                writer.WriteString($"User is already connected ({username})!");
                writer.Flush();

                NetworkManager.SendTo(ipPort, newMemStr.ToArray());
                return;
            }

            NetUser newUser = NetworkManager.CreateUser(ipPort, username);

            using MemoryStream handshakeStr = new MemoryStream();
            using PacketWriter handshakeWriter = new PacketWriter(handshakeStr);
            handshakeWriter.Write((byte)PacketTypes.HANDSHAKE);
            handshakeWriter.WriteString($"-"); // "-" indicates offline-mode.
            handshakeWriter.Flush();

            NetworkManager.SendTo(newUser.Endpoint.ToString(), handshakeStr.ToArray());
        }

        [Handler(PacketTypes.CMSG_SERVERLIST)]
        public static void HandleServerList(PacketReader reader, string ipPort)
        {
            Console.WriteLine("Received server list ping!");
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
