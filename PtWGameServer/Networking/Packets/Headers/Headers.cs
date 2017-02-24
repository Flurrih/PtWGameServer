using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PtWGameServer
{
    enum Header : ushort
    {
        Init,
        Login,
        Chat
    }

    enum LoginHeader : ushort
    {
        Authorization,
        NonAuthorization
    }
}