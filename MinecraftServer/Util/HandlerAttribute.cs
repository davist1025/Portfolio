using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftServer.Network;

namespace MinecraftServer.Util
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HandlerAttribute : Attribute
    {
        public PacketTypes PacketId { get; init; }

        public HandlerAttribute(PacketTypes packetId)
        {
            PacketId = packetId;
        }
    }
}
