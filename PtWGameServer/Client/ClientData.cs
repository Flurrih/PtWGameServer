using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PtWGameServer.Client
{
    public partial class ClientData
    {
        public Socket clientSocket;
        public Thread clientThread;
        public string token;

        public ClientData()
        {
            token = Guid.NewGuid().ToString();
            clientThread = new Thread(Server.Data_IN);
            clientThread.Start(clientSocket);
            SendConnectionPacket();
        }
        public ClientData(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            token = Guid.NewGuid().ToString();
            clientThread = new Thread(Server.Data_IN);
            clientThread.Start(clientSocket);
            SendConnectionPacket();
        }
    }
}