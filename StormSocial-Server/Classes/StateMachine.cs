using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace StormSocial_Server.Classes
{
    internal class StateMachine
    {
        public enum ServerState
        {
            OffState,
            OnState,
            WaitForConnectionState,
            WaitForPostState,
            ChatState
        }
        public class ClientConnection
        {
            private Socket socket;
            private byte[] buffer = new byte[1024];

            public void Connect(string ipAddress, int port)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), port));
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnReceive, null);
            }

            public void Send(string message)
            {
                byte[] data = Encoding.ASCII.GetBytes(message);
                socket.Send(data);
            }

            private void OnReceive(IAsyncResult result)
            {
                int bytesRead = socket.EndReceive(result);
                if (bytesRead > 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    // TODO: handle incoming message
                    
                }
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnReceive, null);
            }
        }

        public class ServerStateMachine
        {    
            private ServerState currentState;
            private Socket listener;

            // Define any necessary module-level variables here
            private List<ClientConnection> clientConnections;

            public ServerStateMachine()
            {
                currentState = ServerState.OffState;
                // Initialize any module-level variables here
                clientConnections = new List<ClientConnection>();
            }
            public void StartListeningForConnections()
            {
                // Set up the listening socket
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(new IPEndPoint(IPAddress.Any, 1234));
                listener.Listen(10);

                Console.WriteLine("Waiting for connections...");

                // Accept connections in a loop
                while (true)
                {
                    // Accept a connection
                    Socket clientSocket = listener.Accept();

                    // Create a new ClientConnection object to handle the connection
                    ClientConnection clientConnection = new ClientConnection(clientSocket, this);

                    // Add the new client to the list of connected clients
                    connectedClients.Add(clientConnection);

                    Console.WriteLine("Client connected: " + clientSocket.RemoteEndPoint.ToString());
                }
            }

            public void TransitionTo(ServerState nextState)
            {
                switch (currentState)
                {
                    case ServerState.OffState:
                        if (nextState == ServerState.OnState)
                        {
                            // Perform OnState entry actions here
                            StartListeningForConnections();
                            currentState = nextState;
                        }
                        break;

                    case ServerState.OnState:
                        if (nextState == ServerState.WaitForConnectionState)
                        {
                            // Perform WaitForConnectionState entry actions here
                            Console.WriteLine("Waiting for client connections...");
                            currentState = nextState;
                        }
                        else if (nextState == ServerState.OffState)
                        {
                            // Perform OffState entry actions here
                            listener.Close();
                            Console.WriteLine("Server is now offline.");
                            currentState = nextState;
                        }
                        break;

                    case ServerState.WaitForConnectionState:
                        if (nextState == ServerState.WaitForPostState)
                        {
                            // Perform WaitForPostState entry actions here
                            Console.WriteLine("All clients connected. Waiting for posts...");
                            AcceptNextConnection();
                            currentState = nextState;
                        }
                        else if (nextState == ServerState.OffState)
                        {
                            // Perform OffState entry actions here
                            listener.Close();
                            Console.WriteLine("Server is now offline.");
                            currentState = nextState;
                        }
                        break;

                    case ServerState.WaitForPostState:
                        if (nextState == ServerState.WaitForConnectionState)
                        {
                            // Perform WaitForConnectionState entry actions here
                            StartWaitingForPosts();
                            currentState = nextState;
                        }
                        else if (nextState == ServerState.OffState)
                        {
                            // Perform OffState entry actions here
                            currentState = nextState;
                        }
                        else if (nextState == ServerState.ChatState)
                        {
                            // Perform ChatState entry actions here
                            EnterChatState();
                            currentState = nextState;
                        }
                        break;

                    case ServerState.ChatState:
                        if (nextState == ServerState.WaitForPostState)
                        {
                            // Perform WaitForPostState entry actions here
                            ExitChatState();
                            currentState = nextState;
                        }
                        else if (nextState == ServerState.OffState)
                        {
                            // Perform OffState entry actions here
                            ExitChatState();
                            currentState = nextState;
                        }
                        break;

                    default:
                        // Handle invalid state transition
                        break;
                }
            }
        }
    }
}