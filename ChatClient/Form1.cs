using ChatShared;
using LiteNetLib;
using LiteNetLib.Utils;
using System.Diagnostics;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        private NetManager _manager;
        private EventBasedNetListener _listener;
        private NetPacketProcessor _packetProcessor;

        public Form1()
        {
            _packetProcessor = new NetPacketProcessor();
            _packetProcessor.SubscribeReusable<ClientSession, NetPeer>(ReadClientSession);

            _listener = new EventBasedNetListener();
            _listener.PeerConnectedEvent += (peer) =>
            {
                toolStripStatusLabel_Status.Text = "Authenticating...";

                string username = textBox_Username.Text;

                NetDataWriter writer = new NetDataWriter();
                _packetProcessor.Write(writer, new ClientAuthentication() { Username = username });
                peer.Send(writer, DeliveryMethod.ReliableOrdered);
            };
            _listener.NetworkReceiveEvent += (peer, reader, channel, method) => _packetProcessor.ReadAllPackets(reader, peer);

            _manager = new NetManager(_listener);
            _manager.Start();

            Task.Run(() =>
            {
                while (true)
                    _manager.PollEvents();
            });

            InitializeComponent();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel_Status.Text = "Connecting...";
            _manager.Connect("127.0.0.1", 27737, "");
        }

        private void ReadClientSession(ClientSession session, NetPeer peer)
        {
            toolStripStatusLabel_Status.Text = "Starting...";

            this.Invoke(new Action(() => {
                this.Hide();
                new MainWindow(textBox_Username.Text, session.SessionId).Show();
            }));
        }
    }
}
