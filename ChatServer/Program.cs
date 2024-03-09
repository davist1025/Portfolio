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
            NetDataWriter writer = new NetDataWriter();
            bool isUserOnline = false;

            // loop through all connected peers.
            for (int i = 0; i < _manager.ConnectedPeersCount; i++)
            {
                NetPeer connectedPeer = _manager.ConnectedPeerList[i];

                // if the post-auth peer's id does not equal this authenticating peer id.
                if (connectedPeer.Id != peer.Id)
                {
                    ChatUser user = connectedPeer.Tag as ChatUser;
                    if (user.Username.EqualsIgnoreCase(authentication.Username))
                        isUserOnline = true;
                }

                if (isUserOnline)
                    break;
            }

            if (isUserOnline)
            {
                Console.WriteLine($"{peer.Id} is attempting to connect with a username that already exists!");
                _packetProcessor.Write(writer, new ClientAuthenticateStatus() { State = ClientAuthenticateStatus.AuthState.UserAlreadyExists });
            }
            else
            {
                string newSessionId = Guid.NewGuid().ToString().Replace("-", "");
                ChatUser newChatUser = new ChatUser(authentication.Username, newSessionId);
                peer.Tag = newChatUser;
                Console.WriteLine($"{newChatUser.Username} has authenticated w/ session id: {newChatUser.SessionId}");
            }
            peer.Send(writer, DeliveryMethod.ReliableOrdered);
        }

        static void Main(string[] args)
            => new Program();
    }
}
