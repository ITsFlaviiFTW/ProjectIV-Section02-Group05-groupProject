namespace StormSocial_Client
{
    partial class Form2
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
            ContactsPanel = new Panel();
            pictureBox = new PictureBox();
            differentChatButton = new Button();
            Contact4Button = new Button();
            Contact3Button = new Button();
            Contact2Button = new Button();
            Contact1Button = new Button();
            ContactsLabel = new Label();
            CurrentChatName = new Label();
            panel1 = new Panel();
            currentContact = new Label();
            ChatLabel = new Label();
            currentlyLoggedInAs = new Label();
            currentUser = new Label();
            BrowsePhotosButton = new Button();
            vScrollBar1 = new VScrollBar();
            SendButton = new Button();
            MessageTextBox = new TextBox();
            IncomingText = new TextBox();
            OutgoingText = new TextBox();
            ContactsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ContactsPanel
            // 
            ContactsPanel.BackColor = Color.White;
            ContactsPanel.Controls.Add(pictureBox);
            ContactsPanel.Controls.Add(differentChatButton);
            ContactsPanel.Controls.Add(Contact4Button);
            ContactsPanel.Controls.Add(Contact3Button);
            ContactsPanel.Controls.Add(Contact2Button);
            ContactsPanel.Controls.Add(Contact1Button);
            ContactsPanel.Controls.Add(ContactsLabel);
            ContactsPanel.Controls.Add(CurrentChatName);
            ContactsPanel.Location = new Point(12, 12);
            ContactsPanel.Name = "ContactsPanel";
            ContactsPanel.Size = new Size(200, 542);
            ContactsPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(15, 256);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(171, 142);
            pictureBox.TabIndex = 6;
            pictureBox.TabStop = false;
            // 
            // differentChatButton
            // 
            differentChatButton.Location = new Point(29, 497);
            differentChatButton.Name = "differentChatButton";
            differentChatButton.Size = new Size(157, 23);
            differentChatButton.TabIndex = 5;
            differentChatButton.Text = "Chat With Someone Else!";
            differentChatButton.UseVisualStyleBackColor = true;
            differentChatButton.Click += differentChatButton_Click;
            // 
            // Contact4Button
            // 
            Contact4Button.Location = new Point(15, 160);
            Contact4Button.Name = "Contact4Button";
            Contact4Button.Size = new Size(171, 23);
            Contact4Button.TabIndex = 4;
            Contact4Button.UseVisualStyleBackColor = true;
            Contact4Button.Visible = false;
            Contact4Button.Click += Contact4Button_Click;
            // 
            // Contact3Button
            // 
            Contact3Button.Location = new Point(15, 119);
            Contact3Button.Name = "Contact3Button";
            Contact3Button.Size = new Size(171, 23);
            Contact3Button.TabIndex = 3;
            Contact3Button.UseVisualStyleBackColor = true;
            Contact3Button.Visible = false;
            Contact3Button.Click += Contact3Button_Click;
            // 
            // Contact2Button
            // 
            Contact2Button.Location = new Point(15, 79);
            Contact2Button.Name = "Contact2Button";
            Contact2Button.Size = new Size(171, 23);
            Contact2Button.TabIndex = 2;
            Contact2Button.UseVisualStyleBackColor = true;
            Contact2Button.Visible = false;
            Contact2Button.Click += Contact2Button_Click;
            // 
            // Contact1Button
            // 
            Contact1Button.Location = new Point(15, 43);
            Contact1Button.Name = "Contact1Button";
            Contact1Button.Size = new Size(171, 23);
            Contact1Button.TabIndex = 1;
            Contact1Button.UseVisualStyleBackColor = true;
            Contact1Button.Visible = false;
            Contact1Button.Click += Contact1Button_Click;
            // 
            // ContactsLabel
            // 
            ContactsLabel.AutoSize = true;
            ContactsLabel.Location = new Point(73, 15);
            ContactsLabel.Name = "ContactsLabel";
            ContactsLabel.Size = new Size(54, 15);
            ContactsLabel.TabIndex = 0;
            ContactsLabel.Text = "Contacts";
            // 
            // CurrentChatName
            // 
            CurrentChatName.AutoSize = true;
            CurrentChatName.Location = new Point(3, 0);
            CurrentChatName.Name = "CurrentChatName";
            CurrentChatName.Size = new Size(91, 15);
            CurrentChatName.TabIndex = 0;
            CurrentChatName.Text = "Storm Chat v1.0";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(currentContact);
            panel1.Controls.Add(ChatLabel);
            panel1.Controls.Add(currentlyLoggedInAs);
            panel1.Controls.Add(currentUser);
            panel1.Controls.Add(BrowsePhotosButton);
            panel1.Controls.Add(vScrollBar1);
            panel1.Controls.Add(SendButton);
            panel1.Controls.Add(MessageTextBox);
            panel1.Controls.Add(IncomingText);
            panel1.Controls.Add(OutgoingText);
            panel1.Location = new Point(218, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(893, 542);
            panel1.TabIndex = 1;
            // 
            // currentContact
            // 
            currentContact.AutoSize = true;
            currentContact.Location = new Point(96, 15);
            currentContact.Name = "currentContact";
            currentContact.Size = new Size(0, 15);
            currentContact.TabIndex = 9;
            // 
            // ChatLabel
            // 
            ChatLabel.AutoSize = true;
            ChatLabel.Location = new Point(3, 15);
            ChatLabel.Name = "ChatLabel";
            ChatLabel.Size = new Size(87, 15);
            ChatLabel.TabIndex = 7;
            ChatLabel.Text = "Chatting With: ";
            // 
            // currentlyLoggedInAs
            // 
            currentlyLoggedInAs.AutoSize = true;
            currentlyLoggedInAs.Location = new Point(293, 15);
            currentlyLoggedInAs.Name = "currentlyLoggedInAs";
            currentlyLoggedInAs.Size = new Size(134, 15);
            currentlyLoggedInAs.TabIndex = 8;
            currentlyLoggedInAs.Text = "Currently Logged In As: ";
            // 
            // currentUser
            // 
            currentUser.AutoSize = true;
            currentUser.Location = new Point(433, 15);
            currentUser.Name = "currentUser";
            currentUser.Size = new Size(0, 15);
            currentUser.TabIndex = 7;
            // 
            // BrowsePhotosButton
            // 
            BrowsePhotosButton.Location = new Point(754, 497);
            BrowsePhotosButton.Name = "BrowsePhotosButton";
            BrowsePhotosButton.Size = new Size(28, 27);
            BrowsePhotosButton.TabIndex = 6;
            BrowsePhotosButton.Text = "...";
            BrowsePhotosButton.UseVisualStyleBackColor = true;
            BrowsePhotosButton.Click += BrowsePhotosButton_Click;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(868, 43);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(22, 441);
            vScrollBar1.TabIndex = 5;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(791, 499);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 4;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // MessageTextBox
            // 
            MessageTextBox.Location = new Point(3, 499);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(560, 23);
            MessageTextBox.TabIndex = 3;
            // 
            // IncomingText
            // 
            IncomingText.Location = new Point(433, 43);
            IncomingText.Multiline = true;
            IncomingText.Name = "IncomingText";
            IncomingText.Size = new Size(433, 441);
            IncomingText.TabIndex = 2;
            IncomingText.TextAlign = HorizontalAlignment.Right;
            // 
            // OutgoingText
            // 
            OutgoingText.Location = new Point(3, 43);
            OutgoingText.Multiline = true;
            OutgoingText.Name = "OutgoingText";
            OutgoingText.RightToLeft = RightToLeft.No;
            OutgoingText.Size = new Size(424, 441);
            OutgoingText.TabIndex = 1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 566);
            Controls.Add(panel1);
            Controls.Add(ContactsPanel);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ContactsPanel.ResumeLayout(false);
            ContactsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel ContactsPanel;
        private Label ContactsLabel;
        private Button Contact4Button;
        private Button Contact3Button;
        private Button Contact2Button;
        private Button Contact1Button;
        private Panel panel1;
        private VScrollBar vScrollBar1;
        private Button SendButton;
        private TextBox MessageTextBox;
        private TextBox IncomingText;
        private TextBox OutgoingText;
        private Label CurrentChatName;
        private Button BrowsePhotosButton;
        private Button differentChatButton;
        private PictureBox pictureBox;
        private Label currentUser;
        private Label currentlyLoggedInAs;
        private Label currentContact;
        private Label ChatLabel;
    }
}