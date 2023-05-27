using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class HardToVisualize
    {
        public int MinExtraChar2(string s, string[] dictionary)
        {
            Array.Sort(dictionary, (x, y) => y.Length.CompareTo(x.Length));
            Console.WriteLine(dictionary[0]);

            foreach (var z in dictionary)
            {
                s = s.Replace(z, "");
            }

            return s.Length;
        }

        private static string ReplaceFirst(string text, string item)
        {
            int pos = text.IndexOf(item);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + text.Substring(pos + item.Length);
        }
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            char[] w1 = word1.ToCharArray();
            char[] w2 = word2.ToCharArray();
            Array.Sort(w1);
            Array.Sort(w2);

            int count = 1;
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            for (int i = 0; i < w1.Length - 1; i++)
            {
                if (!word2.Contains(w1[i].ToString()))
                {
                    return false;
                }
                if (w1[i] == w1[i + 1])
                {
                    count++;
                }
                else
                {
                    list1.Add(count);
                    count = 1;
                }
            }
            list1.Add(count);
            count = 1;

            for (int i = 0; i < w2.Length - 1; i++)
            {
                if (w2[i] == w2[i + 1])
                {
                    count++;
                }
                else
                {
                    list2.Add(count);
                    count = 1;
                }
            }
            list2.Add(count);

            for (int i = 0; i < list1.Count; i++)
            {
                if (list2.Contains(list1[i]))
                {
                    list2.Remove(list1[i]);
                }
                else
                {
                    return false;
                }
            }

            foreach (var z in word1)
            {
                if (!word2.Contains(z))
                    return false;
            }

            return true;
        }

        public int MaxOperations(int[] nums, int k)
        {
            Dictionary<int, int> map = new();

            int ans = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(k - nums[i]) && map[k - nums[i]] > 0)
                {
                    ans++;
                    map[k - nums[i]] = map[k - nums[i]] - 1;
                }
                else
                {
                    if (map.ContainsKey(nums[i]))
                        map[nums[i]] = map[nums[i]] + 1;
                    else
                        map[nums[i]] = 1;
                }
            }

            return ans;
        }

        public int MaxOperations2(int[] nums, int k)
        {
            Dictionary<int, int> d = new();
            foreach (var x in nums)
            {
                if (x < k)
                {
                    if (!d.ContainsKey(x))
                        d.Add(x, 1);
                    else
                        d[x]++;
                }
            }

            int r = 0;
            int l = 0;
            int h = 1;
            while (l < h && d.Count > 0)
            {
                l = d.Keys.Min();
                h = d.Keys.Max();
                Console.WriteLine(l + " " + h);
                int x = k - h;
                //Console.WriteLine(x);
                while (d.ContainsKey(l) && l < x)
                {
                    d.Remove(l);
                    if (d.Count == 0)
                        break;
                    l = d.Keys.Min();
                }
                //Console.WriteLine(" " + d.Count);
                l = x;
                while (d.ContainsKey(l) && d[l] > 0 && d[h] > 0 && (l != h || d[l] > 1))
                {
                    //Console.WriteLine(true);
                    r++;
                    d[l]--;
                    d[h]--;
                }
                if (d.ContainsKey(l) && d[l] == 0)
                    d.Remove(l);
                if (d.ContainsKey(h) && d[h] == 0)
                    d.Remove(h);
                d.Remove(h);
            }

            return r;
        }

        public int MaxOperations3(int[] nums, int k)
        {
            Array.Sort(nums);
            int r = 0;
            int i = 0;
            int j = nums.Length - 1;
            while (j > -1 && nums[j] >= k)
                j--;

            while (i < j)
            {
                var x = k - nums[j];
                //Console.WriteLine(nums[i]  + "-" + nums[j] + " " + x);
                if (nums[i] == x)
                {
                    //Console.WriteLine(i + " " + j);
                    r++;
                    i++;
                    j--;
                    continue;
                }
                while (i < nums.Length && nums[i] < x)
                    i++;
                //Console.WriteLine(nums[i]  + "-" + nums[j]);
                if (i < nums.Length && nums[i] == x)
                {
                    //Console.WriteLine(i + " " + j);
                    r++;
                    i++;
                    j--;
                    continue;
                }
                else
                    j--;
            }

            return r;
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            int t = 0;
            int b = matrix.Length - 1;
            int l = 0;
            int r = matrix[0].Length - 1;
            int s = matrix.Length * matrix[0].Length;
            IList<int> list = new List<int>();

            while (list.Count < s)
            {
                for (int i = l; i <= r && list.Count < s; i++)
                    list.Add(matrix[t][i]);
                t++;
                for (int i = t; i <= b && list.Count < s; i++)
                    list.Add(matrix[i][r]);
                r--;
                for (int i = r; i >= l && list.Count < s; i--)
                    list.Add(matrix[b][i]);
                b--;
                for (int i = b; i >= t && list.Count < s; i--)
                    list.Add(matrix[i][l]);
                l++;
            }

            return list;
        }

        public int SumOddLengthSubarrays(int[] arr)
        {
            int sum = 0;

            int l = arr.Length;

            for (int i = 0; i < l; i++)
            {
                for (int j = i; j < l; j += 2)
                {
                    for (int k = i; k <= j; k++)
                    {
                        sum += arr[k];
                    }
                }
            }

            return sum;
        }

        public int[][] LargestLocal(int[][] grid)
        {
            int rows = grid.Length - 2;
            int cols = grid[0].Length - 2;

            int[][] local = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                local[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    local[i][j] = FindMax(grid, i, j);
                }
            }

            return local;
        }

        private int FindMax(int[][] grid, int x, int y)
        {
            int max = 0;
            int rows = x + 3;
            int cols = y + 3;

            for (int i = x; i < rows; i++)
            {
                for (int j = y; j < cols; j++)
                {
                    if (grid[i][j] > max) max = grid[i][j];
                }
            }

            return max;
        }
    }
}
