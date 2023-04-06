using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StormSocial_Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Update the scroll position of the text boxes
            OutgoingText.ScrollToCaret();
            OutgoingText.SelectionStart = OutgoingText.GetCharIndexFromPosition(new Point(0, vScrollBar1.Value));
            IncomingText.ScrollToCaret();
            IncomingText.SelectionStart = IncomingText.GetCharIndexFromPosition(new Point(0, vScrollBar1.Value));
        }
    }
}
