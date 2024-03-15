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
            Console.WriteLine($"{ipPort} sent keepalive: {generatedId}");

            using PacketWriter writer = new(PacketTypes.KEEPALIVE);
            writer.Write((int)new Random().Next(90000000));
            NetworkManager.SendTo(ipPort, writer.ToArray());
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
                using PacketWriter writer = new(PacketTypes.SMSG_KICK);
                writer.WriteString($"Invalid protocol version; given = {clientProtocolVersion}, expected = {Protocol}");
                NetworkManager.SendTo(ipPort, writer.ToArray());
                return;
            }

            if (NetworkManager.TryGetUser(connectingUsername, out NetUser user))
            {
                using PacketWriter writer = new(PacketTypes.LOGIN);
                user.EntityId = 1; // todo: generate an entity id (use EC/ECS?)
                writer.Write(user.EntityId);
                writer.WriteString(""); // unused?
                writer.WriteString("FLAT");
                writer.Write((int)user.Mode);
                writer.Write((int)user.Dimension);
                writer.Write((int)user.Difficulty);
                writer.Write((sbyte)0); // unused?
                writer.Write((sbyte)4); // max players.
                writer.Flush();

                NetworkManager.SendTo(user.Endpoint.ToString(), writer.ToArray());

                using PacketWriter spawnWriter = new(PacketTypes.SMSG_SPAWN_POSITION);
                spawnWriter.Write((int)117);
                spawnWriter.Write((int)70);
                spawnWriter.Write((int)-50);
                spawnWriter.Flush();

                NetworkManager.SendTo(user.Endpoint.ToString(), spawnWriter.ToArray());
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

                using PacketWriter writer = new(PacketTypes.SMSG_KICK);
                writer.WriteString($"User is already connected ({username})!");
                writer.Flush();

                NetworkManager.SendTo(ipPort, writer.ToArray());
                return;
            }

            NetUser newUser = NetworkManager.CreateUser(ipPort, username);

            using PacketWriter handshakeWriter = new PacketWriter(PacketTypes.HANDSHAKE);
            //handshakeWriter.WriteString("ssesionId"); how should this be generated for "online" mode?
            handshakeWriter.WriteString($"-"); // "-" indicates offline-mode.
            handshakeWriter.Flush();

            NetworkManager.SendTo(newUser.Endpoint.ToString(), handshakeWriter.ToArray());
        }

        [Handler(PacketTypes.CMSG_PLAYER_POSITION)]
        public static void HandlePlayerPosition(PacketReader reader, string ipPort)
        {
            double x = reader.ReadDouble();
            double y = reader.ReadDouble();
            double stance = reader.ReadDouble();
            double z = reader.ReadDouble();
            bool isOnGround = reader.ReadBoolean();

            Console.WriteLine($"{x}:{y}:{z}");
        }

        [Handler(PacketTypes.PLAYER_POSITION_LOOK)]
        public static void HandlePlayerPositionAndLook(PacketReader reader, string ipPort)
        {
            double x = reader.ReadDouble();
            double y = reader.ReadDouble();
            double stance = reader.ReadDouble();
            double z = reader.ReadDouble();
            float yaw = reader.ReadSingle();
            float pitch = reader.ReadSingle();
            bool isOnGround = reader.ReadBoolean();

            using var writer = new PacketWriter(PacketTypes.PLAYER_POSITION_LOOK);
            writer.Write(x);
            writer.Write(stance);
            writer.Write(y);
            writer.Write(z);
            writer.Write(yaw);
            writer.Write(pitch);
            writer.Write(isOnGround);
            NetworkManager.SendTo(ipPort, writer.ToArray());
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
