using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.InteropServices;

namespace StormSocial_Server.Classes
{
    internal class DataPacket // Class for structure of 
    {
        public struct DataPacketStruct
        {
            public IPAddress[] sourceAddress; // Source address 
            public int sequenceNumber; // Sequence number
            public DateTime timeStamp; // Timestamp
            public string dataType; // Type of data
            public string data; // Actual packet data
            public uint checksum; // Checksum

            // Constructor to initialize the packet 
            public DataPacketStruct()
            {
                this.sourceAddress = Dns.GetHostAddresses(Dns.GetHostName()); // Get source address
                this.sequenceNumber = 0;
                this.timeStamp = DateTime.Now;
                this.dataType = "text/plain";
                this.data = "defaultString";
                this.checksum = 123;
            }

            // Constructor to initialize the packet with parameters
            public DataPacketStruct(IPAddress[] sourceAddress, int sequenceNumber, DateTime timeStamp, string dataType, string data, uint checksum)
            {
                this.sourceAddress = sourceAddress;
                this.sequenceNumber = sequenceNumber;
                this.timeStamp = timeStamp;
                this.dataType = dataType;
                this.data = data;
                this.checksum = checksum;
            }
        }

        public class PacketManipulation
        {
            char[] buffer = new char[Marshal.SizeOf(typeof(DataPacket))];

            // Function to log the data packet information to a text file
            void LogDataPacketInfo(DataPacketStruct packet, string filename)
            {
                using (StreamWriter outputFile = new StreamWriter(filename, true))
                {
                    // Write packet info in a structured format
                    outputFile.WriteLine("Source address: " + packet.sourceAddress);
                    outputFile.WriteLine("Sequence number: " + packet.sequenceNumber);
                    outputFile.WriteLine("Timestamp: " + packet.timeStamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    outputFile.WriteLine("Data type: " + packet.dataType);
                    outputFile.WriteLine("Data: " + packet.data);
                }
            }

            // Serialize a data packet
            static byte[] SerializeDataPacketStruct(DataPacketStruct dataPacket)
            {
                int size = Marshal.SizeOf(dataPacket); // get the size of a data packet
                byte[] buffer = new byte[size]; // create a buffer for the serialized data 
                IntPtr ptr = Marshal.AllocHGlobal(size); // ptr for the structure data 

                try 
                {
                    Marshal.StructureToPtr(dataPacket, ptr, false); // copy the packet contents to block
                    Marshal.Copy(ptr, buffer, 0, size); // copy packet contents (^block) to buffer
                }
                finally
                {
                    Marshal.FreeHGlobal(ptr); // free the allocated block
                }

                return buffer;
            }

            // Deserialize a data packet 
            static DataPacketStruct DeserializeDataPacketStruct(byte[] data)
            {
                IntPtr ptr = IntPtr.Zero;

                try
                {
                    int size = Marshal.SizeOf<DataPacketStruct>(); // get the size of a data packet
                    ptr = Marshal.AllocHGlobal(size); // ptr for the structure data 

                    Marshal.Copy(data, 0, ptr, size); // copies the contents of the byte array

                    // Convert memory block back to packet struct
                    DataPacketStruct packet = Marshal.PtrToStructure<DataPacketStruct>(ptr);

                    return packet;
                }
                finally
                {
                    if (ptr != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(ptr); //  ensures that the memory block is always freed
                    }
                }
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
                    string encodedPacketImage = receivedPacket.data; // Get encoded image from packet 

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