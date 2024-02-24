namespace TipoutCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double totalPerEmployee = Convert.ToDouble(Convert.ToDouble(textBox_Tips.Text) / Convert.ToInt32(textBox_NoEmployees.Text));
            textBox_Total.Text = $"${totalPerEmployee}";
        }
    }
}
