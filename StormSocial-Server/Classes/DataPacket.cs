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
            private uint CalculateChecksum()
            {
                using (var crc32 = new Crc32Algorithm())
                {
                    var sourceData = $"{sourceAddress},{sequenceNumber},{timeStamp},{dataType},{packetData}";
                    byte[] data = Encoding.ASCII.GetBytes(sourceData);
                    byte[] hash = crc32.ComputeHash(data);
                    return BitConverter.ToUInt32(hash, 0);
                }
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

            public static string SerializeDataPacketStruct(DataPacketStruct packet)
            {
                return JsonConvert.SerializeObject(packet);
            }

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
                    // Process text...
                }
            }

            // Function to generate a unique image path (based on date/time)
            public static string GetUniqueImagePath()
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                string imagePath = Path.Combine(Environment.CurrentDirectory, fileName);
                return imagePath;
            }

        }
    }
}