namespace ChatClient
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
            button_Connect = new Button();
            label1 = new Label();
            textBox_Username = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel_Status = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button_Connect
            // 
            button_Connect.Location = new Point(106, 171);
            button_Connect.Name = "button_Connect";
            button_Connect.Size = new Size(94, 29);
            button_Connect.TabIndex = 0;
            button_Connect.Text = "Connect";
            button_Connect.UseVisualStyleBackColor = true;
            button_Connect.Click += button_Connect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 76);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // textBox_Username
            // 
            textBox_Username.Location = new Point(65, 99);
            textBox_Username.Name = "textBox_Username";
            textBox_Username.Size = new Size(177, 27);
            textBox_Username.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel_Status });
            statusStrip1.Location = new Point(0, 299);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(306, 26);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Status
            // 
            toolStripStatusLabel_Status.Name = "toolStripStatusLabel_Status";
            toolStripStatusLabel_Status.Size = new Size(54, 20);
            toolStripStatusLabel_Status.Text = "Ready!";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 325);
            Controls.Add(statusStrip1);
            Controls.Add(textBox_Username);
            Controls.Add(label1);
            Controls.Add(button_Connect);
            Name = "Form1";
            Text = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Connect;
        private Label label1;
        private TextBox textBox_Username;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel_Status;
    }
}
