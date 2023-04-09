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
        Profile profile;
        public string ContactEmail { get; set; }
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

            currentUser.Text = Program.loggedInClients[Program.clientSocket.RemoteEndPoint.ToString()].getEmail();

            profile = new Profile(currentUser.Text);
            System.Windows.Forms.Button[] buttonArray = new System.Windows.Forms.Button[4];
            buttonArray[0] = Contact1Button;
            buttonArray[1] = Contact2Button;
            buttonArray[2] = Contact3Button;
            buttonArray[3] = Contact4Button;

            for (int i = 0; i < buttonArray.Length; i++)
            {
                buttonArray[i].Visible = false;
            }
            if (profile.GetContacts().getContacts().Count > 0)
            {
                for (int i = 0; i < profile.GetContacts().getContacts().Count; i++)
                {
                    buttonArray[i].Text = profile.GetContacts().getContacts()[i];
                    buttonArray[i].Visible = true;
                }
            }

            if (!string.IsNullOrEmpty(ContactEmail))
            {
                //Contact1Button.Visible = true;
                //Contact1Button.Text = ContactEmail;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string userMessage = MessageTextBox.Text;

            // Retrieve the user's email address
            string userEmail = Program.loggedInClients[Program.clientSocket.RemoteEndPoint.ToString()].getEmail();

            // Create the data packet
            var packet = new DataPacket.DataPacketStruct
            {
                email = userEmail,
                sequenceNumber = 1,
                dataType = "text/plain",
                packetData = userMessage,
                checksum = 0
            };

            var json = DataPacket.PacketManipulation.SerializeDataPacketStruct(packet);
            var JSONbytes = Encoding.ASCII.GetBytes(json);

            // Send the packet 
            Program.clientSocket.Send(JSONbytes);

            // Append the email address and message to the OutgoingText TextBox
            OutgoingText.AppendText(userEmail + ": " + userMessage + Environment.NewLine);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Read the profiles.txt file
            string profilesPath = "profiles.txt";
            if (File.Exists(profilesPath))
            {
                string profileData = File.ReadAllText(profilesPath);

                // Create the data packet
                var packet = new DataPacket.DataPacketStruct
                {
                    sequenceNumber = 1,
                    dataType = "profile_data",
                    packetData = profileData,
                    checksum = 0
                };

                // Serialize and send the packet
                var json = DataPacket.PacketManipulation.SerializeDataPacketStruct(packet);
                var JSONbytes = Encoding.ASCII.GetBytes(json);
                Program.clientSocket.Send(JSONbytes);
            }

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
                const int imageChunkSize = DataPacket.DataPacketTcpSocket.MaxPacketSize; // Define the size of the image chunks

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.Multiselect = false;

                // Retrieve the user's email address
                string userEmail = Program.loggedInClients[Program.clientSocket.RemoteEndPoint.ToString()].getEmail();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);
                    string encodedImageData = Convert.ToBase64String(imageData); // Encode the image data as a base64 string

                    int totalChunks = (int)Math.Ceiling((double)encodedImageData.Length / imageChunkSize);
                    for (int i = 0; i < totalChunks; i++)
                    {
                        int startIndex = i * imageChunkSize;
                        int endIndex = Math.Min(startIndex + imageChunkSize, encodedImageData.Length);
                        int currentChunkSize = endIndex - startIndex;
                        string currentChunkData = encodedImageData.Substring(startIndex, currentChunkSize);

                        bool isLastPacket = (i == totalChunks - 1);

                        var packet = new DataPacket.DataPacketStruct
                        {
                            email = userEmail,
                            sequenceNumber = i + 1,
                            dataType = "image",
                            packetData = currentChunkData,
                            isLastPacket = isLastPacket,
                            checksum = 0
                        };

                        var json = DataPacket.PacketManipulation.SerializeDataPacketStruct(packet);
                        var JSONbytes = Encoding.ASCII.GetBytes(json); // Use ASCII to encode the JSON

                        // Add a delay to ensure that the server can process the packets in the correct order
                        Thread.Sleep(10);
                        Program.clientSocket.Send(JSONbytes);
                    }
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }





        private void differentChatButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(currentUser.Text); //send to current user to intialize the proflie on form 3
            form3.Show();
            this.Hide();
        }
        private void Contact1Button_Click(object sender, EventArgs e)
        {
            currentContact.Text = Contact1Button.Text;
        }

        private void Contact2Button_Click(object sender, EventArgs e)
        {
            currentContact.Text = Contact2Button.Text;
        }

        private void Contact3Button_Click(object sender, EventArgs e)
        {
            currentContact.Text = Contact3Button.Text;
        }

        private void Contact4Button_Click(object sender, EventArgs e)
        {
            currentContact.Text = Contact4Button.Text;
        }

        

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.Show();
            this.Hide();
        }
    }
}
