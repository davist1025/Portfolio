
using System.Diagnostics;

namespace BugReporter
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer _timer;

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
    }
}
