using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    internal class ChatUser
    {
        public string Username { get; init; }
        public string SessionId { get; init; }

        public ChatUser(string username, string sessionId)
        {
            Username = username;
            SessionId = sessionId;
        }
    }
}
