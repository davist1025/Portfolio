namespace ChatClient
{
    partial class MainWindow
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
            listView_Users = new ListView();
            textBox_Input = new TextBox();
            richTextBox_Output = new RichTextBox();
            SuspendLayout();
            // 
            // listView_Users
            // 
            listView_Users.Location = new Point(445, 24);
            listView_Users.Name = "listView_Users";
            listView_Users.Size = new Size(151, 315);
            listView_Users.TabIndex = 0;
            listView_Users.UseCompatibleStateImageBehavior = false;
            // 
            // textBox_Input
            // 
            textBox_Input.Location = new Point(2, 312);
            textBox_Input.Name = "textBox_Input";
            textBox_Input.Size = new Size(437, 27);
            textBox_Input.TabIndex = 1;
            // 
            // richTextBox_Output
            // 
            richTextBox_Output.Location = new Point(2, 24);
            richTextBox_Output.Name = "richTextBox_Output";
            richTextBox_Output.Size = new Size(437, 282);
            richTextBox_Output.TabIndex = 2;
            richTextBox_Output.Text = "";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 357);
            Controls.Add(richTextBox_Output);
            Controls.Add(textBox_Input);
            Controls.Add(listView_Users);
            Name = "MainWindow";
            Text = "MainWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView_Users;
        private TextBox textBox_Input;
        private RichTextBox richTextBox_Output;
    }
}