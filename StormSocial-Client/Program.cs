// Client

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using StormSocial_Client;
using StormSocial_Server.Classes;

namespace SimpleClientServer
{

    class Program
    {
        // Create a TCP/IP socket and connect to the server
        // Create the socket connection
        public static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Dictionary<string, Login> loggedInClients = new Dictionary<string, Login>();

        static async Task Main(string[] args)
        {
            clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, 1234));

            
            //view server program.cs for documentation
            var buffer = new byte[DataPacket.DataPacketTcpSocket.MaxPacketSize];
            int bytesRead = await clientSocket.ReceiveAsync(buffer, SocketFlags.None);
            StringBuilder receivedDataBuilder = new StringBuilder();

            string partialReceivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            receivedDataBuilder.Append(partialReceivedData);

            string receivedData = receivedDataBuilder.ToString();
            bool isLastPacket = false;
            string currentDataType = "";

            receivedDataBuilder.Clear();

            try
            {
                var packet = DataPacket.PacketManipulation.DeserializeDataPacketStruct(receivedData);
                isLastPacket = packet.isLastPacket;
                currentDataType = packet.GetDataType();

                if (currentDataType == "profile_data")
                {
                    File.WriteAllText($"profiles.txt", packet.GetPacketData());
                }
                if(currentDataType == "chat_history")
                {
                    string content = packet.GetPacketData();
                    string[] splitContent = content.Split(':');
                    string fileName = string.Concat(splitContent[0], "-", splitContent[1], "-chats.txt");
                    File.WriteAllText($"{fileName}", packet.GetPacketData());
                }
                if(currentDataType == "contact_file")
                {
                    File.WriteAllText($"{packet.GetEmail()}-contacts.txt", packet.GetPacketData());
                }
            }
            catch
            {

            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}

