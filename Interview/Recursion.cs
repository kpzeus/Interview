using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Recursion
    {
        public static int NumSquares(int n)
        {
            if (n <= 3)
                return n;

            int res = n;

            int i = 1;
            while (i <= n)
            {
                int t = i * i;
                if (t > n)
                    break;
                else
                {
                    var a = n - t;
                    var x = NumSquares(a);
                    res = Math.Min(res, 1 + x);
                }
                i++;
            }

            return res;
        }
    }
}
