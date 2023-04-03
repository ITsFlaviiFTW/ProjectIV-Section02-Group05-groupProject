using Force.Crc32;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

namespace StormSocial_Server.Tests
{
    [TestClass]
    public class DataPacketTests
    {
        [TestMethod]
        public void T001_DefaultConstructor_VerifyContents()
        {
            // Arrange
            var packet = new DataPacket.DataPacketStruct(); // Default non-parameterized constructor
            var expectedAddresses = Dns.GetHostAddresses(Dns.GetHostName());

            // Assert
            Assert.AreEqual(packet.sequenceNumber, 0);
            Assert.IsTrue(packet.timeStamp == System.DateTime.Now.ToString());
            Assert.AreEqual(packet.dataType, "text/plain");
            Assert.AreEqual(packet.packetData, "defaultString");
        }


        [TestMethod]
        public void T002_ParameterizedConstructor_VerifyContents()
        {
            // Arrange
            var packet = new DataPacket.DataPacketStruct(1, "text/plain", "Test packet", (uint)12345); // Parameterized constructor

            // Assert
            Assert.AreEqual(packet.sequenceNumber, 1);
            Assert.AreEqual(packet.timeStamp, packet.timeStamp);
            Assert.AreEqual(packet.dataType, "text/plain");
            Assert.AreEqual(packet.packetData, "Test packet");
            Assert.AreEqual(packet.checksum, (uint)12345);
        }

        [TestMethod]
        public void T003_CalculateChecksum_ModifyContents_Compare()
        {
            // Arrange
            var packet = new DataPacket.DataPacketStruct(1, "text/plain", "Test packet", 0); // Parameterized constructor

            // Act
            packet.checksum = 12345; // Set the checksum to a known value
            packet.sequenceNumber = 2; // Modify one of the other fields
            uint newChecksum = packet.checksum; // Get the new checksum value

            // Assert
            Assert.AreNotEqual(newChecksum, 12345);
        }

        [TestMethod]
        public void T004_SerializeDataPacketStruct_VerifySizeAndContents()
        {
            // Arrange
            int sequenceNumber = 123;
            string dataType = "image/jpeg";
            string data = "abc123";
            int checksum = 456;

            // Act
            DataPacket.DataPacketStruct packet = new DataPacket.DataPacketStruct(sequenceNumber, dataType, data, (uint)checksum);
            string buffer = DataPacket.PacketManipulation.SerializeDataPacketStruct(packet);

            DataPacket.DataPacketStruct deserializedPacket = DataPacket.PacketManipulation.DeserializeDataPacketStruct(buffer);

            // Assert
            Assert.AreEqual(packet.sequenceNumber, deserializedPacket.sequenceNumber);
            Assert.IsTrue(packet.timeStamp == System.DateTime.Now.ToString());
            Assert.AreEqual(packet.dataType, deserializedPacket.dataType);
            Assert.AreEqual(packet.packetData, deserializedPacket.packetData);
            Assert.AreEqual(packet.checksum, deserializedPacket.checksum);
        }

        [TestMethod]
        public void T005_LogDataPacketInfo_WritesPacketInfoToTextFile()
        {
            // Arrange
            var packet = new DataPacket.DataPacketStruct
            {
                sourceAddress = "192.168.1.1",
                sequenceNumber = 1,
                timeStamp = DateTime.Now.ToString(),
                dataType = "text/plain",
                packetData = "Hello, World!"
            };

            var filename = "test.txt";
            var packetManipulation = new DataPacket.PacketManipulation();

            // Act
            packetManipulation.LogDataPacketInfo(packet, filename);

            // Assert
            var lines = File.ReadAllLines(filename);
            Assert.AreEqual("Source address: 192.168.1.1", lines[0]);
            Assert.AreEqual("Sequence number: 1", lines[1]);
            Assert.AreEqual($"Timestamp: {packet.timeStamp}", lines[2]);
            Assert.AreEqual("Data type: text/plain", lines[3]);
            Assert.AreEqual("Data: Hello, World!", lines[4]);

            // Clean up
            File.Delete(filename);
        }
    }
}
