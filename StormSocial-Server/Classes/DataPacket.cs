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
        struct DataPacketStruct
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

        internal class PacketManipulation
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

        }
    }
}