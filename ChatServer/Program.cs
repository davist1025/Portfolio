using ChatShared;
using LiteNetLib;
using LiteNetLib.Utils;

namespace ChatServer
{
    /// <summary>
    /// Implements a simple chat server using LiteNetLib as the networking backend.
    /// </summary>
    internal class Program
    {
        private NetManager _manager;
        private EventBasedNetListener _listener;
        private NetPacketProcessor _packetProcessor;

        private bool _isRunning = false;

        public Program()
        {
            _listener = new EventBasedNetListener();
            _manager = new NetManager(_listener);
            _packetProcessor = new NetPacketProcessor();
            _packetProcessor.SubscribeReusable<ClientAuthentication, NetPeer>(ReadClientAuthentication);
            _manager.Start(27737);

            _listener.ConnectionRequestEvent += (req) => req.Accept();
            _listener.PeerConnectedEvent += (peer) => Console.WriteLine($"{peer.Id} has connected.");
            _listener.PeerDisconnectedEvent += (peer, reason) => Console.WriteLine($"{peer.Id} has disconnected; {reason.Reason}");
            _listener.NetworkReceiveEvent += (peer, reader, channel, method) => _packetProcessor.ReadAllPackets(reader, peer);

            _isRunning = true;

            while (_isRunning)
            {
                _manager.PollEvents();
            }
        }

        private void ReadClientAuthentication(ClientAuthentication authentication, NetPeer peer)
        {
            Console.WriteLine($"{authentication.Username} is attempting authenticate (peer: {peer.Id})");

            // todo: check connected users for username.
            NetDataWriter writer = new NetDataWriter();
            _packetProcessor.Write(writer, new ClientSession() { SessionId = Guid.NewGuid().ToString().Replace("-", "") });
            peer.Send(writer, DeliveryMethod.ReliableOrdered);
        }

        static void Main(string[] args)
            => new Program();
    }
}
