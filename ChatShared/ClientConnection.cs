using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatShared
{
    /// <summary>
    /// S > C.
    /// Contains information about a new client connection.
    /// 
    /// This object is sent to all connected users.
    /// </summary>
    public class ClientConnection
    {
        public string Username { get; set; }
    }
}
