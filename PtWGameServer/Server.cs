using PtWGameServer.Client;
using PtWGameServer.Player;
using PtWGameServer.ServerPackets.PacketManagers;
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
        static Socket listenerSocket;
        static List<ClientData> _clients;
        static List<PlayerData> _players;


        public void Start()
        {
            CommandLine.Write("[" + DateTime.Now + "] "+"Starting server on " + GetIPAddress());
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clients = new List<ClientData>();
            _players = new List<PlayerData>();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(GetIPAddress()), 8888);

            listenerSocket.Bind(ip);

            Thread listenThread = new Thread(ListenThread);
            listenThread.Start();
            CommandLine.WriteLine("Server started");
        }

        static void ListenThread()
        {
            for (;;)
            {
                listenerSocket.Listen(0);

                _clients.Add(new ClientData(listenerSocket.Accept()));
                CommandLine.WriteLine("New Client connected");
            }
        }

        //clientData thread - receives data from each client individually
        public static void Data_IN(object cSocket)
        {
            Socket clientSocket = (Socket)cSocket;

            byte[] Buffer = new byte[512];
            int readBytes;

            for (;;)
            {

                try
                {
                    Buffer = new byte[clientSocket.SendBufferSize];

                    readBytes = clientSocket.Receive(Buffer);

                    if (readBytes > 0)
                    {
                        PacketManager.Unpack(Buffer, _clients[0]);
                    }
                }
                catch (SocketException ex)
                {
                    CommandLine.WriteLine("Client disconnected");
                }
            }
        }


        public static string GetIPAddress()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress i in ips)
            {
                if (i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return i.ToString();
            }

            return "127.0.0.1";
        }
        public static void AddNewPlayer(PlayerData player)
        {
            _players.Add(player);
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).onlinePlayers.AppendText(Environment.NewLine + player.id + ":" + player.userName);
            });
        }
        public static ClientData GetClientSocket(string token)
        {
            foreach (ClientData c in _clients)
            {
                if (c.token == token)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
