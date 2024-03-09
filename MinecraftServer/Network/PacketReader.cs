using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServer.Network
{
    public class PacketReader : BinaryReader
    {
        public PacketReader(Stream input) : base(input)
        {
        }

        public override double ReadDouble()
        {
            return BinaryPrimitives.ReadDoubleBigEndian(ReadBytes(8));
        }

        public override short ReadInt16()
        {
            return BinaryPrimitives.ReadInt16BigEndian(ReadBytes(2));
        }

        public override int ReadInt32()
        {
            return BinaryPrimitives.ReadInt32BigEndian(ReadBytes(4));
        }

        public override long ReadInt64()
        {
            return BinaryPrimitives.ReadInt64BigEndian(ReadBytes(8));
        }

        public override float ReadSingle()
        {
            return BinaryPrimitives.ReadSingleBigEndian(ReadBytes(4));
        }

        public override ushort ReadUInt16()
        {
            return BinaryPrimitives.ReadUInt16BigEndian(ReadBytes(2));
        }

        public override uint ReadUInt32()
        {
            return BinaryPrimitives.ReadUInt32BigEndian(ReadBytes(4));
        }

        public override ulong ReadUInt64()
        {
            return BinaryPrimitives.ReadUInt64BigEndian(ReadBytes(8));
        }

        // src: https://github.com/qwaxys/MultiProxyServer/blob/master/MultiProxy/Program.cs#L400
        public override string ReadString()
        {
            byte[] lengthArray = new byte[sizeof(short)];
            Read(lengthArray, 0, sizeof(short));

            short length = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(lengthArray, 0));

            byte[] stringArray = new byte[length * 2];
            Read(stringArray, 0, length * 2);

            return Encoding.BigEndianUnicode.GetString(stringArray);
        }
    }
}
