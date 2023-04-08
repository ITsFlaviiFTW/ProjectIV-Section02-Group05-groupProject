using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace StormSocial_Server.Classes
{
    internal class StateMachine
    {
        // Use a property to store the current state
        public ServerState CurrentState { get; private set; }
        private Socket listener;

        // Store the client connections in a list
        private readonly List<ClientConnection> clientConnections = new List<ClientConnection>();

        public StateMachine()
        {
            CurrentState = ServerState.OffState;
        }

        public void TransitionTo(ServerState nextState)
        {
            // Perform any exit actions for the current state
            switch (CurrentState)
            {
                case ServerState.OnState:
                    StopListeningForConnections();
                    break;
                case ServerState.ChatState:
                    DisconnectAllClients();
                    break;
            }

            // Perform any entry actions for the next state
            switch (nextState)
            {
                case ServerState.OnState:
                    StartListeningForConnections();
                    break;
                case ServerState.ChatState:
                    StartChatting();
                    break;
            }

            // Update the current state
            CurrentState = nextState;
        }

        private void StartListeningForConnections()
        {
            // Set up the listening socket
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, 8000));
            listener.Listen(10);

            // Start accepting incoming connections asynchronously
            listener.BeginAccept(OnClientConnected, listener);
        }

        private void OnClientConnected(IAsyncResult result)
        {
            // Accept the new connection
            listener = (Socket)result.AsyncState;
            var clientSocket = listener.EndAccept(result);

            // Create a new client connection object and add it to the list
            var clientConnection = new ClientConnection(clientSocket, this);
            clientConnections.Add(clientConnection);

            // Start receiving data from the client asynchronously
            clientSocket.BeginReceive(clientConnection.Buffer, 0, clientConnection.Buffer.Length, SocketFlags.None, clientConnection.OnReceive, null);

            // Continue accepting incoming connections
            listener.BeginAccept(OnClientConnected, listener);
        }

        private void StartChatting()
        {
            // Nothing to do here, since we start accepting connections as soon as we enter the ChatState
        }

        private void StopListeningForConnections()
        {
            // Close the listening socket
            listener.Close();
        }

        private void DisconnectAllClients()
        {
            // Disconnect all clients
            foreach (var clientConnection in clientConnections)
            {
                clientConnection.Socket.Close();
            }
            clientConnections.Clear();
        }

        public enum ServerState
        {
            OffState,
            OnState,
            ChatState
        }

        public class ClientConnection
        {
            // Store the socket and buffer in fields
            public readonly Socket Socket;
            public readonly byte[] Buffer = new byte[10000000];

            public ClientConnection(Socket clientSocket, StateMachine stateMachine)
            {
                Socket = clientSocket;
                StateMachine = stateMachine;
            }

            public StateMachine StateMachine { get; }

            public void Send(string message)
            {
                byte[] data = Encoding.ASCII.GetBytes(message);
                Socket.Send(data);
            }

            public void OnReceive(IAsyncResult result)
            {
                int bytesRead = Socket.EndReceive(result);
                if (bytesRead > 0)
                {
                    string message = Encoding.ASCII.GetString(Buffer, 0, bytesRead);
                    // Broadcast the message to all clients except the sender
                    foreach (var clientConnection in StateMachine.clientConnections)
                    {
                        if (clientConnection != this)
                        {
                            clientConnection.Send(message);
                        }
                    }
                    // Start receiving data from the client again
                    Socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, OnReceive, null);
                }
                else
                {
                    // If no data was received, disconnect the client
                    Disconnect();
                }
            }

            private void Disconnect()
            {
                Socket.Close();
                StateMachine.clientConnections.Remove(this);
            }
        }
    }
}

