using PtWGameServer.ServerPackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PtWGameServer.Player
{
    public partial class PlayerData
    {
        public void SendPlayerData()
        {
            PacketWriter pw = new PacketWriter();
            pw.Write((ushort)Headers.Player);
            pw.Write((ushort)PlayerHeader.BasicData);
            pw.Write(id);
            pw.Write(userName);
            playerSocket.Send(pw.GetBytes());
            CommandLine.WriteLine("Sent Player Data packet");
        }
    }
}