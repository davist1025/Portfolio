using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class MainWindow : Form
    {
        private string _username;
        private string _sessionId;

        public MainWindow(string username, string sessionId)
        {
            _username = username;
            _sessionId = sessionId;

            InitializeComponent();

            listView_Users.Items.Add(_username);

            this.FormClosing += OnFormClosing;
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
            Form1.NetworkManager.DisconnectAll();
        }
    }
}
