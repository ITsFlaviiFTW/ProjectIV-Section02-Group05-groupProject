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
            this.SystemLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LNLabel = new System.Windows.Forms.Label();
            this.FNLabel = new System.Windows.Forms.Label();
            this.PassText = new System.Windows.Forms.TextBox();
            this.EmailText = new System.Windows.Forms.TextBox();
            this.LNText = new System.Windows.Forms.TextBox();
            this.FNText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordLoginText = new System.Windows.Forms.TextBox();
            this.EmailLoginText = new System.Windows.Forms.TextBox();
            this.PasswordLoginLabel = new System.Windows.Forms.Label();
            this.LoginEmailLabel = new System.Windows.Forms.Label();
            this.SloganText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SloganPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.BackgroundImage = global::StormSocial_Client.Properties.Resources.logo;
            this.Logo.Location = new System.Drawing.Point(305, 64);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(560, 86);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // SloganPanel
            // 
            this.SloganPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.SloganPanel.Controls.Add(this.SystemLabel);
            this.SloganPanel.Controls.Add(this.PassLabel);
            this.SloganPanel.Controls.Add(this.EmailLabel);
            this.SloganPanel.Controls.Add(this.LNLabel);
            this.SloganPanel.Controls.Add(this.FNLabel);
            this.SloganPanel.Controls.Add(this.PassText);
            this.SloganPanel.Controls.Add(this.EmailText);
            this.SloganPanel.Controls.Add(this.LNText);
            this.SloganPanel.Controls.Add(this.FNText);
            this.SloganPanel.Controls.Add(this.button2);
            this.SloganPanel.Controls.Add(this.LoginButton);
            this.SloganPanel.Controls.Add(this.PasswordLoginText);
            this.SloganPanel.Controls.Add(this.EmailLoginText);
            this.SloganPanel.Controls.Add(this.PasswordLoginLabel);
            this.SloganPanel.Controls.Add(this.LoginEmailLabel);
            this.SloganPanel.Controls.Add(this.SloganText);
            this.SloganPanel.Location = new System.Drawing.Point(284, 34);
            this.SloganPanel.Name = "SloganPanel";
            this.SloganPanel.Size = new System.Drawing.Size(605, 472);
            this.SloganPanel.TabIndex = 2;
            this.SloganPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SloganPanel_Paint);
            // 
            // SystemLabel
            // 
            this.SystemLabel.AutoSize = true;
            this.SystemLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.SystemLabel.Location = new System.Drawing.Point(137, 438);
            this.SystemLabel.Name = "SystemLabel";
            this.SystemLabel.Size = new System.Drawing.Size(0, 15);
            this.SystemLabel.TabIndex = 15;
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Location = new System.Drawing.Point(313, 367);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(60, 15);
            this.PassLabel.TabIndex = 14;
            this.PassLabel.Text = "Password:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(334, 326);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(39, 15);
            this.EmailLabel.TabIndex = 13;
            this.EmailLabel.Text = "Email:";
            // 
            // LNLabel
            // 
            this.LNLabel.AutoSize = true;
            this.LNLabel.Location = new System.Drawing.Point(134, 362);
            this.LNLabel.Name = "LNLabel";
            this.LNLabel.Size = new System.Drawing.Size(66, 15);
            this.LNLabel.TabIndex = 12;
            this.LNLabel.Text = "Last Name:";
            // 
            // FNLabel
            // 
            this.FNLabel.AutoSize = true;
            this.FNLabel.Location = new System.Drawing.Point(134, 321);
            this.FNLabel.Name = "FNLabel";
            this.FNLabel.Size = new System.Drawing.Size(67, 15);
            this.FNLabel.TabIndex = 11;
            this.FNLabel.Text = "First Name:";
            // 
            // PassText
            // 
            this.PassText.Location = new System.Drawing.Point(379, 359);
            this.PassText.Name = "PassText";
            this.PassText.Size = new System.Drawing.Size(100, 23);
            this.PassText.TabIndex = 10;
            // 
            // EmailText
            // 
            this.EmailText.Location = new System.Drawing.Point(379, 318);
            this.EmailText.Name = "EmailText";
            this.EmailText.Size = new System.Drawing.Size(100, 23);
            this.EmailText.TabIndex = 9;
            // 
            // LNText
            // 
            this.LNText.Location = new System.Drawing.Point(207, 359);
            this.LNText.Name = "LNText";
            this.LNText.Size = new System.Drawing.Size(100, 23);
            this.LNText.TabIndex = 8;
            // 
            // FNText
            // 
            this.FNText.Location = new System.Drawing.Point(206, 318);
            this.FNText.Name = "FNText";
            this.FNText.Size = new System.Drawing.Size(100, 23);
            this.FNText.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Create Account";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(204, 257);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(104, 23);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordLoginText
            // 
            this.PasswordLoginText.Location = new System.Drawing.Point(206, 228);
            this.PasswordLoginText.Name = "PasswordLoginText";
            this.PasswordLoginText.Size = new System.Drawing.Size(100, 23);
            this.PasswordLoginText.TabIndex = 4;
            // 
            // EmailLoginText
            // 
            this.EmailLoginText.Location = new System.Drawing.Point(206, 190);
            this.EmailLoginText.Name = "EmailLoginText";
            this.EmailLoginText.Size = new System.Drawing.Size(100, 23);
            this.EmailLoginText.TabIndex = 3;
            // 
            // PasswordLoginLabel
            // 
            this.PasswordLoginLabel.AutoSize = true;
            this.PasswordLoginLabel.Location = new System.Drawing.Point(137, 231);
            this.PasswordLoginLabel.Name = "PasswordLoginLabel";
            this.PasswordLoginLabel.Size = new System.Drawing.Size(60, 15);
            this.PasswordLoginLabel.TabIndex = 2;
            this.PasswordLoginLabel.Text = "Password:";
            // 
            // LoginEmailLabel
            // 
            this.LoginEmailLabel.AutoSize = true;
            this.LoginEmailLabel.Location = new System.Drawing.Point(137, 193);
            this.LoginEmailLabel.Name = "LoginEmailLabel";
            this.LoginEmailLabel.Size = new System.Drawing.Size(39, 15);
            this.LoginEmailLabel.TabIndex = 1;
            this.LoginEmailLabel.Text = "Email:";
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
        private TextBox PasswordLoginText;
        private TextBox EmailLoginText;
        private Label PasswordLoginLabel;
        private Label LoginEmailLabel;
        private Label PassLabel;
        private Label EmailLabel;
        private Label LNLabel;
        private Label FNLabel;
        private TextBox PassText;
        private TextBox EmailText;
        private TextBox LNText;
        private TextBox FNText;
        private Label SystemLabel;
    }
}