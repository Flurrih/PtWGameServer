using PtWGameServer.ServerPackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PtWGameServer.Client
{
    public partial class ClientData
    {
        public void SendLoginAuthorizationPacket()
        {
            PacketWriter pw = new PacketWriter();
            pw.Write((ushort)Headers.Login);
            pw.Write((ushort)LoginHeader.Authorization);
            clientSocket.Send(pw.GetBytes());
        }
        public void SendLoginNonAuthorizationPacket()
        {
            PacketWriter pw = new PacketWriter();
            pw.Write((ushort)Headers.Login);
            pw.Write((ushort)LoginHeader.NonAuthorization);
            clientSocket.Send(pw.GetBytes());
        }
        public void SendConnectionPacket()
        {
            PacketWriter pw = new PacketWriter();
            pw.Write((ushort)Headers.Connection);
            pw.Write(token);
            clientSocket.Send(pw.GetBytes());
        }
    }
}