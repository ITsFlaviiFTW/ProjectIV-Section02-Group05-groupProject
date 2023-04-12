using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StormSocial_Server.Classes;

namespace SimpleClientServer
{
    class Program
    {
        private static Dictionary<string, string> emailToSocketAddressMap = new Dictionary<string, string>();

        [STAThread]
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
            string profileFile = "profile.txt";
            if(File.Exists(profileFile))
            {
                string profileData = File.ReadAllText(profileFile);

                var packet = new DataPacket.DataPacketStruct
                {
                    sequenceNumber = 1, 
                    dataType = "profile_data",
                    packetData = profileData,
                    checksum = 0
                };
                var json = DataPacket.PacketManipulation.SerializeDataPacketStruct(packet);
                var JSONbytes = Encoding.ASCII.GetBytes(json);
                clientSocket.Send(JSONbytes);
            }
           
            var buffer = new byte[DataPacket.DataPacketTcpSocket.MaxPacketSize];
            StringBuilder imageDataBuilder = new StringBuilder();
            StringBuilder receivedDataBuilder = new StringBuilder(); // Added this line0
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
                        File.WriteAllText($"profile{currentEmail}.txt", packet.GetPacketData());
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



                    // Print information for each received packet
                    Console.WriteLine($"Packet Received from {packet.GetSourceAddress()}");
                    Console.WriteLine($"  Email: {packet.GetEmail()}");
                    Console.WriteLine($"  Sequence Number: {packet.GetSequenceNumber()}");
                    Console.WriteLine($"  Timestamp: {packet.GetTimeStamp()}");
                    Console.WriteLine($"  Data Type: {packet.GetDataType()}");
                    Console.WriteLine($"  Data Size: {packet.GetPacketData().Length} bytes");
                    Console.WriteLine($"  Email: {packet.GetEmail()}\n");
                    bool firstMessage = true;
                    if (firstMessage)
                    {
                        List<string> contacts = new List<string>();
                        string contactsFile = string.Concat(packet.GetEmail(), "-contacts.txt");
                        if(File.Exists(contactsFile))
                        {
                            
                            using(StreamReader sr = new StreamReader(contactsFile))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    contacts.Add(line);
                                }
                            }
                            
                        }
                        for(int i = 0; i < contacts.Count; i++)
                        {
                            string fileName = string.Concat(packet.GetEmail(), "-", contacts[i], "-chats.txt");
                            if (File.Exists(fileName))
                            {
                                string data = File.ReadAllText(fileName);

                                // Create the data packet
                                var newPacket = new DataPacket.DataPacketStruct
                                {
                                    sequenceNumber = 1,
                                    dataType = "chat_history",
                                    packetData = data,
                                    email = packet.GetEmail(),
                                    checksum = 0
                                };

                                // Serialize and send the packet
                                var json = DataPacket.PacketManipulation.SerializeDataPacketStruct(packet);
                                var JSONbytes = Encoding.ASCII.GetBytes(json);
                                clientSocket.Send(JSONbytes);
                            }
                        }

                        firstMessage = false;
                        string contactsData = File.ReadAllText(contactsFile);
                        var Newpacket = new DataPacket.DataPacketStruct
                        {
                            sequenceNumber = 1,
                            dataType = "contact_file",
                            packetData = contactsData,
                            email = packet.GetEmail(),
                            checksum = 0
                        };
                        var json2 = DataPacket.PacketManipulation.SerializeDataPacketStruct(Newpacket);
                        var JSONbytes2 = Encoding.ASCII.GetBytes(json2);
                        clientSocket.Send(JSONbytes2);
                    }
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
