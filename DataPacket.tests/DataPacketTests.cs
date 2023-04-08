using Force.Crc32;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using static StormSocial_Server.Classes.DataPacket;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System;

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
            var packet = new DataPacket.DataPacketStruct("sampleEmail", 1, "text/plain", "Test packet", (uint)12345); // Parameterized constructor

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
            var packet = new DataPacket.DataPacketStruct("sampleEmail", 1, "text/plain", "Test packet", 0); // Parameterized constructor

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
            string testEmail = "sampleEmail";

            // Act
            DataPacket.DataPacketStruct packet = new DataPacket.DataPacketStruct(testEmail, sequenceNumber, dataType, data, (uint)checksum);
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

        [TestMethod]
        public void T006_ImageDecode_CheckImageIsSaved()
        {
            // Arrange
            var packet = new DataPacket.DataPacketStruct() // Create a new packet (with mock image)
            {
                dataType = "image",
                packetData = "encodedImageData"
            };
            var imagePath = DataPacket.PacketManipulation.GetUniqueImagePath();

            // Act

            // Decode and write image to file
            DataPacket.PacketManipulation.DecodeAndWriteImageToFile(packet.packetData, imagePath);

            // Assert
            Assert.IsTrue(File.Exists(imagePath)); // Check if image has been saved 
        }

        [TestMethod]
        public void T007_ProcessPacket_VerifyNoExceptions()
        {
            // Arrange
            var packet = new DataPacket.DataPacketStruct()
            {
                dataType = "text/plain",
                packetData = "test data"
            };

            // Act
            try
            {
                DataPacket.PacketManipulation.ProcessDataPacket(packet);
            }
            catch (AssertFailedException ex)
            {
                Assert.Fail("Assertion failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }

            // Assert
            // No exception thrown
        }

        [TestMethod]
        public void T008_TestPacketSending() // Create a new data packet
        {
            // Arrange
            var packet = new DataPacket.DataPacketStruct() // Test packet
            {
                sequenceNumber = 1,
                dataType = "image",
                packetData = "encodedImageData"
            };

            // Create two sockets
            var serverSocket = new DataPacket.DataPacketTcpSocket("localhost", 8080);
            var clientSocket = new DataPacket.DataPacketTcpSocket("localhost", 8080);

            // Act

            // Send the data packet from the server socket to the client socket
            var serverResult = serverSocket.SendDataPacket(packet);
            var receivedPacket = clientSocket.ReceiveDataPacket();

            // Assert

            // Ensure received data packet matches the original data packet
            Assert.IsTrue(serverResult);
            Assert.AreEqual(packet.sequenceNumber, receivedPacket.sequenceNumber);
            Assert.AreEqual(packet.dataType, receivedPacket.dataType);
            Assert.AreEqual(packet.packetData, receivedPacket.packetData);
        }

        [TestMethod]
        public void T009_TestPacketReceiving()
        {
            // Arrange
            string ipAddress = "localhost"; // IP address of the server
            int port = 8080; // Port number of the server
            DataPacketTcpSocket socket = new DataPacketTcpSocket(ipAddress, port);

            // Create a test packet
            DataPacket.DataPacketStruct testPacket = new DataPacket.DataPacketStruct();
            string jsonString = DataPacket.PacketManipulation.SerializeDataPacketStruct(testPacket);
            byte[] data = Encoding.ASCII.GetBytes(jsonString);

            // Start a server to send the test packet
            TcpListener server = TcpListener.Create(port);
            server.Start();
            TcpClient client = new TcpClient();
            client.Connect(ipAddress, port);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);

            // Act
            DataPacket.DataPacketStruct receivedPacket = socket.ReceiveDataPacket();

            // Assert
            Assert.AreEqual(testPacket.sourceAddress, receivedPacket.sourceAddress);
            Assert.AreEqual(testPacket.sequenceNumber, receivedPacket.sequenceNumber);
            Assert.AreEqual(testPacket.timeStamp, receivedPacket.timeStamp);
            Assert.AreEqual(testPacket.dataType, receivedPacket.dataType);
            Assert.AreEqual(testPacket.packetData, receivedPacket.packetData);
            Assert.AreEqual(testPacket.checksum, receivedPacket.checksum);

            // Clean up
            server.Stop();
            client.Close();
            stream.Close();
        }

        [TestMethod]
        public void T010_TestConnection()
        {

        }
    }
}
