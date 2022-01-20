using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview
{
    public class ArrayQns
    {
        public static int FirstMissingPositive(int[] nums)
        {
            int missing = 1;

            int[] val = new int[nums.Length * 2];

            int i = 0;
            int min = int.MaxValue;
            while (i < nums.Length)
            {
                if (nums[i] < min)
                {
                    min = nums[i];
                }
                i++;
            }

            if (min > nums.Length)
            {
                return 1;
            }

            i = 0;
            val[0] = -1;
            while (i < nums.Length)
            {
                if (nums[i] > 0 && nums[i] < val.Length)
                {
                    var value = nums[i];
                    val[value] = -1;
                }
                i++;
            }

            i = 0;
            while (i < val.Length)
            {
                if (val[i] == 0)
                {
                    missing = i;
                    break;
                }
                i++;
            }

            if(i == val.Length)
            {
                missing = nums.Length + 1;
            }

            return missing;
        }

        static Dictionary<char, char[]> d = new Dictionary<char, char[]>(){
        {'2', new char[] {'a','b','c'}},
        {'3', new char[] {'d','e','f'}},
        {'4', new char[] {'g','h','i'}},
        {'5', new char[] {'j','k','l'}},
        {'6', new char[] {'m','n','o'}},
        {'7', new char[] {'p','q','r', 's'}},
        {'8', new char[] {'t','u','v'}},
        {'9', new char[] {'w','x','y','z'}}
    };

        static IList<string> x;

        public static IList<string> LetterCombinations(string digits)
        {
            x = new List<string>();
            Build(new StringBuilder(), digits, 0);
            return x;
        }

        private static void Build(StringBuilder s, string digits, int i)
        {
            if (s.Length == digits.Length)
            {
                x.Add(s.ToString());
                return;
            }

            var set = d[digits[i]];
            int j = 0;
            while (j < set.Length)
            {
                s.Append(set[j]);
                Build(s, digits, i + 1);
                s.Length--;
                j++;
            }
        }
        static List<string> s;
        public static IList<string> GenerateParenthesis(int n)
        {
            s = new();
            Gen(new StringBuilder(), n, 0, 0);
            return s;
        }

        private static void Gen(StringBuilder sb, int n, int o, int c)
        {
            if (c == n)
            {
                s.Add(sb.ToString());
                return;
            }

            if (o > c)
            {
                sb.Append(")");
                Gen(sb, n, o, c + 1);
                sb.Length--;
            }

            if (o < n)
            {
                sb.Append("(");
                Gen(sb, n, o + 1, c);
                sb.Length--;
            }
        }

        public static int[] SortArray(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return nums;

            return MergeSort(nums);
        }

        private static int[] MergeSort(int[] nums)
        {
            if (nums.Length < 2)
                return nums;

            int mid = nums.Length / 2;
            int[] l = new int[mid];
            int i = 0;
            while (i < mid)
            {
                l[i] = nums[i];
                i++;
            }

            l = MergeSort(l);
            int[] r = new int[nums.Length - mid];
            int j = 0;
            while (i < nums.Length)
            {
                r[j] = nums[i];
                i++;
                j++;
            }
            r = MergeSort(r);

            return Merge(l, r);
        }

        private static int[] Merge(int[] l, int[] r)
        {
            int[] x = new int[l.Length + r.Length];

            int i = 0;
            int j = 0;
            int k = 0;
            while (i < l.Length && j < r.Length)
            {
                if (l[i] <= r[j])
                {
                    x[k] = l[i];
                    i++;
                }
                else
                {
                    x[k] = r[j];
                    j++;
                }
                k++;
            }

            while (i < l.Length)
            {
                x[k] = l[i];
                i++;
                k++;
            }

            while (j < r.Length)
            {
                x[k] = r[j];
                j++;
                k++;
            }

            return x;
        }

        public static IList<int> FindDisappearedNumbers(params int[] nums)
        {
            HashSet<int> h = new();
            List<int> x = new();
            int i = 0;
            while (i < nums.Length)
            {
                h.Add(nums[i]);
                i++;
            }

            i = 1;
            while (i <= nums.Length)
            {
                if (!h.Contains(i))
                    x.Add(i);
                i++;
            }

            return x;
        }

        public static int PotHoles(string L1, string L2)
        {
            return Math.Max(PotHoles(L1, L2, 0, true), PotHoles(L1, L2, 0, false));
        }

        public static int PotHoles(string L1, string L2, int i, bool lane1)
        {
            if (i == L1.Length)
                return 0;

            if (lane1)
            {
                if (L2[i] == 'x')
                {
                    return 1 + PotHoles(L1, L2, i + 1, true);
                }
                else
                {
                    return PotHoles(L1, L2, i + 1, false);
                }
            }
            else
            {

                if (L1[i] == 'x')
                {
                    return 1 + PotHoles(L1, L2, i + 1, false);
                }
                else
                {
                    return PotHoles(L1, L2, i + 1, true);
                }
            }
        }

        public static bool IsValidBrackets(string s)
        {
            Dictionary<char, char> d =
                new Dictionary<char, char>
            {
                {'(',')'},
                {'{','}'},
                {'[',']'}
            };

            Stack<char> st = new();

            if (s.Length == 0)
                return true;

            if (s.Length % 2 == 1)
                return false;

            int i = 0;
            while (i < s.Length)
            {
                if (d.ContainsKey(s[i]))
                    st.Push(s[i]);
                else
                {
                    if (st.Count == 0)
                        return false;
                    char p = st.Pop();
                    if (s[i] != d[p])
                        return false;
                }

                i++;
            }

            return st.Count == 0;
        }

        public static string LongestCommonPrefix(params string[] strs)
        {
            StringBuilder s = new();

            if (strs.Length == 0)
                return "";

            if (strs.Length == 1)
                return strs[0];

            int i = 0;
            int j = 0;
            while (true)
            {
                while (j < strs.Length)
                {
                    if (strs[j].Length == i)
                        return s.ToString();

                    if (strs[0][i] != strs[j][i])
                        return s.ToString();

                    j++;
                }
                j = 1;
                s.Append(strs[0][i]);
                i++;
            }
        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle == string.Empty)
                return 0;

            int i = 0;
            int j = 0;
            int index = -1;
            while (i < haystack.Length)
            {
                if (j == needle.Length)
                    break;
                if (haystack[i] == needle[j])
                {
                    if (j == 0)
                        index = i;
                    j++;
                }
                else
                {
                    if (j > 0 && index > -1)
                    {
                        i = index;
                    }
                    j = 0;
                }
                i++;
            }

            if (j == needle.Length)
                return index;

            return -1;
        }

        public static int MaximumSizeSubsetWithGivenSum(int sum, params int[] a)
        {
            var res = new List<List<int>>();
            var curr = new List<int>();
            MaximumSizeSubsetWithGivenSum(sum, 0, res, curr, a);
            return res.Max(x => x.Count);
        }

        private static void MaximumSizeSubsetWithGivenSum(
            int sum, 
            int i, 
            List<List<int>> res,
            List<int> curr,
            params int[] a)
        {
            if (sum < 0 || i >= a.Length)
                return;

            if (sum == 0)
            {
                res.Add(curr);
                return;
            }

            for (int j = i; j < a.Length; j++)
            {
                var newCurr = new List<int>(curr);
                newCurr.Add(a[j]);
                MaximumSizeSubsetWithGivenSum(sum - a[j], j + 1, res, newCurr, a);
            }
        }

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

        public static List<int> howSumTabular(int t, params int[] a)
        {
            var x = new List<int>[t + 1];

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

        public static List<int> bestSumTabular(int t, params int[] a)
        {
            var x = new List<int>[t + 1];

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
    }
}
