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
            //Create new contact here

            Form2 Form2 = new Form2();
            Form2.Show();
            this.Hide();
        }
    }
}
