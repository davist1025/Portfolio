using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MinecraftServer.Util;

namespace MinecraftServer.Network
{
    public enum PacketTypes : byte
    {
        KEEPALIVE = 0x00,
        LOGIN = 0x01,
        HANDSHAKE = 0x02,
        PLAYER_POSITION_LOOK = 0x0D,

        CMSG_PLAYER_POSITION = 0x0B,
        CMSG_SERVERLIST = 0xFE,

        SMSG_SPAWN_POSITION = 0x06,
        SMSG_KICK = 0xFF
    }

    public class PacketProcessor
    {
        private static Dictionary<PacketTypes, MethodInfo> _handlers = new Dictionary<PacketTypes, MethodInfo>();

        /// <summary>
        /// Registers all known packet handlers.
        /// </summary>
        public static void Initialize()
        {
            var handlerFunctions = Assembly.GetExecutingAssembly()
                .GetTypes()
                .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public))
                .Where(m => m.GetCustomAttributes(typeof(HandlerAttribute), false).Length == 1)
                .ToArray();

            for (int i = 0; i < handlerFunctions.Length; i++)
            {
                MethodInfo function = handlerFunctions[i];
                HandlerAttribute handler = function.GetCustomAttribute<HandlerAttribute>();

                if (!_handlers.TryAdd(handler.PacketId, function))
                    Console.WriteLine("Failed to add packet handler.");
            }

            if (_handlers.Count > 0)
                Console.WriteLine($"Loaded {_handlers.Count} packet handling functions.");
        }

        /// <summary>
        /// Reads an incoming data stream.
        /// </summary>
        /// <param name="buffer"></param>
        public static void Read(byte[] buffer, string ipPort)
        {
            using var memStr = new MemoryStream(buffer);
            using var binReader = new PacketReader(memStr);

            byte packetId = binReader.ReadByte();
            Console.WriteLine($"Scanning packet id: 0x{packetId.ToString("X2")}");

            if (TryGetHandler((PacketTypes)packetId, out MethodInfo handler))
            {
                handler.Invoke(null,
                        new object[] { binReader, ipPort });
            }
            else
            {
                Console.WriteLine($"Unknown packet received: 0x{packetId.ToString("X2")}");
                // should a disc. packet be sent here?
            }
        }

        /// <summary>
        /// Attempts to retrieve the handler for a given packet id.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool TryGetHandler(PacketTypes type, out MethodInfo handler)
        {
            handler = null;
            if (_handlers.TryGetValue(type, out MethodInfo thisHandler))
                handler = thisHandler;

            if (handler != null)
                return true;

            return false;
        }
    }
}
