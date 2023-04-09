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
                Console.WriteLine($"Accepted connection from {clientSocket.RemoteEndPoint} \n");

                // Start a new task to handle the client communication
                _ = Task.Run(() => HandleClientAsync(clientSocket));
            }
        }

        static async Task HandleClientAsync(Socket clientSocket)
        {
            var buffer = new byte[DataPacket.DataPacketTcpSocket.MaxPacketSize];
            StringBuilder imageDataBuilder = new StringBuilder();
            StringBuilder receivedDataBuilder = new StringBuilder(); // Added this line
            string currentDataType = "";
            string currentEmail = "";
            bool isLastPacket = false;

            while (clientSocket.Connected)
            {
                int bytesRead = await clientSocket.ReceiveAsync(buffer, SocketFlags.None);
                if (bytesRead == 0)
                {
                    // Client disconnected
                    Console.WriteLine($"Client {clientSocket.RemoteEndPoint} disconnected");
                    break;
                }

                // Convert the received bytes to a string
                string partialReceivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                receivedDataBuilder.Append(partialReceivedData);

                // Check if the received data contains a complete JSON object
                string receivedData = receivedDataBuilder.ToString();
                if (receivedData.Count(c => c == '{') != receivedData.Count(c => c == '}'))
                {
                    // The received data is not a complete JSON object, wait for more data
                    continue;
                }

                // Clear the receivedDataBuilder for the next packet
                receivedDataBuilder.Clear();

                // Try to deserialize the received data
                try
                {
                    var packet = DataPacket.PacketManipulation.DeserializeDataPacketStruct(receivedData);
                    isLastPacket = packet.isLastPacket;
                    currentDataType = packet.GetDataType();
                    currentEmail = packet.GetEmail();

                    if (currentDataType == "image")
                    {
                        imageDataBuilder.Append(packet.GetPacketData());

                        if (isLastPacket)
                        {
                            DataPacket.PacketManipulation.ProcessDataPacket(packet);
                        }
                    }
                    if (currentDataType == "text/plain")
                    {
                        DataPacket.PacketManipulation.ProcessDataPacket(packet);
                    }
                    if (currentDataType == "profile_data")
                    {
                        File.WriteAllText($"profile_{currentEmail}.txt", packet.GetPacketData());
                    }
                    



                    // Print information for each received packet
                    Console.WriteLine($"Packet Received from {packet.GetSourceAddress()}");
                    Console.WriteLine($"  Email: {packet.GetEmail()}");
                    Console.WriteLine($"  Sequence Number: {packet.GetSequenceNumber()}");
                    Console.WriteLine($"  Timestamp: {packet.GetTimeStamp()}");
                    Console.WriteLine($"  Data Type: {packet.GetDataType()}");
                    Console.WriteLine($"  Data Size: {packet.GetPacketData().Length} bytes\n");
                }
                catch (JsonReaderException ex)
                {
                    // Error deserializing packet
                    Console.WriteLine($"Error deserializing packet: {ex.Message}");
                    continue;
                }
                catch (Exception ex)
                {
                    // Other error occurred
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    break;
                }
            }

            // Clean up the client socket
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
}
