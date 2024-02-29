using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatShared
{
    public static class Utils
    {
        public static bool EqualsIgnoreCase(this string a, string b) => a.Equals(b, StringComparison.OrdinalIgnoreCase);
    }
}
