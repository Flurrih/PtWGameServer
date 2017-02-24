using PtWGameServer.Database;
using PtWGameServer.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PtWGameServer.Managers
{
    class LoginManager
    {
        LoginPacket data;
        public LoginManager(LoginPacket loginPacket, Socket clientSocket)
        {
            data = loginPacket;
            DBConnect db = new DBConnect();
            if(db.CheckForAuthorization(data.login , data.password))
            {
                CommandLine.WriteLine("Client authorized");
                clientSocket.Send(new LoginAuthorizationPacket(true).Data);
                //Authorization package
            }
            else
            {
                CommandLine.WriteLine("Clien not authorized");
                clientSocket.Send(new LoginAuthorizationPacket(false).Data);
                //Non authorization package
            }
        }
    }
}
