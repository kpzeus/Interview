using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class Series
    {
        public static IEnumerable<string> Slices(string v1, int v2)
        {
            List<string> res = new List<string>();

            if (string.IsNullOrEmpty(v1) || v2 > v1.Length || v2 < 1)
            {
                throw new ArgumentException();
            }

            int index = 0;
            while(index + v2 <= v1.Length)
            {
                res.Add(v1.Substring(index, v2));
                index++;
            }

            return res;
        }
    }
}
