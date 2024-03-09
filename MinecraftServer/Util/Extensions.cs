using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServer.Util
{
    public static class Extensions
    {
        public static bool EqualsIgnoreCase(this string a, string b) => a.Equals(b, StringComparison.OrdinalIgnoreCase);
    }
}
