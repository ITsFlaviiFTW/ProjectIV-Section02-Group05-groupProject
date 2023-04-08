using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using Force.Crc32;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Net.Sockets;

namespace StormSocial_Server.Classes
{
    public class DataPacket // Class for structure of 
    {
        public class DataPacketStruct
        {
            public string sourceAddress; // Source address 
            public int sequenceNumber; // Sequence number
            public string timeStamp; // Timestamp
            public string dataType; // Type of data
            public string packetData; // Actual packet data
            public uint checksum; // Checksum
            public int totalPackets; // Total number of packets
            public int packetIndex; // Packet index


            // Constructor to initialize the packet 
            public DataPacketStruct()
            {
                this.sourceAddress = Dns.GetHostAddresses(Dns.GetHostName())?.ToString() ?? "Unknown"; // Get Source Address
                this.sequenceNumber = 0;
                this.timeStamp = DateTime.Now.ToString();
                this.dataType = "text/plain";
                this.packetData = "defaultString";
                this.checksum = CalculateChecksum();
            }

            // Constructor to initialize the packet with parameters
            public DataPacketStruct(int sequenceNumber, string dataType, string data, uint checksum)
            {
                this.sourceAddress = Dns.GetHostAddresses(Dns.GetHostName())?.ToString() ?? "Unknown"; // Get Source Address
                this.sequenceNumber = sequenceNumber;
                this.timeStamp = DateTime.Now.ToString();
                this.dataType = dataType;
                this.packetData = data;
                this.checksum = checksum;
            }

            // Calculate the packet checksum using the CRC32 algorithm
            public uint CalculateChecksum()
            {
                using (var crc32 = new Crc32Algorithm())
                {
                    var sourceData = $"{sourceAddress},{sequenceNumber},{timeStamp},{dataType},{packetData}";
                    byte[] data = Encoding.ASCII.GetBytes(sourceData);
                    byte[] hash = crc32.ComputeHash(data);
                    return BitConverter.ToUInt32(hash, 0);
                }
            }

            // Getter methods for the public fields
            public string GetSourceAddress()
            {
                return sourceAddress;
            }

            public int GetSequenceNumber()
            {
                return sequenceNumber;
            }

            public string GetTimeStamp()
            {
                return timeStamp;
            }

            public string GetDataType()
            {
                return dataType;
            }

            public string GetPacketData()
            {
                return packetData;
            }

            public uint GetChecksum()
            {
                return checksum;
            }
        }

        public class PacketManipulation
        {
            // Function to log the data packet information to a text file
            public void LogDataPacketInfo(DataPacketStruct packet, string filename)
            {
                using (StreamWriter outputFile = new StreamWriter(filename, true))
                {
                    // Write packet info in a structured format
                    outputFile.WriteLine("Source address: " + packet.sourceAddress);
                    outputFile.WriteLine("Sequence number: " + packet.sequenceNumber);
                    outputFile.WriteLine("Timestamp: " + packet.timeStamp);
                    outputFile.WriteLine("Data type: " + packet.dataType);
                    outputFile.WriteLine("Data: " + packet.packetData);
                }
            }

            // Function to serialize a data packet
            public static string SerializeDataPacketStruct(DataPacketStruct packet)
            {
                return JsonConvert.SerializeObject(packet);
            }

            // Function to deserialize a data packet
            public static DataPacketStruct DeserializeDataPacketStruct(string json)
            {
                return JsonConvert.DeserializeObject<DataPacketStruct>(json);
            }


            // Convert images to string (for packet data)
            public static string EncodeImageToString(byte[] imageData)
            {
                // Convert byte array to Base64 string
                string base64String = Convert.ToBase64String(imageData);
                return base64String;
            }

            // Convert images from string back to byte array  
            public static void DecodeAndWriteImageToFile(string base64StringImage, string outputPath)
            {
                // Convert Base64 string to byte array
                byte[] imageData = Convert.FromBase64String(base64StringImage);

                // Write the image byte array to a file
                File.WriteAllBytes(outputPath, imageData);
            }

            // Convert 
            public static void ProcessDataPacket(DataPacketStruct receivedPacket)
            {
                if (receivedPacket.dataType == "image") // Decode and write package image to local path 
                {
                    string imagePath = GetUniqueImagePath(); // Get unique image path for received photo
                    string encodedPacketImage = receivedPacket.packetData; // Get encoded image from packet 

                    DecodeAndWriteImageToFile(encodedPacketImage, imagePath); // Decode received image and write to file
                }
                if (receivedPacket.dataType == "text/plain")
                {
                    // Process text
                    string textPath = GetUniqueLogPath();
                    PacketManipulation textLogger = new PacketManipulation();
                    textLogger.LogDataPacketInfo(receivedPacket, textPath);
                }
            }

            // Function to generate a unique image path (based on date/time)
            public static string GetUniqueImagePath()
            {
                string fileName = "Packet Log - " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                string imagePath = Path.Combine(Environment.CurrentDirectory, fileName);
                return imagePath;
            }
            // Function to generate a unique log path (based on date/time)
            public static string GetUniqueLogPath()
            {
                string fileName = "Packet Log - " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt";
                string logPath = Path.Combine(Environment.CurrentDirectory, fileName);
                return logPath;
            }
        }

        // Class contains networking-related packet functions 
        public class DataPacketTcpSocket
        {
            private readonly int port; // Port to connect to 
            private readonly string ipAddress; // IP address of the server 

            public DataPacketTcpSocket(string ipAddress, int port) // Constructor 
            {
                this.ipAddress = ipAddress;
                this.port = port;
            }

            // Method to send a data packet 
            public bool SendDataPacket(DataPacket.DataPacketStruct packet)
            {
                try
                {
                    // Connect to the server using TCP
                    TcpClient client = new TcpClient(ipAddress, port);
                    NetworkStream stream = client.GetStream();

                    // Serialize packet to json string
                    string jsonString = DataPacket.PacketManipulation.SerializeDataPacketStruct(packet);

                    // Convert json string to byte array
                    byte[] data = Encoding.ASCII.GetBytes(jsonString);

                    // Send packet to server
                    stream.Write(data, 0, data.Length);

                    // Close connections
                    stream.Close();
                    client.Close();

                    return true; // Return true if successful
                }
                catch (SocketException)
                {
                    return false;  // Return false if failed to send data packet
                }
            }

            public DataPacket.DataPacketStruct ReceiveDataPacket()
            {
                try
                {
                    // Start listening for incoming connections
                    TcpListener listener = new TcpListener(IPAddress.Any, port);
                    listener.Start();

                    // Accept incoming connection
                    TcpClient client = listener.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    // Read data from the stream
                    byte[] data = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(data, 0, client.ReceiveBufferSize);

                    // Convert received byte array to json string
                    string jsonString = Encoding.ASCII.GetString(data, 0, bytesRead);

                    // Deserialize json string to packet object
                    DataPacket.DataPacketStruct packet = DataPacket.PacketManipulation.DeserializeDataPacketStruct(jsonString);

                    // Close connections
                    stream.Close();
                    client.Close();
                    listener.Stop();

                    // Return the received data packet
                    return packet;
                }
                catch (SocketException)
                {
                    return null; // Return null if failed to receive data packet
                }
            }
        }
    }
}