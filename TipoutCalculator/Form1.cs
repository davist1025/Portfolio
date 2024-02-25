namespace TipoutCalculator
{
    public partial class Form1 : Form
    {
        private NewEmployeeForm _newEmployeeChild;

        public Form1()
        {
            InitializeComponent();

            _newEmployeeChild = new NewEmployeeForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string calculation = "Total Calculations" +
                "\n====================\n";

            double totalTipsPerEmployeeOverall = Convert.ToDouble(Convert.ToDouble(textBox_Tips.Text) / listView_Employees.Items.Count);
            calculation += $"Total tips for each employee: ${totalTipsPerEmployeeOverall}\n";
            calculation += '\n';
            calculation += "Tips based on hours worked:\n";

            for (int i = 0; i < listView_Employees.Items.Count; i++)
            {
                var name = listView_Employees.Items[i].Text;
                var hrs = listView_Employees.Items[i].SubItems[1].Text;

                var hoursWorkedPercent = Convert.ToDouble(textBox_Tips.Text) / Convert.ToDouble(textBox_hoursOpen.Text);
                var tipsForHoursWorked = Convert.ToDouble(hrs) * hoursWorkedPercent;

                calculation += $"{name}: ${double.Round(tipsForHoursWorked, 2)}\n";
            }

            MessageBox.Show(calculation);

            //double totalPerEmployee = Convert.ToDouble(Convert.ToDouble(textBox_Tips.Text) / Convert.ToInt32(textBox_NoEmployees.Text));
            //textBox_Total.Text = $"${totalPerEmployee}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _newEmployeeChild.ShowDialog(this);
        }

        private void OnHoursOpenKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void OnTotalTipsKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && textBox_Tips.Text.IndexOf(e.KeyChar) > 1)
            {
                e.Handled = true;
            }
        }
    }
}
