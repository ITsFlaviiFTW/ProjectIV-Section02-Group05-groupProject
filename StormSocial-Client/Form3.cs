using StormSocial_Server.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StormSocial_Client
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void confirmChatButton_Click(object sender, EventArgs e)
        {
            string existingEmail = chatTextBox.Text;
            Login email = new Login();
            email.setEmail(existingEmail);
            if (email.checkForExistingEmailInFile(existingEmail) == true)
            {
                Form2 form2 = new Form2();
                form2.ContactEmail = existingEmail; // Set the ContactEmail property
                form2.Show();
                this.Hide();
            }
            else
            {
                errorLabel.Text = "Email does not exist. Please try again.";
            }
        }

    }
}
