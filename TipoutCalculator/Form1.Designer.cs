namespace TipoutCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox_Tips = new TextBox();
            label2 = new Label();
            listView_Employees = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            button2 = new Button();
            label1 = new Label();
            textBox_hoursOpen = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(201, 206);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 0;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox_Tips
            // 
            textBox_Tips.Location = new Point(12, 210);
            textBox_Tips.Name = "textBox_Tips";
            textBox_Tips.Size = new Size(125, 27);
            textBox_Tips.TabIndex = 2;
            textBox_Tips.KeyPress += OnTotalTipsKeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 187);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 6;
            label2.Text = "Total tips";
            // 
            // listView_Employees
            // 
            listView_Employees.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listView_Employees.Location = new Point(12, 8);
            listView_Employees.Name = "listView_Employees";
            listView_Employees.Size = new Size(314, 121);
            listView_Employees.TabIndex = 9;
            listView_Employees.UseCompatibleStateImageBehavior = false;
            listView_Employees.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Hours Worked";
            columnHeader2.Width = 120;
            // 
            // button2
            // 
            button2.Location = new Point(201, 135);
            button2.Name = "button2";
            button2.Size = new Size(125, 29);
            button2.TabIndex = 10;
            button2.Text = "Add Employee";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 134);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 12;
            label1.Text = "Hours open";
            // 
            // textBox_hoursOpen
            // 
            textBox_hoursOpen.Location = new Point(12, 157);
            textBox_hoursOpen.Name = "textBox_hoursOpen";
            textBox_hoursOpen.Size = new Size(125, 27);
            textBox_hoursOpen.TabIndex = 11;
            textBox_hoursOpen.KeyPress += OnHoursOpenKeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 247);
            Controls.Add(label1);
            Controls.Add(textBox_hoursOpen);
            Controls.Add(button2);
            Controls.Add(listView_Employees);
            Controls.Add(label2);
            Controls.Add(textBox_Tips);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox_Tips;
        private Label label2;
        private ListView listView_Employees;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button button2;
        private Label label1;
        private TextBox textBox_hoursOpen;
    }
}
