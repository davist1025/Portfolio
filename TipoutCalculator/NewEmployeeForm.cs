using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipoutCalculator
{
    public partial class NewEmployeeForm : Form
    {
        private ILogger _logger;

        public NewEmployeeForm()
        {
            InitializeComponent();

            using (ILoggerFactory factory = new LoggerFactory())
                _logger = factory.CreateLogger<NewEmployeeForm>();
        }

        /// <summary>
        /// Fired when attempting to type within the hours worked textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnHoursWorkedKeyPress(object sender, KeyPressEventArgs e)
        {
            // credit: https://stackoverflow.com/questions/463299/how-do-i-make-a-textbox-that-only-accepts-numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 mainFrm = Owner as Form1;

            if (mainFrm == null)
            {
                _logger.LogCritical("NewEmployeeForm's Owner property is null.");
                return;
            }


            ListView employeeListview = mainFrm.Controls.Find("listView_Employees", true).First() as ListView;
            if (employeeListview != null)
            {
                string employeeName = textBox_Name.Text;
                string formattedName = char.ToUpper(employeeName[0]) + employeeName.Remove(0, 1).ToLower();

                employeeListview.Items.Add(new ListViewItem(new string[] { formattedName, textBox_NoHoursWorked.Text }));
                textBox_Name.Clear();
                textBox_NoHoursWorked.Clear();

                Close();
            }
        }

        private void OnNameKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
