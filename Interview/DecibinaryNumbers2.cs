using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class DecibinaryNumbers2
    {
        public static Dictionary<long, List<long>> lookup = new Dictionary<long, List<long>>();

        public static long[] items = new long[10000000];

        public static long index = 0;

        public static long decibinaryNumbers(long n)
        {
            if (lookup.Count == 0)
            {
                GetMatch();
            }

            return items[n - 1];
        }

        public static void GetMatch()
        {
            long count = 0;

            while (count < items.Length)
            {
                Eval(count);
                count++;
            }

            foreach (var set in lookup)
            {
                foreach (var val in set.Value)
                {
                    items[index] = val;
                    index++;
                }
            }
        }

        public static void Eval(long val)
        {
            long t = 0;
            int p = 0;
            long val2 = val;

            while (val2 > 0)
            {
                var digit = val2 % 10;
                t += digit * (1 << p);
                p++;
                val2 /= 10;
            }

            if (!lookup.ContainsKey(t))
            {
                lookup.Add(t, new List<long>());
            }

            lookup[t].Add(val);
        }
    }
}
