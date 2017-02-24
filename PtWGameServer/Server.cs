using PtWGameServer.Client;
using PtWGameServer.Networking;
using PtWGameServer.Player;
using SocksLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PtWGameServer
{
    public class Server
    {
        public Dictionary<string, Socket> _clients { get; private set; }
        public static ServerSocket ServerSocket;
        public bool isRunning { get; private set; }
        public Server()
        {
            isRunning = false;
            _clients = new Dictionary<string, Socket>();
            ServerSocket = new ServerSocket(this);
            ServerSocket.Bind(6556);
            ServerSocket.Listen(500);
            ServerSocket.Accept();

            if (ServerSocket._socket.Connected)
                isRunning = true;
        }

        public void AddNewClient(string token, Socket socket)
        {
            _clients.Add(token, socket);
            CommandLine.WriteLine("New client added to list");
        }
    }
}
