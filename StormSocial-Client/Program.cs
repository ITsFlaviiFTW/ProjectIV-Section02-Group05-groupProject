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
        

        static void Main(string[] args)
        {
            clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, 1234));


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            
            /*
            // Send the JSON data packet to the server
            var bytes = Encoding.ASCII.GetBytes(json);
            clientSocket.Send(bytes);

            // Receive the response from the server and deserialize it
            var buffer = new byte[1024];
            var bytesRead = clientSocket.Receive(buffer);
            var responseJson = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            var responsePacket = DataPacket.PacketManipulation.DeserializeDataPacketStruct(responseJson);

            // Display the response packet's data
            Console.WriteLine($"Received response packet from {responsePacket.GetSourceAddress()} with data: {responsePacket.GetPacketData()}");

            // Clean up the client socket
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            */
        }
    }
}
