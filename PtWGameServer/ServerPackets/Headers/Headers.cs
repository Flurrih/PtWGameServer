using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PtWGameServer
{
    public enum Headers : ushort
    {
        Login,
        Registration,
        Connection,
        Player
    }

    public enum LoginHeader : ushort
    {
        Authorization,
        NonAuthorization
    }

    public enum PlayerHeader : ushort
    {
        BasicData
    }
}