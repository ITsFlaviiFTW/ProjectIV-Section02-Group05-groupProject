namespace StormSocial_Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Logo = new System.Windows.Forms.PictureBox();
            this.SloganPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernamTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SloganText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SloganPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.BackgroundImage = global::StormSocial_Client.Properties.Resources.logo;
            this.Logo.Location = new System.Drawing.Point(305, 112);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(560, 86);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // SloganPanel
            // 
            this.SloganPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.SloganPanel.Controls.Add(this.button2);
            this.SloganPanel.Controls.Add(this.LoginButton);
            this.SloganPanel.Controls.Add(this.PasswordTextBox);
            this.SloganPanel.Controls.Add(this.UsernamTextBox);
            this.SloganPanel.Controls.Add(this.PasswordLabel);
            this.SloganPanel.Controls.Add(this.UsernameLabel);
            this.SloganPanel.Controls.Add(this.SloganText);
            this.SloganPanel.Location = new System.Drawing.Point(284, 82);
            this.SloganPanel.Name = "SloganPanel";
            this.SloganPanel.Size = new System.Drawing.Size(605, 328);
            this.SloganPanel.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Create Account";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(250, 250);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(104, 23);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(251, 221);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 23);
            this.PasswordTextBox.TabIndex = 4;
            // 
            // UsernamTextBox
            // 
            this.UsernamTextBox.Location = new System.Drawing.Point(251, 183);
            this.UsernamTextBox.Name = "UsernamTextBox";
            this.UsernamTextBox.Size = new System.Drawing.Size(100, 23);
            this.UsernamTextBox.TabIndex = 3;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(182, 224);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(60, 15);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(182, 186);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(63, 15);
            this.UsernameLabel.TabIndex = 1;
            this.UsernameLabel.Text = "Username:";
            // 
            // SloganText
            // 
            this.SloganText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.SloganText.Location = new System.Drawing.Point(109, 136);
            this.SloganText.Name = "SloganText";
            this.SloganText.Size = new System.Drawing.Size(374, 23);
            this.SloganText.TabIndex = 0;
            this.SloganText.Text = "Don\'t weather the storm alone - connect with others on Storm Social.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1123, 566);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.SloganPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.SloganPanel.ResumeLayout(false);
            this.SloganPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox Logo;
        private Panel SloganPanel;
        private TextBox SloganText;
        private Button button2;
        private Button LoginButton;
        private TextBox PasswordTextBox;
        private TextBox UsernamTextBox;
        private Label PasswordLabel;
        private Label UsernameLabel;
    }
}