using PtWGameServer.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PtWGameServer.Networking
{
    public class ServerSocket
    {
        public Server main { get; private set; }
        public Socket _socket { get; private set; }
        private byte[] _buffer = new byte[1024];

        public ServerSocket(Server main)
        {
            this.main = main;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Bind(int port)
        {
            _socket.Bind(new IPEndPoint(IPAddress.Parse(GetIPAddress()), port));
        }

        public void Listen(int backlog)
        {
            _socket.Listen(backlog);
        }

        public void Accept()
        {
            _socket.BeginAccept(AcceptedCallback, null);
        }

        private void AcceptedCallback(IAsyncResult result)
        {
            Socket clientSocket = _socket.EndAccept(result);
            string newToken = Guid.NewGuid().ToString();
            clientSocket.Send(new InitialPacket(newToken).Data);
            main.AddNewClient(newToken, clientSocket);
            CommandLine.WriteLine("Initial packet sent to new client");
            _buffer = new byte[1024];
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, clientSocket);
            Accept();
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                Socket clientSocket = (Socket)result.AsyncState;
                if (clientSocket.Connected)
                {
                    int bufferSize = clientSocket.EndReceive(result);
                    byte[] packet = new byte[bufferSize];
                    Array.Copy(_buffer, packet, packet.Length);

                    // Handle packet
                    if (packet.Length > 0)
                        PacketHandler.Handle(packet, clientSocket);

                    _buffer = new byte[1024];
                    clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, clientSocket);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
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

    }
}
