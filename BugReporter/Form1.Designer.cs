namespace BugReporter
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
            label1 = new Label();
            textBox_Name = new TextBox();
            textBox_Email = new TextBox();
            label2 = new Label();
            label3 = new Label();
            dateTimePicker_Encounter = new DateTimePicker();
            label4 = new Label();
            comboBox_Impact = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            richTextBox_Description = new RichTextBox();
            richTextBox_Expected = new RichTextBox();
            label7 = new Label();
            richTextBox_Notes = new RichTextBox();
            label8 = new Label();
            button_Submit = new Button();
            checkBox_Subscribe = new CheckBox();
            label9 = new Label();
            comboBox_Service = new ComboBox();
            label_ImpactHint = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "First name";
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new Point(12, 45);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(169, 27);
            textBox_Name.TabIndex = 1;
            // 
            // textBox_Email
            // 
            textBox_Email.Location = new Point(278, 45);
            textBox_Email.Name = "textBox_Email";
            textBox_Email.Size = new Size(169, 27);
            textBox_Email.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(278, 22);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 87);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 4;
            label3.Text = "Date Encountered";
            // 
            // dateTimePicker_Encounter
            // 
            dateTimePicker_Encounter.Location = new Point(12, 110);
            dateTimePicker_Encounter.Name = "dateTimePicker_Encounter";
            dateTimePicker_Encounter.Size = new Size(250, 27);
            dateTimePicker_Encounter.TabIndex = 5;
            dateTimePicker_Encounter.Value = new DateTime(2024, 2, 26, 0, 0, 0, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 152);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 6;
            label4.Text = "Impact";
            // 
            // comboBox_Impact
            // 
            comboBox_Impact.FormattingEnabled = true;
            comboBox_Impact.Items.AddRange(new object[] { "Critical", "Severe", "Moderate", "Mild" });
            comboBox_Impact.Location = new Point(12, 175);
            comboBox_Impact.Name = "comboBox_Impact";
            comboBox_Impact.Size = new Size(151, 28);
            comboBox_Impact.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(278, 215);
            label5.Name = "label5";
            label5.Size = new Size(110, 20);
            label5.TabIndex = 8;
            label5.Text = "Expected result";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 215);
            label6.Name = "label6";
            label6.Size = new Size(122, 20);
            label6.TabIndex = 9;
            label6.Text = "What happened?";
            // 
            // richTextBox_Description
            // 
            richTextBox_Description.Location = new Point(12, 238);
            richTextBox_Description.Name = "richTextBox_Description";
            richTextBox_Description.Size = new Size(250, 57);
            richTextBox_Description.TabIndex = 10;
            richTextBox_Description.Text = "";
            // 
            // richTextBox_Expected
            // 
            richTextBox_Expected.Location = new Point(278, 238);
            richTextBox_Expected.Name = "richTextBox_Expected";
            richTextBox_Expected.Size = new Size(250, 57);
            richTextBox_Expected.TabIndex = 11;
            richTextBox_Expected.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 309);
            label7.Name = "label7";
            label7.Size = new Size(48, 20);
            label7.TabIndex = 12;
            label7.Text = "Notes";
            // 
            // richTextBox_Notes
            // 
            richTextBox_Notes.Location = new Point(12, 332);
            richTextBox_Notes.Name = "richTextBox_Notes";
            richTextBox_Notes.Size = new Size(250, 111);
            richTextBox_Notes.TabIndex = 13;
            richTextBox_Notes.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(278, 309);
            label8.Name = "label8";
            label8.Size = new Size(61, 20);
            label8.TabIndex = 16;
            label8.Text = "Options";
            // 
            // button_Submit
            // 
            button_Submit.Location = new Point(410, 414);
            button_Submit.Name = "button_Submit";
            button_Submit.Size = new Size(118, 29);
            button_Submit.TabIndex = 17;
            button_Submit.Text = "Submit";
            button_Submit.UseVisualStyleBackColor = true;
            // 
            // checkBox_Subscribe
            // 
            checkBox_Subscribe.AutoSize = true;
            checkBox_Subscribe.Location = new Point(278, 334);
            checkBox_Subscribe.Name = "checkBox_Subscribe";
            checkBox_Subscribe.Size = new Size(149, 24);
            checkBox_Subscribe.TabIndex = 18;
            checkBox_Subscribe.Text = "Subscribe to issue";
            checkBox_Subscribe.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(278, 87);
            label9.Name = "label9";
            label9.Size = new Size(56, 20);
            label9.TabIndex = 19;
            label9.Text = "Service";
            // 
            // comboBox_Service
            // 
            comboBox_Service.FormattingEnabled = true;
            comboBox_Service.Items.AddRange(new object[] { "Web", "Application", "Network" });
            comboBox_Service.Location = new Point(278, 110);
            comboBox_Service.Name = "comboBox_Service";
            comboBox_Service.Size = new Size(151, 28);
            comboBox_Service.TabIndex = 20;
            // 
            // label_ImpactHint
            // 
            label_ImpactHint.AutoSize = true;
            label_ImpactHint.Location = new Point(61, 152);
            label_ImpactHint.Name = "label_ImpactHint";
            label_ImpactHint.Size = new Size(26, 20);
            label_ImpactHint.TabIndex = 21;
            label_ImpactHint.Text = "(?)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 455);
            Controls.Add(label_ImpactHint);
            Controls.Add(comboBox_Service);
            Controls.Add(label9);
            Controls.Add(checkBox_Subscribe);
            Controls.Add(button_Submit);
            Controls.Add(label8);
            Controls.Add(richTextBox_Notes);
            Controls.Add(label7);
            Controls.Add(richTextBox_Expected);
            Controls.Add(richTextBox_Description);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBox_Impact);
            Controls.Add(label4);
            Controls.Add(dateTimePicker_Encounter);
            Controls.Add(label3);
            Controls.Add(textBox_Email);
            Controls.Add(label2);
            Controls.Add(textBox_Name);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Report App";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_Name;
        private TextBox textBox_Email;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePicker_Encounter;
        private Label label4;
        private ComboBox comboBox_Impact;
        private Label label5;
        private Label label6;
        private RichTextBox richTextBox_Description;
        private RichTextBox richTextBox_Expected;
        private Label label7;
        private RichTextBox richTextBox_Notes;
        private CheckedListBox checkedListBox_Options;
        private Label label8;
        private Button button_Submit;
        private CheckBox checkBox_Subscribe;
        private Label label9;
        private ComboBox comboBox_Service;
        private Label label_ImpactHint;
    }
}
