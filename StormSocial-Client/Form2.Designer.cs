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
            this.ContactsPanel = new System.Windows.Forms.Panel();
            this.differentChatButton = new System.Windows.Forms.Button();
            this.Contact4Button = new System.Windows.Forms.Button();
            this.Contact3Button = new System.Windows.Forms.Button();
            this.Contact2Button = new System.Windows.Forms.Button();
            this.Contact1Button = new System.Windows.Forms.Button();
            this.ContactsLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BrowsePhotosButton = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SendButton = new System.Windows.Forms.Button();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.IncomingText = new System.Windows.Forms.TextBox();
            this.OutgoingText = new System.Windows.Forms.TextBox();
            this.CurrentChatName = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.AddContactButton = new System.Windows.Forms.Button();
            this.ContactsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ContactsPanel
            // 
            this.ContactsPanel.BackColor = System.Drawing.Color.White;
            this.ContactsPanel.Controls.Add(this.pictureBox);
            this.ContactsPanel.Controls.Add(this.differentChatButton);
            this.ContactsPanel.Controls.Add(this.AddContactButton);
            this.ContactsPanel.Controls.Add(this.Contact4Button);
            this.ContactsPanel.Controls.Add(this.Contact3Button);
            this.ContactsPanel.Controls.Add(this.Contact2Button);
            this.ContactsPanel.Controls.Add(this.Contact1Button);
            this.ContactsPanel.Controls.Add(this.ContactsLabel);
            this.ContactsPanel.Location = new System.Drawing.Point(12, 12);
            this.ContactsPanel.Name = "ContactsPanel";
            this.ContactsPanel.Size = new System.Drawing.Size(200, 542);
            this.ContactsPanel.TabIndex = 0;
            // 
            // differentChatButton
            // 
            this.differentChatButton.Location = new System.Drawing.Point(29, 497);
            this.differentChatButton.Name = "differentChatButton";
            this.differentChatButton.Size = new System.Drawing.Size(157, 23);
            this.differentChatButton.TabIndex = 5;
            this.differentChatButton.Text = "Chat With Someone Else!";
            this.differentChatButton.UseVisualStyleBackColor = true;
            this.differentChatButton.Click += new System.EventHandler(this.differentChatButton_Click);
            // 
            // Contact4Button
            // 
            this.Contact4Button.Location = new System.Drawing.Point(15, 160);
            this.Contact4Button.Name = "Contact4Button";
            this.Contact4Button.Size = new System.Drawing.Size(171, 23);
            this.Contact4Button.TabIndex = 4;
            this.Contact4Button.UseVisualStyleBackColor = true;
            this.Contact4Button.Visible = false;
            // 
            // Contact3Button
            // 
            this.Contact3Button.Location = new System.Drawing.Point(15, 119);
            this.Contact3Button.Name = "Contact3Button";
            this.Contact3Button.Size = new System.Drawing.Size(171, 23);
            this.Contact3Button.TabIndex = 3;
            this.Contact3Button.UseVisualStyleBackColor = true;
            this.Contact3Button.Visible = false;
            // 
            // Contact2Button
            // 
            this.Contact2Button.Location = new System.Drawing.Point(15, 79);
            this.Contact2Button.Name = "Contact2Button";
            this.Contact2Button.Size = new System.Drawing.Size(171, 23);
            this.Contact2Button.TabIndex = 2;
            this.Contact2Button.UseVisualStyleBackColor = true;
            this.Contact2Button.Visible = false;
            // 
            // Contact1Button
            // 
            this.Contact1Button.Location = new System.Drawing.Point(15, 43);
            this.Contact1Button.Name = "Contact1Button";
            this.Contact1Button.Size = new System.Drawing.Size(171, 23);
            this.Contact1Button.TabIndex = 1;
            this.Contact1Button.UseVisualStyleBackColor = true;
            this.Contact1Button.Visible = false;
            this.Contact1Button.Click += new System.EventHandler(this.Contact1Button_Click);
            // 
            // ContactsLabel
            // 
            this.ContactsLabel.AutoSize = true;
            this.ContactsLabel.Location = new System.Drawing.Point(73, 15);
            this.ContactsLabel.Name = "ContactsLabel";
            this.ContactsLabel.Size = new System.Drawing.Size(54, 15);
            this.ContactsLabel.TabIndex = 0;
            this.ContactsLabel.Text = "Contacts";
            this.ContactsLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.BrowsePhotosButton);
            this.panel1.Controls.Add(this.vScrollBar1);
            this.panel1.Controls.Add(this.SendButton);
            this.panel1.Controls.Add(this.MessageTextBox);
            this.panel1.Controls.Add(this.IncomingText);
            this.panel1.Controls.Add(this.OutgoingText);
            this.panel1.Controls.Add(this.CurrentChatName);
            this.panel1.Location = new System.Drawing.Point(218, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 542);
            this.panel1.TabIndex = 1;
            // 
            // BrowsePhotosButton
            // 
            this.BrowsePhotosButton.Location = new System.Drawing.Point(754, 497);
            this.BrowsePhotosButton.Name = "BrowsePhotosButton";
            this.BrowsePhotosButton.Size = new System.Drawing.Size(28, 27);
            this.BrowsePhotosButton.TabIndex = 6;
            this.BrowsePhotosButton.Text = "...";
            this.BrowsePhotosButton.UseVisualStyleBackColor = true;
            this.BrowsePhotosButton.Click += new System.EventHandler(this.BrowsePhotosButton_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(868, 43);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(22, 441);
            this.vScrollBar1.TabIndex = 5;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(791, 499);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 4;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(3, 499);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(100, 23);
            this.MessageTextBox.TabIndex = 3;
            this.MessageTextBox.TextChanged += new System.EventHandler(this.MessageTextBox_TextChanged);
            // 
            // IncomingText
            // 
            this.IncomingText.Location = new System.Drawing.Point(433, 43);
            this.IncomingText.Multiline = true;
            this.IncomingText.Name = "IncomingText";
            this.IncomingText.Size = new System.Drawing.Size(433, 441);
            this.IncomingText.TabIndex = 2;
            this.IncomingText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // OutgoingText
            // 
            this.OutgoingText.Location = new System.Drawing.Point(3, 43);
            this.OutgoingText.Multiline = true;
            this.OutgoingText.Name = "OutgoingText";
            this.OutgoingText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OutgoingText.Size = new System.Drawing.Size(424, 441);
            this.OutgoingText.TabIndex = 1;
            // 
            // CurrentChatName
            // 
            this.CurrentChatName.AutoSize = true;
            this.CurrentChatName.Location = new System.Drawing.Point(16, 15);
            this.CurrentChatName.Name = "CurrentChatName";
            this.CurrentChatName.Size = new System.Drawing.Size(91, 15);
            this.CurrentChatName.TabIndex = 0;
            this.CurrentChatName.Text = "Storm Chat v1.0";
            // 
            // pictureBox
            // AddContactButton
            // 
            this.pictureBox.Location = new System.Drawing.Point(15, 256);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(171, 142);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            this.AddContactButton.Location = new System.Drawing.Point(44, 499);
            this.AddContactButton.Name = "AddContactButton";
            this.AddContactButton.Size = new System.Drawing.Size(98, 23);
            this.AddContactButton.TabIndex = 5;
            this.AddContactButton.Text = "Add a contact";
            this.AddContactButton.UseVisualStyleBackColor = true;
            this.AddContactButton.Click += new System.EventHandler(this.AddContactButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 566);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ContactsPanel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ContactsPanel.ResumeLayout(false);
            this.ContactsPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

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
        private Button AddContactButton;
    }
}