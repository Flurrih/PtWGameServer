using PtWGameServer.ServerPackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PtWGameServer.Networking.Packets
{
    class LoginPacket : IPacket
    {
        public string login { get; private set; }
        public string password { get; private set; }
        public LoginPacket(PacketReader pr)
        {
            login = pr.ReadString();
            password = pr.ReadString();
        }
        public LoginPacket()
        {

        }
    }

    class LoginAuthorizationPacket : IPacket
    {
        byte[] packet;
        public LoginAuthorizationPacket(bool val)
        {
            pw.Write((ushort)Header.Login);
            if (val)
                pw.Write((ushort)LoginHeader.Authorization);
            else
                pw.Write((ushort)LoginHeader.NonAuthorization);
            packet = pw.GetBytes();
        }

        public byte[] Data
        {
            get { return packet; }
            set { }
        }
    }
}
