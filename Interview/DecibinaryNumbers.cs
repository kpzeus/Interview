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

        public static int globalCount = 0;

        public static long decibinaryNumbers(long n)
        {
            if (map.ContainsKey(n))
            {
                return map[n - 1];
            }

            if (items.Count == 0)
                items.Add(0);
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
                    if (!items.Contains(x))
                    {
                        items.Add(x);
                        map[i] = x;
                        i++;
                    }
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
            GetMatch(n, 0, 0, x, set);
            l.AddRange(set);
            l.Sort();

            return l;
        }

        public static void GetMatch(long n, long val, int power, int maxPower, List<long> l)
        {
            long testDigit = 0;
            while (power <= maxPower)
            {
                while (testDigit < 10)
                {
                    val = (val * 10) + testDigit;

                    if (((int)Math.Log10(val) + 1) <= maxPower)
                    {
                        if (Eval(val, n))
                        {
                            if(!l.Contains(val))
                                l.Add(val);
                        }
                    }

                    val = (val - testDigit) / 10;

                    testDigit++;
                }

                testDigit = 0;
                while (testDigit < 10)
                {
                    val = (val * 10) + testDigit;

                    if (((int)Math.Log10(val) + 1) <= maxPower)
                    {
                        if (val != 0)
                        {
                            GetMatch(n, val, power++, maxPower, l);
                        }
                    }

                    val = (val - testDigit) / 10;

                    testDigit++;
                }
                power++;
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
