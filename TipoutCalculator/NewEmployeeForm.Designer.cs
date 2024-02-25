namespace TipoutCalculator
{
    partial class NewEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            textBox_Name = new TextBox();
            label1 = new Label();
            textBox_NoHoursWorked = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 8;
            label2.Text = "Employee Name";
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new Point(12, 32);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(208, 27);
            textBox_Name.TabIndex = 7;
            textBox_Name.KeyPress += OnNameKeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 82);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 10;
            label1.Text = "# of Hours Worked";
            // 
            // textBox_NoHoursWorked
            // 
            textBox_NoHoursWorked.Location = new Point(12, 105);
            textBox_NoHoursWorked.Name = "textBox_NoHoursWorked";
            textBox_NoHoursWorked.Size = new Size(208, 27);
            textBox_NoHoursWorked.TabIndex = 9;
            textBox_NoHoursWorked.KeyPress += OnHoursWorkedKeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(198, 147);
            button1.Name = "button1";
            button1.Size = new Size(147, 29);
            button1.TabIndex = 11;
            button1.Text = "Add Employee";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NewEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 188);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox_NoHoursWorked);
            Controls.Add(label2);
            Controls.Add(textBox_Name);
            Name = "NewEmployeeForm";
            Text = "NewEmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox textBox_Name;
        private Label label1;
        private TextBox textBox_NoHoursWorked;
        private Button button1;
    }
}