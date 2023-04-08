using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StormSocial_Server.Classes;

namespace SimpleClientServer
{
    class Program
    {
        private static Dictionary<string, string> emailToSocketAddressMap = new Dictionary<string, string>();

        static async Task Main(string[] args)
        {
            // Create the server socket
            var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 1234));
            serverSocket.Listen(5);

            Console.WriteLine("Server started on port 1234");

            while (true)
            {
                // Accept incoming client connections
                var clientSocket = await serverSocket.AcceptAsync();
                Console.WriteLine($"Accepted connection from {clientSocket.RemoteEndPoint}");

                // Start a new task to handle the client communication
                _ = Task.Run(() => HandleClientAsync(clientSocket));
            }
        }

        static async Task HandleClientAsync(Socket clientSocket)
        {
            var stateMachine = new StateMachine();
            var buffer = new byte[10000000];

            // Receive and process data from the client in a loop
            while (clientSocket.Connected)
            {
                var receivedData = "";
                var bytesRead = await clientSocket.ReceiveAsync(buffer, SocketFlags.None);
                if (bytesRead == 0)
                {
                    // Client disconnected
                    Console.WriteLine($"Client {clientSocket.RemoteEndPoint} disconnected");
                    break;
                }

                // Convert the received bytes to a string and concatenate it with the previously received data
                receivedData += Encoding.ASCII.GetString(buffer, 0, bytesRead);

                
                // Extract the complete message and process it
                try
                {
                    var packet = DataPacket.PacketManipulation.DeserializeDataPacketStruct(receivedData);
                    DataPacket.PacketManipulation.ProcessDataPacket(packet);
                    Console.WriteLine("Message Received from " + packet.GetSourceAddress() + ": " + packet.GetPacketData());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while processing the message: {ex.Message}");
                }
                // Deserialize the received data packet
                var packet = DataPacket.PacketManipulation.DeserializeDataPacketStruct(Encoding.ASCII.GetString(buffer));
                DataPacket.PacketManipulation.ProcessDataPacket(packet);

                Console.WriteLine("Message Received from " + packet.GetSourceAddress() + ": " + packet.GetPacketData());

                // Update the email-to-socket address map after successful authentication
                // Replace "email" with the actual email field in the packet
                string email = packet.GetEmail();
                if (!string.IsNullOrEmpty(email))
                {
                    emailToSocketAddressMap[email] = clientSocket.RemoteEndPoint.ToString();
                }
            }

            // Clean up the client socket
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }


       
    }
}
