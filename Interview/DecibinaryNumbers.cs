using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class DecibinaryNumbers
    {
        public static Dictionary<long, long> map = new Dictionary<long, long>();

        public static List<long> items = new List<long>();

        public static Dictionary<long, Dictionary<long, bool>> evalMap = new Dictionary<long, Dictionary<long, bool>>();

        public static long decibinaryNumbers(long n)
        {
            if (map.ContainsKey(n))
            {
                return map[n];
            }

            long curr = 0;
            long i = map.Count + 1;
            while (curr <= n)
            {
                var m = GetMatches(curr);
                m.ForEach(x =>
                {
                    if (!items.Contains(x))
                    {
                        items.Add(x);
                        map[i] = x;
                        i++;
                    }
                });

                curr++;
            }

            return map[n];
        }

        public static List<long> GetMatches(long n)
        {
            List<long> l = new List<long>();

            var x = 0;
            while (n > Math.Pow(2, x))
            {
                x++;
            }

            var set = new List<long>();
            GetMatch(n, 0, x, set);
            l.AddRange(set);
            l.Sort();

            return l;
        }

        public static void GetMatch(long n, long val, int power, List<long> l)
        {
            long testDigit = 0;
            while (power > -1)
            {
                while (testDigit < 10)
                {
                    val = (val * 10) + testDigit;

                    if (val.ToString().Length <= (power + 1))
                    {
                        if (Eval(val, n))
                        {
                            l.Add(val);
                        }
                        else
                        {
                            if (val != 0)
                            {
                                GetMatch(n, val, power, l);
                            }
                        }
                    }

                    val = (val - testDigit) / 10;

                    testDigit++;
                }
                power--;
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

            while (val > 0)
            {
                var digit = val % 10;
                t += digit * (1 << p);
                p++;
                val /= 10;
            }

            if (t == n)
            {
                if (!evalMap.ContainsKey(n))
                    evalMap.Add(n, new Dictionary<long, bool>());

                if (!evalMap[n].ContainsKey(val))
                    evalMap[n].Add(val, t == n);
            }

            return t == n;
        }
    }
}
