using PtWGameServer.Client;
using PtWGameServer.Database;
using PtWGameServer.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PtWGameServer.ServerPackets.PacketManagers
{
    public static class PacketManager
    {
        public static void Unpack(byte[] data, ClientData client)
        {
            PacketReader pr = new PacketReader(data);
            Headers header = (Headers)pr.ReadUInt16();
            switch (header)
            {
                case Headers.Login:
                    {
                        CommandLine.WriteLine("Login attempt by client");
                        string token = pr.ReadString();
                        string login = pr.ReadString();
                        string password = pr.ReadString();
                        DBConnect db = new DBConnect();
                        if (db.CheckForAuthorization(login, password))
                        {

                            CommandLine.WriteLine("Client authorized");
                            PlayerData player = new PlayerData(Server.GetClientSocket(token).clientSocket);
                            db.FillPlayerData(login, player);
                            client.SendLoginAuthorizationPacket();

                            Server.AddNewPlayer(player);
                            CommandLine.WriteLine("New player logged in with ID: " + player.id + "username: " + player.userName);
                            player.SendPlayerData();
                        }
                        else
                        {
                            client.SendLoginNonAuthorizationPacket();
                            CommandLine.WriteLine("Client not authorized");
                        }
                    }
                    break;
                case Headers.Registration:
                    {
                        DBConnect db = new DBConnect();
                        string token = pr.ReadString();
                        string login = pr.ReadString();
                        string password = pr.ReadString();
                        db.InsertNewUser(login, password);
                        CommandLine.WriteLine("Added new user with ID: " + login);
                    }
                    break;
            }
        }
    }
}