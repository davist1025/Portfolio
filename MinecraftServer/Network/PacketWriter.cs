using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServer.Network
{
    public class PacketWriter : BinaryWriter
    {
        public PacketWriter(Stream stream) : base(stream) { }

        // src: https://github.com/qwaxys/MultiProxyServer/blob/master/MultiProxy/Program.cs#L400
        public void WriteString(string message)
        {
            short len = IPAddress.HostToNetworkOrder((short)message.Length);
            byte[] a = BitConverter.GetBytes(len);
            byte[] b = Encoding.BigEndianUnicode.GetBytes(message);
            Write(a.Concat(b).ToArray());
        }
    }
}
