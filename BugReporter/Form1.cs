
using MailKit.Net.Smtp;
using MimeKit;
using System.Diagnostics;

namespace BugReporter
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer _timer;
        private SmtpClient _mailClient;

        private string[] _developers = new[] 
        { 
            "davis.tyler1025@gmail.com",
            "portfolioappto@gmail.com"
        };

        // this application requires 2FA w/ an App Password to use (sigh, google. all i want to do is write an application for my portfolio, lol).
        // the Google account of the sending email (textBox_Email) must have 2FA and an App Password.
        private string _myAppPassword = "my app password";

        public Form1()
        {
            InitializeComponent();

            button_Submit.Enabled = false;

            ToolTip impactHintTip = new ToolTip
            {
                ToolTipTitle = "Impact"
            };

            impactHintTip.SetToolTip(label_ImpactHint,
                "Critical - Service is unusable\n" +
                "Severe - Service is fragile and/or error-prone\n" +
                "Moderate - Service is usable with consistent inconvenience (i.e lag, network interruptions)\n" +
                "Mild - Service is fully functional, minor inconvenience that is inconsistent");

            dateTimePicker_Encounter.MaxDate = DateTime.Now;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 250;
            _timer.Tick += OnTimerTick;
            _timer.Start();
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            bool isNameFilled = !string.IsNullOrWhiteSpace(textBox_Name.Text);
            bool isEmailFilled = !string.IsNullOrWhiteSpace(textBox_Email.Text);

            DateOnly date = DateOnly.FromDateTime(dateTimePicker_Encounter.Value);
            int serviceIndex = comboBox_Service.SelectedIndex;
            int impactIndex = comboBox_Impact.SelectedIndex;

            bool isResultFilled = !string.IsNullOrWhiteSpace(richTextBox_Description.Text);
            bool isExpectedFilled = !string.IsNullOrWhiteSpace(richTextBox_Expected.Text);

            if (isNameFilled && isEmailFilled && serviceIndex > -1 && impactIndex > -1 && isResultFilled && isExpectedFilled)
            {
                if (!button_Submit.Enabled)
                    button_Submit.Enabled = true;
            }
            else
            {
                if (!isNameFilled || !isEmailFilled || serviceIndex == -1 || impactIndex == -1 || !isResultFilled || !isExpectedFilled)
                {
                    if (button_Submit.Enabled)
                        button_Submit.Enabled = false;
                }
            }
        }

        private void button_Submit_Click(object sender, EventArgs e)
        {
            string myEmail = textBox_Email.Text.Trim();

            var eMessage = new MimeMessage();
            eMessage.From.Add(new MailboxAddress("PortfolioFrom", myEmail));

            for (int i = 0; i < _developers.Length; i++)
            {
                var toDeveloperEmail = _developers[i];
                eMessage.To.Add(new MailboxAddress(toDeveloperEmail, toDeveloperEmail));
            }

            eMessage.Subject = $"Bug Report - {comboBox_Service.SelectedItem}";

            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody =
                "See the attached bug report below.<br><br>"
                +$"<b>Submitted by: </b> {textBox_Name.Text} - {textBox_Email.Text}<br>"
                +$"<b>Date: </b> {dateTimePicker_Encounter.Value.ToShortDateString()}<br>"
                +$"<b>Service impacted: </b> {comboBox_Service.SelectedItem}<br>"
                +$"<b>Impact level: </b> {comboBox_Impact.SelectedItem}<br><br>"
                +$"<b>Given result: </b> {richTextBox_Description.Text}<br><br>"
                +$"<b>Expected result: </b> {richTextBox_Expected.Text}<br><br>"
                +$"<b>User notes: </b> {richTextBox_Notes.Text}";
            // todo: attach body above as json file.
            eMessage.Body = builder.ToMessageBody();

            using SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate(myEmail, "vgbp eyxi oqhk gxzw");
            client.Send(eMessage);
            client.Disconnect(true);
        }
    }
}
