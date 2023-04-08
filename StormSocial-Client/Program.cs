// Client

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using StormSocial_Client;
using StormSocial_Server.Classes;

namespace SimpleClientServer
{

    class Program
    {
        // Create a TCP/IP socket and connect to the server
        // Create the socket connection
        public static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Dictionary<string, Login> loggedInClients = new Dictionary<string, Login>();

        [STAThread]
        static void Main(string[] args)
        {
            clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, 1234));


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}

