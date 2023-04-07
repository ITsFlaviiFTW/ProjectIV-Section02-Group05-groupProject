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

            // Create the data packet
            var packet = new DataPacket.DataPacketStruct(1, "text/plain", userMessage, 0);
            var json = DataPacket.PacketManipulation.SerializeDataPacketStruct(packet);
            var JSONbytes = Encoding.ASCII.GetBytes(json);

            // Send the data packet
            Program.clientSocket.Send(JSONbytes);

            // Receive the response from the server and deserialize it
            var buffer = new byte[1024];
            var bytesRead = Program.clientSocket.Receive(buffer);
            var responseJson = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            var responsePacket = DataPacket.PacketManipulation.DeserializeDataPacketStruct(responseJson);

            // Display the response packet's data
            Console.WriteLine($"Received response packet from {responsePacket.GetSourceAddress()} with data: {responsePacket.GetPacketData()}");
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
    }
}
