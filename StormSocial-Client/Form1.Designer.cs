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
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.SloganPanel = new System.Windows.Forms.Panel();
            this.SloganText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SloganPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.BackgroundImage = global::StormSocial_Client.Properties.Resources.logo;
            this.Logo.Location = new System.Drawing.Point(56, 174);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(560, 86);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // LoginPanel
            // 
            this.LoginPanel.Location = new System.Drawing.Point(680, 190);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(372, 177);
            this.LoginPanel.TabIndex = 1;
            // 
            // SloganPanel
            // 
            this.SloganPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.SloganPanel.Controls.Add(this.SloganText);
            this.SloganPanel.Location = new System.Drawing.Point(35, 144);
            this.SloganPanel.Name = "SloganPanel";
            this.SloganPanel.Size = new System.Drawing.Size(605, 272);
            this.SloganPanel.TabIndex = 2;
            // 
            // SloganText
            // 
            this.SloganText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.SloganText.Location = new System.Drawing.Point(21, 136);
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
            this.Controls.Add(this.LoginPanel);
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
        private Panel LoginPanel;
        private Panel SloganPanel;
        private TextBox SloganText;
    }
}