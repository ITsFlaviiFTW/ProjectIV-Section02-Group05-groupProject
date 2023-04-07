// Server

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using StormSocial_Server.Classes;

namespace SimpleClientServer
{
    class Program
    {
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

            // Receive and process data from the client in a loop
            while (clientSocket.Connected)
            {
                var buffer = new byte[1024];
                var bytesRead = await clientSocket.ReceiveAsync(buffer, SocketFlags.None);
                if (bytesRead == 0)
                {
                    // Client disconnected
                    Console.WriteLine($"Client {clientSocket.RemoteEndPoint} disconnected");
                    break;
                }

                // Deserialize the received data packet
                var packet = DataPacket.PacketManipulation.DeserializeDataPacketStruct(Encoding.ASCII.GetString(buffer));
                DataPacket.PacketManipulation.ProcessDataPacket(packet);

                Console.WriteLine("Message Received from " + packet.GetSourceAddress() + ": " + packet.GetPacketData());

            }

            // Clean up the client socket
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
}