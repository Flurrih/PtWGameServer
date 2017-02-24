using SocksLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PtWGameServer.Client
{
    public class ClientData
    {
        public Socket socket { get; private set; }
        public string token { get; private set; }

        public ClientData(Socket socket, string token)
        {
            this.socket = socket;
            this.token = token;
        }
    }
}