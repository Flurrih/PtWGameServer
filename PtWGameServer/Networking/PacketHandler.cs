using PtWGameServer.ServerPackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using PtWGameServer.Networking.Packets;
using PtWGameServer.Managers;

namespace PtWGameServer.Networking
{
    public static class PacketHandler
    {
        static int i = 0;
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            //ushort packetLength = BitConverter.ToUInt16(packet, 0);
            //ushort packetType = BitConverter.ToUInt16(packet, 2);



            //Console.WriteLine("Received packet! Length: {0} | Type: {1}", packetLength, packetType);
            CommandLine.WriteLine("Reading packet ");
            PacketReader pr = new PacketReader(packet);

            Header header = (Header)pr.ReadInt16();

            switch (header)
            {
                case Header.Login:
                    {
                        LoginPacket loginPacket = new LoginPacket(pr);
                        LoginManager loginManager = new LoginManager(loginPacket, clientSocket);
                    }
                    break;
            }
        }
    }
}
