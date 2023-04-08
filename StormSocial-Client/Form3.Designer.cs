namespace StormSocial_Client
{
    partial class Form3
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
            this.chatLabel = new System.Windows.Forms.Label();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.confirmChatButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatLabel
            // 
            this.chatLabel.AutoSize = true;
            this.chatLabel.Location = new System.Drawing.Point(262, 131);
            this.chatLabel.Name = "chatLabel";
            this.chatLabel.Size = new System.Drawing.Size(106, 15);
            this.chatLabel.TabIndex = 0;
            this.chatLabel.Text = "Start Chatting with";
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(268, 168);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(100, 23);
            this.chatTextBox.TabIndex = 1;
            // 
            // confirmChatButton
            // 
            this.confirmChatButton.Location = new System.Drawing.Point(280, 210);
            this.confirmChatButton.Name = "confirmChatButton";
            this.confirmChatButton.Size = new System.Drawing.Size(75, 23);
            this.confirmChatButton.TabIndex = 2;
            this.confirmChatButton.Text = "Chat!";
            this.confirmChatButton.UseVisualStyleBackColor = true;
            this.confirmChatButton.Click += new System.EventHandler(this.confirmChatButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 382);
            this.Controls.Add(this.confirmChatButton);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.chatLabel);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label chatLabel;
        private TextBox chatTextBox;
        private Button confirmChatButton;
    }
}