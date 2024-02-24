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
            textBox_NoEmployees = new TextBox();
            textBox_Tips = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox_Total = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 206);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 0;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox_NoEmployees
            // 
            textBox_NoEmployees.Location = new Point(12, 32);
            textBox_NoEmployees.Name = "textBox_NoEmployees";
            textBox_NoEmployees.Size = new Size(125, 27);
            textBox_NoEmployees.TabIndex = 1;
            // 
            // textBox_Tips
            // 
            textBox_Tips.Location = new Point(12, 96);
            textBox_Tips.Name = "textBox_Tips";
            textBox_Tips.Size = new Size(125, 27);
            textBox_Tips.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 5;
            label1.Text = "# of Employees";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 6;
            label2.Text = "Tips (all day)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(177, 184);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 7;
            label3.Text = "Total/employee";
            // 
            // textBox_Total
            // 
            textBox_Total.Location = new Point(177, 207);
            textBox_Total.Name = "textBox_Total";
            textBox_Total.ReadOnly = true;
            textBox_Total.Size = new Size(149, 27);
            textBox_Total.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 247);
            Controls.Add(textBox_Total);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_Tips);
            Controls.Add(textBox_NoEmployees);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox_NoEmployees;
        private TextBox textBox_Tips;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox_Total;
    }
}
