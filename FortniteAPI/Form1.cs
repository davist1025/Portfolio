namespace FortniteAPI
{
    public partial class Form1 : Form
    {
        private FortniteClient _client;

        public Form1()
        {
            InitializeComponent();

            _client = new FortniteClient();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await _client.GetPlaylists();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await _client.GetShop();
        }
    }
}
