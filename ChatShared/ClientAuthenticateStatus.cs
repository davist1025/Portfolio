using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatShared
{
    /// <summary>
    /// S > C.
    /// Contains information related to an unsuccessful login.
    /// 
    /// This packet is only sent if ClientSession is not.
    /// </summary>
    public class ClientAuthenticateStatus
    {
        public enum AuthState
        {
            UserAlreadyExists
        }

        public AuthState State { get; set; }
    }
}
