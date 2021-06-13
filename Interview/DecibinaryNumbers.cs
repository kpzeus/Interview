using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class DecibinaryNumbers
    {
        public static Dictionary<long, long> map = new Dictionary<long, long>();

        public static Dictionary<long, Dictionary<long, bool>> evalMap = new Dictionary<long, Dictionary<long, bool>>();

        public static int globalCount = 0;

        public static long decibinaryNumbers(long n)
        {
            if (map.ContainsKey(n))
            {
                return map[n - 1];
            }

            map[0] = 0;

            long curr = 0;
            long i = map.Count;
            while (curr <= n)
            {
                if (curr <= globalCount)
                {
                    curr++;
                    continue;
                }                   

                var m = GetMatches(curr);
                m.ForEach(x =>
                {
                    map[i] = x;
                    i++;
                });

                globalCount++;
                curr++;
            }

            return map[n - 1];
        }

        public static List<long> GetMatches(long n)
        {
            List<long> l = new List<long>();

            var x = 0;
            while (n >= Math.Pow(2, x))
            {
                x++;
            }

            var set = new List<long>();
            set.Add(n);
            GetMatch(n, x, set);
            l.AddRange(set);

            return l;
        }

        public static void GetMatch(long n, int maxPower, List<long> l)
        {
            var maxNumber = (int)Math.Pow(2, maxPower);
            var binaryNumber = Convert.ToInt64(Convert.ToString(maxNumber, 2));
            long count = 0;
            while(count < binaryNumber)
            {
                if (Eval(count, n))
                {
                    if (!l.Contains(count))
                        l.Add(count);
                }
                count++;
            }
        }

        public static bool Eval(long val, long n)
        {
            if (evalMap.ContainsKey(n) && evalMap[n].ContainsKey(val))
            {
                return evalMap[n][val];
            }

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

            if (t == n)
            {
                if (!evalMap.ContainsKey(n))
                    evalMap.Add(n, new Dictionary<long, bool>());

                if (!evalMap[n].ContainsKey(val))
                    evalMap[n].Add(val, t == n);
            }
            else
            {
                if (!evalMap.ContainsKey(t))
                    evalMap.Add(t, new Dictionary<long, bool>());

                if (!evalMap[t].ContainsKey(val))
                    evalMap[t].Add(val, true);
            }

            return t == n;
        }
    }
}
