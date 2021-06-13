using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview
{
    public class ArrayQns
    {
        public static int GetMaxSumContiguousSubarray(params int[] a)
        {
            int meh = 0;
            int msf = int.MinValue;
            int start = -1;
            int end = -1;

            for (int i = 0; i < a.Length; i++)
            {
                meh = meh + a[i];

                if (meh < a[i])
                {
                    meh = a[i];
                    start = i;
                }

                if (msf < meh)
                {
                    msf = meh;
                    end = i;
                }
            }

            Console.WriteLine(start);
            Console.WriteLine(end);

            return msf;
        }

        public static int[,] GenSpiralMatrix(int n)
        {
            int[,] m = new int[n, n];

            int t = 0;
            int b = n - 1;
            int l = 0;
            int r = n - 1;
            int s = n * n + 1;
            int c = 1;

            while (c < s)
            {
                for (int i = l; i <= r && c < s; i++)
                    m[t, i] = c++;
                t++;
                for (int i = t; i <= b && c < s; i++)
                    m[i, r] = c++;
                r--;
                for (int i = r; i >= l && c < s; i--)
                    m[b, i] = c++;
                b--;
                for (int i = b; i >= t && c < s; i--)
                    m[i, l] = c++;
                l++;
            }

            return m;
        }

        public static String GetLargestNumberFormed(params int[] a)
        {
            int i = 0;
            int j = 1;
            int temp = 0;

            while (i < a.Length)
            {
                j = i + 1;
                while (j < a.Length)
                {
                    if (string.Compare(a[j].ToString() + a[i].ToString(),
                                       a[i].ToString() + a[j].ToString()) > 0)
                    {
                        temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                    j++;
                }
                i++;
            }

            i = 0;
            string s = "";
            while (i < a.Length)
            {
                s = s + a[i];
                i++;
            }

            int val = 0;
            if (int.TryParse(s, out val))
            {
                s = val.ToString();
            }

            return s;
        }

        public static int[] PlusOne(params int[] digits)
        {
            for (int i = digits.Length - 1; i > -1; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            int[] n = new int[digits.Length + 1];
            n[0] = 1;

            return n;
        }

        public static void AntiDiagonals(int[,] a)
        {
            int n = a.GetLength(0);
            int N = 2 * n - 1;

            List<List<int>> l = new List<List<int>>();

            for (int i = 0; i < N; i++)
            {
                l.Add(new List<int>());
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    l[i + j].Add(a[i, j]);
                }
            }

            for (int i = 0; i < l.Count; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < l[i].Count; j++)
                {
                    Console.Write(l[i][j] + " ");
                }
            }
        }

        public static int MySqrt(int x)
        {
            if (x == 0 || x == 1)
                return x;

            long start = 1, end = x, ans = 0;
            while (start <= end)
            {
                long mid = (start + end) / 2;

                if (mid * mid == x)
                    return (int)mid;

                if (mid * mid < x)
                {
                    start = mid + 1;
                    ans = mid;
                }
                else
                    end = mid - 1;
            }

            return (int)ans;
        }

        public static int RomanToInt(string s)
        {
            Dictionary<char, int> m = new Dictionary<char, int>();

            m.Add('I', 1);
            m.Add('V', 5);
            m.Add('X', 10);
            m.Add('L', 50);
            m.Add('C', 100);
            m.Add('D', 500);
            m.Add('M', 1000);

            int r = m[s[s.Length - 1]];
            for (int i = s.Length - 2; i > -1; i--)
            {
                if (m[s[i + 1]] > m[s[i]])
                {
                    r -= m[s[i]];
                }
                else
                    r += m[s[i]];
            }

            return r;
        }

        public static void WaysOfDenominations(int amount, int[] change, HashSet<string> ways, string current = "", int last = 0)
        {
            if (change == null || change.Length == 0)
                return;

            if (amount < 0)
                return;

            if (amount == 0)
            {
                if (!ways.Contains(current))
                {
                    ways.Add(current);
                }

                return;
            }

            foreach (int c in change)
            {
                if (c >= last)
                    WaysOfDenominations(amount - c, change, ways, current + c + " ", c);
            }
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            int i = -1;
            int j = -1;

            int s = 0;
            int e = nums.Length - 1;
            int m = -1;
            bool found = false;

            if (nums == null || nums.Length == 0)
                return new int[] { i, j };

            while (s <= e)
            {
                m = (s + e) / 2;

                if (nums[m] == target)
                {
                    found = true;
                    break;
                }

                if (nums[m] < target)
                    s = m + 1;
                else
                    e = m - 1;
            }

            if (found)
            {
                i = m;
                j = m;

                while (i > -1 && nums[i] == target)
                {
                    i--;
                }
                i++;

                while (j < nums.Length && nums[j] == target)
                {
                    j++;
                }
                j--;
            }

            return new int[] { i, j };
        }

        public static void SortColors(int[] a)
        {
            int i = 0;
            int k = a.Length - 1;
            int j = k;
            int t = 0;

            while (i <= j)
            {
                if (a[j] == 0)
                {
                    t = a[i];
                    a[i] = a[j];
                    a[j] = t;
                    i++;
                }
                else if (a[j] == 2)
                {
                    t = a[k];
                    a[k] = a[j];
                    a[j] = t;
                    k--;
                    j--;
                }
                else
                    j--;
            }

            Console.WriteLine();
        }

        public static long candies(int n, List<int> arr)
        {
            int[] c = new int[n];
            long sum = 0;

            for (int i = 0; i < n; i++)
            {
                c[i] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                if (arr[i] > arr[i - 1])
                    c[i] = c[i - 1] + 1;
            }

            for (int i = n - 2; i > -1; i--)
            {
                if (arr[i] > arr[i + 1])
                    c[i] = Math.Max(c[i], c[i + 1] + 1);
            }

            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine(c[i]);
                sum += c[i];
            }

            return sum;
        }

        public static int canSum(List<int> A, int B)
        {
            if (A == null || A.Count == 0)
            {
                return 0;
            }

            HashSet<int> h = new HashSet<int>();

            foreach (var x in A)
            {
                if (x == B)
                    return 1;

                if (x > B)
                    continue;

                h.Add(x);

                List<int> sl = new List<int>();
                foreach (var y in h)
                {
                    if (y > B)
                        continue;

                    var s = x + y;
                    if (s == B)
                        return 1;

                    sl.Add(s);
                }

                foreach (var s in sl)
                {
                    h.Add(s);
                }
            }

            return 0;
        }

        public static List<int> howSum(
            List<int> A, 
            int B)
        {
            var result = new List<int>();

            if (A == null || A.Count == 0 || B < 0)
            {
                return result;
            }

            return howSum(A, B, new List<int>(), new List<int>());
        }

        private static List<int> howSum(
            List<int> A,
            int B,
            List<int> temp,
            List<int> cache)
        {
            if (cache.Contains(B))
                return null;

            cache.Add(B);

            if (B < 0)
                return null;

            if (B == 0)
            {
                return temp;
            }  

            foreach(var x in A)
            {
                temp.Add(x);
                var ret = howSum(A, B - x, temp, cache);
                if (ret != null)
                    return ret;
                temp.Remove(x);
            }

            return null;
        }

        public static List<int> bestSum(
           List<int> A,
           int B)
        {
            var result = new List<int>();

            if (A == null || A.Count == 0 || B < 0)
            {
                return result;
            }

            A.Sort();
            A.Reverse();

            return bestSum(A, B, new List<int>(), new List<int>());
        }

        private static List<int> bestSum(
            List<int> A,
            int B,
            List<int> temp,
            List<int> cache)
        {
            if (cache.Contains(B))
                return null;

            cache.Add(B);

            if (B < 0)
                return null;

            if (B == 0)
            {
                return temp;
            }

            foreach (var x in A)
            {
                temp.Add(x);
                var ret = howSum(A, B - x, temp, cache);
                if (ret != null)
                    return ret;
                temp.Remove(x);
            }

            return null;
        }

        public static int fib(int n)
        {
            var x = new int[n + 1];

            x[1] = 1;

            for(int i=0; i<n; i++)
            {
                x[i + 1] += x[i];
                if(i+2 <= n)
                    x[i + 2] += x[i];
            }

            return x[n];
        }

        public static bool canSumTabular(int t, params int[] a)
        {
            var x = new bool[t + 1];

            x[0] = true;

            for (int i = 0; i <= t; i++)
            {
                if (x[i])
                {
                    for (int j = 0; j < a.Length; j++)
                    {
                        var index = i + a[j];
                        if (index <= t)
                        {
                            x[index] = true;
                        }
                    }
                }                
            }

            return x[t];
        }

        public static List<int>? howSumTabular(int t, params int[] a)
        {
            var x = new List<int>?[t + 1];

            x[0] = new List<int>();

            for (int i = 0; i <= t; i++)
            {
                if (x[i] != null)
                {
                    for (int j = 0; j < a.Length; j++)
                    {
                        var index = i + a[j];
                        if (index <= t)
                        {
                            var c = new List<int>(x[i]);
                            c.Add(a[j]);

                            if (x[index] == null)
                            {
                                x[index] = c;
                            }
                        }
                    }
                }
            }

            return x[t];
        }

        public static List<int>? bestSumTabular(int t, params int[] a)
        {
            var x = new List<int>?[t + 1];

            x[0] = new List<int>();

            for (int i = 0; i <= t; i++)
            {
                if (x[i] != null)
                {
                    for (int j = 0; j < a.Length; j++)
                    {
                        var index = i + a[j];
                        if (index <= t)
                        {
                            var c = new List<int>(x[i]);
                            c.Add(a[j]);
                            if (x[index] == null)
                            {
                                x[index] = c;
                            }
                            else
                            {
                                if(c.Count < x[index].Count)
                                {
                                    x[index] = c;
                                }
                            }                            
                        }
                    }
                }
            }

            return x[t];
        }

        public static Dictionary<long, long> map = new Dictionary<long, long>();

        public static List<long> items = new List<long>();

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
            while(n > Math.Pow(2, x))
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

        public static Dictionary<long, Dictionary<long, bool>> evalMap = new Dictionary<long, Dictionary<long, bool>>();

        public static bool Eval(long val, long n)
        {
            if (evalMap.ContainsKey(n) && evalMap[n].ContainsKey(val))
            {
                return evalMap[n][val];
            }

            long t = 0;
            long p = 0;

            while(val > 0)
            {
                var digit = val % 10;
                t += digit * (long)Math.Pow(2, p);
                p++;
                val /= 10;
            }

            if(t == n)
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
