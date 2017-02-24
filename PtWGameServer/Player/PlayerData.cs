using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PtWGameServer.Player
{
    public partial class PlayerData
    {
        public Socket playerSocket;
        public Thread playerThread;
        public int id;
        public string userName;
        public PlayerData(Socket playerSocket)
        {
            //this.playerSocket = playerSocket;
            //playerThread = new Thread(Server.Data_IN);
            //playerThread.Start(playerSocket);
        }
        public PlayerData(Socket playerSocket, int id, string userName)
        {
            //this.playerSocket = playerSocket;
            //this.id = id;
            //this.userName = userName;
            //playerThread = new Thread(Server.Data_IN);
            //playerThread.Start(playerSocket);
        }
    }
}
