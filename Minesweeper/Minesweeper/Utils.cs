using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public static class Utils
    {
        public static string ReplaceCharAt(this string s,char c,int x)
        {
            return s.Substring(0,x) + c + s.Substring(x + 1);
        }
    }
}
