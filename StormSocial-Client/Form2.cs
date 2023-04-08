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
using StormSocial_Server.Classes;
using SimpleClientServer;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel.DataAnnotations;

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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string userMessage = MessageTextBox.Text;

            // Send the data packet 
            var packet = new DataPacket.DataPacketStruct(1, "text/plain", userMessage, 0);
            var json = DataPacket.PacketManipulation.SerializeDataPacketStruct(packet);
            var JSONbytes = Encoding.ASCII.GetBytes(json);

            // Send the packet 

            // Send the data packet
            Program.clientSocket.Send(JSONbytes);


            OutgoingText.AppendText(userMessage + Environment.NewLine);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Clean up the socket connection
            Program.clientSocket.Shutdown(SocketShutdown.Both);
            Program.clientSocket.Close();
        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BrowsePhotosButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new instance of the OpenFileDialog
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Set the file filter to only show image files
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

                // Allow the user to select only one file
                openFileDialog.Multiselect = false;

                // Show the dialog and check if the user clicked OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Read the contents of the selected file into a byte array
                    byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);

                    // Convert the byte array to a Base64-encoded string using your EncodeImageToString() method
                    string encodedImageData = DataPacket.PacketManipulation.EncodeImageToString(imageData);

                    // Use the encodedImageData to send a packet 
                    // Create the data packet
                    // Send the data packet
                    var packet = new DataPacket.DataPacketStruct(1, "image", encodedImageData, 0);
                    var json = DataPacket.PacketManipulation.SerializeDataPacketStruct(packet);
                    var JSONbytes = Encoding.ASCII.GetBytes(json);
                    Program.clientSocket.Send(JSONbytes);

                    // Send the data packet
                    Program.clientSocket.Send(JSONbytes);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g. display an error message to the user
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void Contact1Button_Click(object sender, EventArgs e)
        {

        }

        private void differentChatButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.Show();
            this.Hide();
        }
    }
}
