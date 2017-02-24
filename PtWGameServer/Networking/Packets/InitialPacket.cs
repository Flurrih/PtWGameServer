using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PtWGameServer.Networking.Packets
{
    class InitialPacket : IPacket
    {
        string token;
        byte[] packet;
        public InitialPacket(string token)
        {
            pw.Write((ushort)Header.Init);
            this.token = token;
            pw.Write(token);
            packet = pw.GetBytes();
        }

        public byte[] Data
        {
            get { return packet; }
            set { }
        }
    }
}
