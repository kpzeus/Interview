﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview
{
    public class DecibinaryNumbers
    {
        public static Dictionary<long, long> map = new Dictionary<long, long>();

        public static HashSet<long> processed = new HashSet<long>();

        public static Dictionary<long, Dictionary<long, bool>> evalMap = new Dictionary<long, Dictionary<long, bool>>();

        public static long decibinaryNumbers(long n)
        {
            if (map.ContainsKey(n))
            {
                return map[n - 1];
            }

            map[0] = 0;
            processed.Add(0);

            long curr = 0;
            long i = map.Count;
            while (curr <= n)
            {
                GetMatches(curr);

                curr++;
            }

            return map[n - 1];
        }

        public static void GetMatches(long n)
        {
            var x = 0;

            while (n >= Math.Pow(2, x))
            {
                x++;
            }

            GetMatch(n, x);
        }

        public static void GetMatch(long n, int maxPower)
        {
            var maxNumber = (int)Math.Pow(2, maxPower);
            var binaryNumber = Convert.ToDouble(Convert.ToString(maxNumber, 2));
            long count = 0;
            while (count < binaryNumber)
            {
                if (!processed.Contains(count))
                {
                    if (Eval(count, n))
                    {
                        map[map.Count] = count;
                        processed.Add(count);
                    }
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
