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
            chatLabel = new Label();
            chatTextBox = new TextBox();
            confirmChatButton = new Button();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // chatLabel
            // 
            chatLabel.AutoSize = true;
            chatLabel.Location = new Point(262, 131);
            chatLabel.Name = "chatLabel";
            chatLabel.Size = new Size(106, 15);
            chatLabel.TabIndex = 0;
            chatLabel.Text = "Start Chatting with";
            // 
            // chatTextBox
            // 
            chatTextBox.Location = new Point(268, 168);
            chatTextBox.Name = "chatTextBox";
            chatTextBox.Size = new Size(100, 23);
            chatTextBox.TabIndex = 1;
            // 
            // confirmChatButton
            // 
            confirmChatButton.Location = new Point(280, 210);
            confirmChatButton.Name = "confirmChatButton";
            confirmChatButton.Size = new Size(75, 23);
            confirmChatButton.TabIndex = 2;
            confirmChatButton.Text = "Chat!";
            confirmChatButton.UseVisualStyleBackColor = true;
            confirmChatButton.Click += confirmChatButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Location = new Point(262, 280);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 15);
            errorLabel.TabIndex = 3;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 382);
            Controls.Add(errorLabel);
            Controls.Add(confirmChatButton);
            Controls.Add(chatTextBox);
            Controls.Add(chatLabel);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label chatLabel;
        private TextBox chatTextBox;
        private Button confirmChatButton;
        private Label errorLabel;
    }
}