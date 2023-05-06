using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Interview.ArrayQns;

namespace Interview
{
    public class ArrayQns
    {
        public class EnumeratorConfig
        {
            public int MinLength { get; set; } = -1;
            public int MaxLength { get; set; } = -1;
            public bool StartWithCapitalLetter { get; set; }
            public bool StartWithDigit { get; set; }
        }

        public class CustomStringEnumerator : IEnumerable<string>
        {
            List<string> list;


            public CustomStringEnumerator(IEnumerable<string> collection, EnumeratorConfig config)
            {
                if (collection == null || config == null)
                    throw new ArgumentNullException();

                list = new List<string>(collection);
                list = list.Where(x =>
                 (config.MinLength < 1 || (x != null && x.Length >= config.MinLength))
                 &&
                 (config.MaxLength < 0 || (x == null || x.Length <= config.MaxLength))
                 &&
                 (!config.StartWithCapitalLetter || (!string.IsNullOrEmpty(x) && x[0] >= 'A' && x[0] <= 'Z'))
                 &&
                 (!config.StartWithDigit || (!string.IsNullOrEmpty(x) && x[0] >= '0' && x[0] <= '9')))
                 .ToList();
            }

            public IEnumerator<string> GetEnumerator()
            {
                return list.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)list;
            }
        }
        public int RoadFuel(int[] A, int[] B)
        {
            var d = new Dictionary<int, List<int>>();
            int fuel = 0;

            int j = 0;
            d[0] = new List<int>();
            foreach (var i in A)
            {
                if (!d.ContainsKey(i))
                    d[i] = new List<int>();
                if (!d.ContainsKey(B[j]))
                    d[B[j]] = new List<int>();
                d[i].Add(B[j]);
                d[B[j]].Add(i);

                j++;
            }

            List<int> visited = new List<int>();
            BackTrackRoadFuel(ref fuel, d, 0, 0, 0, visited, 1);

            return fuel;
        }

        private void BackTrackRoadFuel(ref int fuel, Dictionary<int, List<int>> d, int currDest, int currFuel, int pass, List<int> visited, int level)
        {
            //Console.WriteLine("before currFuel " + currFuel);
            currFuel = ((currFuel * level) + 1) * (pass > 5 ? (pass / 5) + 1 : 1);
            if (visited.Contains(currDest))
                return;
            visited.Add(currDest);
            if (d.ContainsKey(currDest))
            {
                //Console.WriteLine("From " + currDest);
                //Console.WriteLine("From " + currDest + " " + d[currDest].Count);
                foreach (var dest in d[currDest])
                {
                    if (dest == 0 || visited.Contains(dest))
                        continue;
                    //Console.WriteLine("To " + dest);
                    //Console.WriteLine("currFuel " + currFuel);
                    fuel = Math.Max(fuel, currFuel);
                    BackTrackRoadFuel(ref fuel, d, dest, currFuel, pass + 1, visited, level + 1);
                }
            }
        }


        const string vowels = "aeiou";

        public int MaxVowels(string s, int k)
        {
            int v = 0;
            int max = 0;
            int i = 0;
            int curr = k;

            while (i < s.Length)
            {
                if (curr == 0)
                {
                    if (vowels.Contains(s[i - k]))
                    {
                        v--;
                    }
                    curr++;
                }

                if (vowels.Contains(s[i]))
                {
                    v++;
                }

                max = Math.Max(max, v);
                curr--;
                i++;
            }

            return max;
        }

        public int BalancedStringSplit(string s)
        {
            ushort count = 0, r = 0, l = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'R')
                {
                    r++;
                }
                else
                {
                    l++;
                }
                if (r == l)
                {
                    count++;
                    r = 0; l = 0;
                }
            }

            return count;
        }

        public int BalancedStringSplit2(string s)
        {
            int count = 0;

            int i = 1;
            int limit = -1;
            while (i < s.Length)
            {
                Search(ref count, s, ref i, ref limit);
            }

            return count;
        }

        private void Search(ref int count, string s, ref int i, ref int limit)
        {
            int j = i - 1;
            int k = i;
            int l = 0;
            int r = 0;
            int oldLimit = limit;

            var l1 = l;
            var r1 = r;
            //Console.WriteLine(oldLimit + "oldLimit");
            while (j > oldLimit && k < s.Length)
            {
                l1 = s[j] == 'L' ? l1 + 1 : l1;
                l1 = s[k] == 'L' ? l1 + 1 : l1;
                r1 = s[j] == 'R' ? r1 + 1 : r1;
                r1 = s[k] == 'R' ? r1 + 1 : r1;

                //Console.WriteLine(l1 + "lcheck" + j);
                //Console.WriteLine(r1 + "rcheck" + k);
                if (l1 == r1)
                {
                    l = l1;
                    r = r1;
                    //Console.WriteLine(i + "more");
                    if (j == oldLimit + 1 && l > 0)
                    {
                        limit = k;
                        i = k + 1;
                    }
                }
                j--;
                k++;
            }

            if (limit > oldLimit)
            {
                count++;
                //Console.WriteLine("found");
            }
            i++;
            //Console.WriteLine(i+ "i");
            //Console.WriteLine(count);
            //Console.WriteLine("limit" + limit);
        }

        public static int InviteFriends(int n, int[] arr, int[] brr)
        {
            int max = 0;

            InviteFriendsBackTrack(ref max, n, new List<int>(), int.MaxValue, int.MaxValue, arr, brr);

            return max;
        }

        private static void InviteFriendsBackTrack(ref int max, int n, List<int> c, int p, int r, int[] arr, int[] brr)
        {
            for (int i = 0; i < n; i++)
            {
                int currP = c.Count(x => x < i);
                int currR = c.Count(x => x > i);
                if (!c.Contains(i) && p > currP && r > currR && arr[i] >= currP && brr[i] >= currR)
                {
                    c.Add(i);
                    max = Math.Max(max, c.Count);
                    InviteFriendsBackTrack(ref max, n, new List<int>(c), Math.Min(p, arr[i]), Math.Min(r, brr[i]), arr, brr);
                    c.Remove(i);
                }
            }
        }

        public string SmallestBeautifulString(string s, int k)
        {
            int n = s.Length;
            int pos = -1;
            var c = s.ToCharArray();

            for (int i = n - 1; i >= 0 && pos < 0; i--)
            {
                int cur = c[i] - 'a';
                cur++;
                while (cur < k && pos < 0)
                {
                    bool isPal = false;
                    if (i - 1 >= 0 && (c[i - 1] - 'a') == cur) isPal = true;
                    if (i - 2 >= 0 && (c[i - 2] - 'a') == cur) isPal = true;
                    if (!isPal)
                    {
                        c[i] = (char)(cur + 'a');
                        pos = i;
                    }
                    cur++;
                }
            }

            if (pos < 0) return "";

            for (int i = pos + 1; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    bool isPal = false;
                    if (i - 1 >= 0 && (c[i - 1] - 'a') == j) isPal = true;
                    if (i - 2 >= 0 && (c[i - 2] - 'a') == j) isPal = true;
                    if (!isPal)
                    {
                        c[i] = (char)(j + 'a');
                        break;
                    }
                }
            }

            return new string(c);
        }

        public int MinimumCost(int[] start, int[] target, int[][] specialRoads)
        {
            int n = specialRoads.Length;

            List<int> d = new List<int>(new int[n]);
            for (int i = 0; i < n; i++)
            {
                d[i] = int.MaxValue;
            }

            var pq = new PriorityQueue<(int, int), int>();
            for (int i = 0; i < n; i++)
            {
                d[i] = Math.Abs(start[0] - specialRoads[i][0]) + Math.Abs(start[1] - specialRoads[i][1]) + specialRoads[i][4];
                pq.Enqueue((d[i], i), d[i]);
            }

            int ans = Math.Abs(start[0] - target[0]) + Math.Abs(start[1] - target[1]);

            while (pq.Count > 0)
            {
                var (d_c, c) = pq.Dequeue();

                if (d_c != d[c]) continue;

                ans = Math.Min(ans, d_c + Math.Abs(target[0] - specialRoads[c][2]) + Math.Abs(target[1] - specialRoads[c][3]));

                for (int nxt = 0; nxt < n; nxt++)
                {
                    int w = Math.Abs(specialRoads[c][2] - specialRoads[nxt][0]) + Math.Abs(specialRoads[c][3] - specialRoads[nxt][1]) + specialRoads[nxt][4];
                    if (d_c + w < d[nxt])
                    {
                        d[nxt] = d_c + w;
                        pq.Enqueue((d[nxt], nxt), d[nxt]);
                    }
                }
            }

            return ans;
        }

        public int FirstCompleteIndex(int[] arr, int[][] mat)
        {
            Dictionary<int, int[]> d = new();
            int m = mat.Length;
            int n = mat[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    d.Add(mat[i][j], new int[] { i, j });
                }
            }
            int[] a = new int[m];
            int[] b = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                int[] c = d[arr[i]];
                a[c[0]]++;
                b[c[1]]++;
                if (a[c[0]] == n || b[c[1]] == m)
                {
                    return i;
                }
            }
            return -1;
        }

        public long CountOperationsToEmptyArray(int[] nums)
        {
            Dictionary<int, int> pos = new();
            int n = nums.Length, p = 0;
            long res = n;
            for (int i = 0; i < n; ++i)
                pos[nums[i]] = i;
            Array.Sort(nums);
            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                    p = pos[nums[i - 1]];
                if (pos[nums[i]] < p)
                    res += n - i;
            }
            return res;
        }

        public int[] GetSubarrayBeauty(int[] nums, int k, int x)
        {
            int[] counter = new int[50], ans = new int[nums.Length - k + 1]; ;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0) counter[nums[i] + 50]++;
                if (i - k >= 0 && nums[i - k] < 0) counter[nums[i - k] + 50]--;
                if (i - k + 1 < 0) continue;
                int count = 0;
                for (int j = 0; j < 50; j++)
                {
                    count += counter[j];
                    if (count >= x)
                    {
                        ans[i - k + 1] = j - 50;
                        break;
                    }
                }
            }
            return ans;
        }

        public int[] GetSubarrayBeauty2(int[] nums, int k, int x)
        {
            int[] r = new int[nums.Length - k + 1];

            int i = 0;
            LinkedList<int> min = new();
            while (i < nums.Length)
            {
                Console.WriteLine("i" + i);
                if (nums[i] < 0)
                {
                    if (min.Count == 0 || nums[i] < min.First.Value)
                    {
                        min.AddFirst(nums[i]);
                        Console.WriteLine("AF" + nums[i]);
                    }
                    else
                    {
                        if (min.Last.Value > nums[i])
                        {
                            var node = min.First;
                            while (node.Value < nums[i])
                            {
                                node = node.Next;
                            }
                            min.AddBefore(node, nums[i]);
                            Console.WriteLine("IB" + node.Value + "," + nums[i]);
                        }
                        else
                        {
                            min.AddLast(nums[i]);
                            Console.WriteLine("AL" + nums[i]);
                        }
                    }
                }
                if (i - k > -2)
                {
                    r[i - k + 1] = 0;
                    if (min.Count > 0)
                    {
                        var node = min.First;
                        int c = x;
                        while (node != null && c > 1)
                        {
                            node = node.Next;
                            c--;
                        }
                        if (node != null && node.Value < 0)
                            r[i - k + 1] = node.Value;
                    }
                    Console.WriteLine("RES" + r[i - k + 1]);
                    if (min.Contains(nums[i - k + 1]))
                    {
                        min.Remove(nums[i - k + 1]);
                        Console.WriteLine("R" + nums[i - k + 1]);
                    }
                }

                i++;
            }
            Console.WriteLine();
            return r;
        }

        public int MinOperations(int[] nums)
        {
            int n = nums.Length;
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 1)
                {
                    c++;
                }
            }
            if (c > 0)
            {
                return n - c;
            }
            int ans = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int num = nums[i];
                for (int j = i + 1; j < n; j++)
                {
                    num = GetGcd(num, nums[j]);
                    if (num == 1)
                    {
                        ans = Math.Min(ans, j - i);
                        break;
                    }
                }
                if (num != 1)
                {
                    break;
                }
            }
            if (ans == int.MaxValue)
            {
                return -1;
            }
            return n - 1 + ans;
        }

        private int GetGcd(int a, int b)
        {
            if (a == 1 || b == 1)
                return 1;
            return (int)BigInteger.GreatestCommonDivisor(a, b);
        }

        public int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
        {
            if (n < 1 || minProfit < 0 || group == null || profit == null || group.Length == 0 || group.Length != profit.Length)
            {
                return 0;
            }

            //PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
            //int i = 0;
            //while (i < group.Length)
            //{
            //    queue.Enqueue(i, profit[i]);
            //    i++;
            //}

            //List<int> ordered = new List<int>();
            //int totalProfit = 0;

            //while (queue.Count > 0)
            //{
            //    var index = queue.Dequeue();
            //    ordered.Add(index);
            //    totalProfit += profit[index];
            //}

            //if (totalProfit < minProfit)
            //{
            //    return 0;
            //}

            var result = GetAllPermutations(n, Enumerable.Range(0, group.Length).ToList(), group, profit, minProfit);

            //result.ToList().ForEach(p => { Console.WriteLine(p); });

            return (int)(result.Count % (Math.Pow(10, 9) + 7));
        }

        public HashSet<string> GetAllPermutations(int n, List<int> numbers, int[] group, int[] profits, int minProfit)
        {
            HashSet<string> results = new HashSet<string>();

            if (numbers.Count() > 0 && n > 0)
            {
                int profit = 0;
                int i = 0;
                int currentGroup = n;
                bool possible = false;
                while (profit <= minProfit && i < numbers.Count && currentGroup >= group[numbers[i]])
                {
                    profit += profits[numbers[i]];
                    currentGroup -= group[numbers[i]];
                    possible = true;
                    i++;
                }

                int currentCost = n - currentGroup;
                int currentAvailable = n;
                if (possible && profit >= minProfit)
                {
                    while (currentAvailable >= currentCost)
                    {
                        currentAvailable -= currentCost;
                        results.Add(string.Join(",", new SortedSet<int>(numbers)));
                    }
                }
            }

            for (int i = 0; i <= numbers.Count() - 1; i++)
            {
                List<int> newNumbers = new List<int>(numbers);
                newNumbers.RemoveAt(i);
                results.UnionWith(GetAllPermutations(n, newNumbers, group, profits, minProfit));
            }

            return results;
        }

        public void CountCombinations(ref long result, List<int> ordered)
        {
            if (ordered.Count == 0)
                return;
            int i = 0;
            List<int> excluded = new List<int>();
            while (i < ordered.Count)
            {
                excluded.Add(ordered[i]);
                result++;
                i++;
            }
            var newList = ordered.Except(excluded).ToList();
            CountCombinations(ref result, newList);
        }

        public int[] MinReverseOperations(int n, int p, int[] banned, int k)
        {
            // Create a boolean array to mark banned positions
            bool[] isBanned = new bool[n];
            foreach (int i in banned)
            {
                isBanned[i] = true;
            }

            // Create a distance array to track the minimum number of operations required to reach each position
            int[] dist = Enumerable.Repeat(-1, n).ToArray();
            dist[p] = 0;

            if (k > n)
            {
                return dist;
            }

            var cache = new HashSet<int>();
            cache.Add(p);

            // Create a queue to hold positions that need to be explored
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(p);

            // Perform breadth-first search to explore all possible positions
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();

                for (int i = curr - k; i < curr + k; i++)
                {
                    int left = i;
                    int right = i + k - 1;
                    if (curr <= right && curr >= left)
                    {
                        RotateMinReverseOperations(curr, left, right, queue, cache, dist, isBanned);
                    }
                }
            }

            return dist;
        }

        private void RotateMinReverseOperations(int curr, int left, int right, Queue<int> queue, HashSet<int> cache, int[] dist, bool[] isBanned)
        {
            int newLocation = right - curr + left;

            // Check if the move is valid
            if (left > -1 && left < dist.Length && right > -1 && right < dist.Length && !isBanned[newLocation])
            {
                // Calculate the new distance
                int newDist = dist[curr] + 1;

                // Update the distance if it's shorter than the current distance
                if (dist[newLocation] == -1 || newDist < dist[newLocation])
                {
                    dist[newLocation] = newDist;

                    if (cache.Contains(newLocation))
                        return;

                    cache.Add(newLocation);

                    queue.Enqueue(newLocation);
                }
            }
        }

        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            bool[] result = new bool[candies.Length];

            if (candies != null && candies.Length > 0)
            {
                int max = candies.Max();
                int i = 0;
                while (i < candies.Length)
                {
                    if (candies[i] + extraCandies > max)
                    {
                        result[i] = true;
                    }
                    i++;
                }
            }

            return result;
        }

        public int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            int result = 0;

            Dictionary<(int, int), int> cache = new();

            result = BacktrackMaxValueOfCoins(piles, 0, k, cache);

            return result;
        }

        private static int BacktrackMaxValueOfCoins(IList<IList<int>> piles, int group, int k, Dictionary<(int, int), int> cache)
        {
            if (group == piles.Count)
                return 0;

            var key = (group, k);

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            cache[key] = BacktrackMaxValueOfCoins(piles, group + 1, k, cache);

            int current = 0;

            int len = Math.Min(piles[group].Count, k);

            for (int i = 0; i < len; i++)
            {
                current += piles[group][i];
                int next = BacktrackMaxValueOfCoins(piles, group + 1, k - i - 1, cache);
                cache[key] = Math.Max(cache[key], current + next);
            }

            return cache[key];
        }

        public int MaxValueOfCoinsV2(IList<IList<int>> piles, int k)
        {
            int result = 0;

            BacktrackMaxValueOfCoinsV2(piles, 0, 0, k, k, 0, ref result, 0);

            return result;
        }

        private static void BacktrackMaxValueOfCoinsV2(IList<IList<int>> piles, int group, int start, int maxCount, int k, int currentValue, ref int maxCoinValue, int selected)
        {
            if (k < 0 || selected > maxCount)
                return;

            if (k == 0)
            {
                maxCoinValue = Math.Max(maxCoinValue, currentValue);
                return;
            }

            for (int j = group; j < piles.Count; j++)
            {
                if (start < piles[j].Count)
                {
                    BacktrackMaxValueOfCoinsV2(piles, j, start + 1, maxCount, k - 1, currentValue + piles[j][start], ref maxCoinValue, selected + 1);
                }
                start = 0;
            }
        }

        public int MaxValueOfCoinsV1(IList<IList<int>> piles, int k)
        {
            int result = 0;

            List<PriorityQueue<(int, int), int>> priorityQueues = new();

            List<int> sums = new();

            List<int> indexes = new();

            foreach (IList<int> p in piles)
            {
                var q = new PriorityQueue<(int, int), int>();
                priorityQueues.Add(q);
                indexes.Add(0);
                sums.Add(0);
                for (int i = 0; i < p.Count; i++)
                {
                    q.Enqueue((p[i], i), -(p[i] + i));
                    sums[sums.Count - 1] = sums[sums.Count - 1] + p[i];
                }
            }

            while (k > 0)
            {
                var max = int.MinValue;
                int i = -1;
                int c = 0;

                var choice = new PriorityQueue<int, int>();

                foreach (var p in priorityQueues)
                {
                    if (p.Count > 0)
                    {
                        choice.Enqueue(c, -(sums[c]));
                    }
                    c++;
                }
                i = choice.Dequeue();
                var set = priorityQueues[i].Peek();
                while (set.Item2 < indexes[i])
                {
                    i = choice.Dequeue();
                    set = priorityQueues[i].Peek();
                }
                max = set.Item1;

                var removed = new List<int>();
                while (indexes[i] < piles[i].Count && indexes[i] < set.Item2 && k > 0)
                {
                    result += piles[i][indexes[i]];
                    removed.Add(piles[i][indexes[i]]);
                    sums[i] -= piles[i][indexes[i]];
                    indexes[i]++;
                    k--;
                }

                if (k > 0 && indexes[i] < piles[i].Count)
                {
                    priorityQueues[i].Dequeue();
                    indexes[i]++;
                    result += max;
                    sums[i] -= max;
                    k--;
                }

                while (removed.Any() && removed.Contains(priorityQueues[i].Peek().Item1))
                {
                    int val = priorityQueues[i].Dequeue().Item1;
                    removed.Remove(val);
                }
            }

            return result;
        }

        public static IList<IList<int>> ParseNestedList(string s)
        {
            IList<IList<int>> r = new List<IList<int>>();
            r.Add(new List<int>());
            StringBuilder sb = new StringBuilder();
            s = s.Trim('[').Trim(']');
            foreach (char c in s.ToCharArray())
            {
                if (c == ']')
                {
                    r[r.Count - 1].Add(int.Parse(sb.ToString()));
                    sb.Length = 0;
                    r.Add(new List<int>());
                    continue;
                }
                if (c == '[')
                {
                    continue;
                }
                if (c == ',')
                {
                    if (sb.Length > 0)
                    {
                        r[r.Count - 1].Add(int.Parse(sb.ToString()));
                    }
                    sb.Length = 0;
                }
                else
                    sb.Append(c);
            }

            if (sb.Length > 0)
            {
                r[r.Count - 1].Add(int.Parse(sb.ToString()));
            }

            return r;
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if (gas == null || cost == null)
                return -1;

            if (gas.Length != cost.Length)
                return -1;

            int total = 0;
            int tank = 0;
            int start = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                int net = gas[i] - cost[i];
                total += net;
                tank += net;
                if (tank < 0)
                {
                    start = (i + 1) % gas.Length;
                    tank = 0;
                }
            }

            if (total >= 0)
                return start;

            return -1;
        }

        class sortHelper : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                if (a[0] == b[0])
                {
                    return a[1] - b[1];
                }
                return a[0] - b[0];
            }
        }

        public int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return intervals;

            List<int[]> res = new();

            Array.Sort(intervals, new sortHelper());

            Stack<int[]> stack = new();

            stack.Push(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {

                var top = (int[])stack.Peek();

                if (top[1] < intervals[i][0])
                    stack.Push(intervals[i]);
                else if (top[1] < intervals[i][1])
                {
                    top[1] = intervals[i][1];
                    stack.Pop();
                    stack.Push(top);
                }
            }

            while (stack.Count != 0)
            {
                res.Add(stack.Pop());
            }

            return res.ToArray();
        }

        public int Jump(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            Queue<(int, int, int)> q = new();
            q.Enqueue((0, nums[0], 0));
            while (q.Count > 0)
            {
                var x = q.Dequeue();
                if (x.Item1 == nums.Length - 1)
                    return x.Item3;
                int i = x.Item1 + 1;
                int max = x.Item1 + x.Item2;
                while (i <= max && i < nums.Length)
                {
                    q.Enqueue((i, nums[i], x.Item3 + 1));
                    i++;
                }
            }

            return -1;
        }

        public string Multiply(string num1, string num2)
        {
            StringBuilder res = new();

            if (num1 == "0" || num2 == "0")
                return "0";

            int r = 0;
            int q = 0;
            List<string> x = new();
            int c = 0;
            for (int i = num2.Length - 1; i > -1; i--)
            {
                res.Length = 0;
                int y = c;
                while (y > 0)
                {
                    res.Append("0");
                    y--;
                }
                for (int j = num1.Length - 1; j > -1; j--)
                {
                    int a = num2[i] - '0';
                    int b = num1[j] - '0';

                    int z = (a * b) + q;
                    r = z % 10;
                    q = z / 10;

                    res.Insert(0, r.ToString());
                }
                if (q > 0)
                {
                    res.Insert(0, q.ToString());
                    q = 0;
                }
                x.Add(res.ToString());
                c++;
            }

            if (q > 0)
            {
                res.Length = 0;
                int y = c;
                while (y > 0)
                {
                    res.Append("0");
                    y--;
                }
                res.Insert(0, q.ToString());
                x.Add(res.ToString());
            }

            return Add(x);
        }

        private string Add(List<string> s)
        {
            string a = s[s.Count - 1];

            int k = s.Count - 2;
            while (k > -1)
            {
                StringBuilder res = new();
                string b = s[k];
                int q = 0;
                int r = 0;
                int i = a.Length - 1;
                int j = b.Length - 1;
                while (i > -1 && j > -1)
                {
                    int x = a[i] - '0';
                    int y = b[j] - '0';

                    int c = (x + y) + q;
                    r = c % 10;
                    q = c / 10;

                    res.Insert(0, r.ToString());
                    i--;
                    j--;
                }
                while (i > -1)
                {
                    int x = a[i] - '0';
                    int c = x + q;
                    r = c % 10;
                    q = c / 10;
                    res.Insert(0, r.ToString());
                    i--;
                }
                while (j > -1)
                {
                    int x = b[j] - '0';
                    int c = x + q;
                    r = c % 10;
                    q = c / 10;
                    res.Insert(0, r.ToString());
                    j--;
                }
                if (q > 0)
                    res.Insert(0, q.ToString());
                a = res.ToString();
                k--;
            }

            return a;
        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> r = new List<IList<int>>();

            if (nums == null || nums.Length < 4)
                return r;

            HashSet<int> h = new();

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 3; i++)
            {
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    int low = j + 1;
                    int high = nums.Length - 1;
                    while (low < high)
                    {
                        int current = nums[low] + nums[high] + nums[i] + nums[j];
                        if (current == target)
                        {
                            List<int> x = new();
                            x.Add(nums[i]);
                            x.Add(nums[j]);
                            x.Add(nums[low]);
                            x.Add(nums[high]);
                            (int, int, int, int) item = new();
                            item.Item1 = x[0];
                            item.Item2 = x[1];
                            item.Item3 = x[2];
                            item.Item4 = x[3];
                            int hash = item.GetHashCode();
                            if (!h.Contains(hash))
                                r.Add(x);
                            h.Add(hash);
                            while (low < high && nums[low] == nums[low + 1])
                                low++;
                            while (low < high && nums[high] == nums[high - 1])
                                high--;
                            low++;
                            high--;
                        }
                        else if (current > target)
                        {
                            high--;
                        }
                        else
                        {
                            low++;
                        }
                    }
                }
            }

            return r;
        }

        public static int MaxArea(int[] height)
        {
            int max = 0;
            int i = 0;
            int j = height.Length - 1;
            while (i < j)
            {
                int l = height[i];
                int r = height[j];
                int len = j - i;
                int h = Math.Min(l, r);
                int area = h * len;
                max = Math.Max(max, area);

                if (l <= r)
                {
                    i++;
                }
                else
                    j--;
            }

            return max;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            int max = 0;

            HashSet<char> h;
            int i = 0;
            while (i < s.Length)
            {
                h = new();
                h.Add(s[i]);
                int j = i + 1;
                while (j < s.Length)
                {
                    if (h.Contains(s[j]))
                    {
                        max = Math.Max(max, h.Count);
                        break;
                    }
                    h.Add(s[j]);
                    j++;
                }
                i++;
            }

            return max;
        }

        static IList<IList<string>> r = new List<IList<string>>();

        public static IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            r.Clear();

            if (!wordList.Contains(endWord))
                return r;

            HashSet<string> h = new HashSet<string>(wordList);
            var x = new List<string>();
            x.Add(beginWord);
            Search(h, x, beginWord, endWord);
            return r;
        }

        private static void Search(HashSet<string> h, List<string> l, string c, string endWord)
        {
            if (r.Count > 0 && l.Count > r[0].Count)
                return;

            if (c == endWord)
            {
                l.Add(c);
                if (r.Count == 0 || l.Count == r[0].Count)
                    r.Add(l);
                return;
            }

            for (char i = 'a'; i <= 'z'; i++)
            {
                for (int j = 0; j < c.Length; j++)
                {
                    var x = c.ToCharArray();
                    x[j] = i;
                    var word = new string(x);
                    if (h.Contains(word))
                    {
                        var newh = new HashSet<string>(h);
                        newh.Remove(word);
                        var newl = new List<string>(l);
                        newl.Add(word);
                        Search(newh, newl, word, endWord);
                    }
                }
            }
        }

        public static bool IsNumber(string str)
        {
            str = str.Trim();

            if (str.Length == 0)
                return false;

            if (str.Length == 1 && !char.IsDigit(str[0]))
                return false;

            bool foundDot = str[0] == '.';
            bool foundDigit = char.IsDigit(str[0]);
            bool foundE = false;

            if (str[0] != '+' && str[0] != '-'
    && !foundDigit && !foundDot)
                return false;

            for (int i = 1; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]) && str[i] != 'e'
                    && str[i] != 'E'
                    && str[i] != '.'
                    && str[i] != '+'
                    && str[i] != '-')
                    return false;

                if (char.IsDigit(str[i]))
                    foundDigit = true;

                if (str[i] == '.')
                {
                    if (foundDot)
                        return false;

                    if (foundE)
                        return false;

                    foundDot = true;

                    if (!char.IsDigit(str[i - 1])
                       && (i + 1 == str.Length ||
                          (!char.IsDigit(str[i + 1])
                          && !"eE".Contains(str[i + 1]))))
                        return false;
                }

                if (str[i] == 'e' || str[i] == 'E')
                {
                    if (foundE)
                        return false;

                    foundE = true;

                    if (!foundDigit)
                        return false;
                    if (!char.IsDigit(str[i - 1])
                       && str[i - 1] != '.')
                        return false;

                    if (i + 1 == str.Length)
                        return false;

                    if (!char.IsDigit(str[i + 1]) && str[i + 1] != '+'
        && str[i + 1] != '-')
                        return false;
                }

                if (str[i] == '+' || str[i] == '-')
                {
                    if (str[i - 1] != 'e' && str[i - 1] != 'E')
                        return false;

                    if (i + 1 == str.Length)
                        return false;

                    if (!char.IsDigit(str[i + 1]))
                        return false;
                }
            }

            return true;
        }

        public static IList<int> FindSubstring(string s, string[] words)
        {
            List<int> r = new();

            int w = words[0].Length;

            int l = w * words.Length;

            if (s.Length < l)
                return r;

            Dictionary<string, int> d = new();

            int i = 0;
            while (i < words.Length)
            {
                if (d.ContainsKey(words[i]))
                {
                    d[words[i]] = d[words[i]] + 1;
                }
                else
                {
                    d.Add(words[i], 1);
                }
                i++;
            }

            i = 0;
            while (i + l - 1 < s.Length)
            {
                var temp = new Dictionary<string, int>(d);

                int j = i;
                int count = words.Length;
                while (j + w - 1 < s.Length)
                {
                    var x = s.Substring(j, w);

                    if (!d.ContainsKey(x) || temp[x] == 0)
                        break;

                    temp[x]--;
                    count--;
                    j = j + w;
                }

                if (count == 0)
                    r.Add(i);

                i++;
            }

            return r;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int i = 0;
            int j = 0;
            int count;
            int n = nums1.Length;
            int m = nums2.Length;
            int m1 = -1, m2 = -1;

            if ((m + n) % 2 == 1)
            {
                for (count = 0;
                    count <= (n + m) / 2;
                    count++)
                {
                    if (i != n && j != m)
                    {
                        m1 = (nums1[i] > nums2[j]) ?
                              nums2[j++] : nums1[i++];
                    }
                    else if (i < n)
                    {
                        m1 = nums1[i++];
                        i++;
                    }
                    else
                    {
                        m1 = nums2[j++];
                    }
                }
                return m1;
            }
            else
            {
                for (count = 0;
                    count <= (n + m) / 2;
                    count++)
                {
                    m2 = m1;
                    if (i != n && j != m)
                    {
                        m1 = (nums1[i] > nums2[j]) ?
                              nums2[j++] : nums1[i++];
                    }
                    else if (i < n)
                    {
                        m1 = nums1[i++];
                    }
                    else
                    {
                        m1 = nums2[j++];
                    }
                }
                return ((double)m1 + (double)m2) / 2;
            }
        }

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

            if (i == val.Length)
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

        static HashSet<string> h = new();
        public static int PotHoles2(string L1, string L2)
        {
            h = new();
            var x = PotHoles2(L1, L2, 0, true);
            h = new();
            var y = PotHoles2(L1, L2, 0, false);
            return Math.Max(x, y);
        }

        public static int PotHoles2(string L1, string L2, int i, bool lane1)
        {
            if (i < L1.Length)
            {
                if (lane1)
                {
                    if (L2[i] == 'x')
                    {
                        h.Add(1 + "," + i);
                        return 1 + PotHoles2(L1, L2, i + 1, true);
                    }
                    else
                    {
                        if (L1[i] == 'x')
                        {
                            if (i == 0 || !h.Contains("1," + (i - 1)))
                            {
                                h.Add(0 + "," + i);
                                return 1 + PotHoles2(L1, L2, i + 1, false);
                            }
                            else
                            {
                                return PotHoles2(L1, L2, i + 1, true);
                            }
                        }
                        else
                        {
                            return PotHoles2(L1, L2, i + 1, true);
                        }
                    }
                }
                else
                {
                    if (L1[i] == 'x')
                    {
                        h.Add(0 + "," + i);
                        return 1 + PotHoles2(L1, L2, i + 1, false);
                    }
                    else
                    {
                        if (L2[i] == 'x')
                        {
                            if (i == 0 || !h.Contains("0," + (i - 1)))
                            {
                                h.Add(1 + "," + i);
                                return 1 + PotHoles2(L1, L2, i + 1, false);
                            }
                            else
                            {
                                return PotHoles2(L1, L2, i + 1, true);
                            }
                        }
                        else
                        {
                            return PotHoles2(L1, L2, i + 1, true);
                        }
                    }
                }
                i++;
            }

            return 0;
        }

        //public static int PotHoles(string L1, string L2)
        //{
        //    return Math.Max(PotHoles(L1, L2, 0, true), PotHoles(L1, L2, 0, false));
        //}

        //public static int PotHoles(string L1, string L2, int i, bool lane1)
        //{
        //    if (i == L1.Length)
        //        return 0;

        //    if (lane1)
        //    {
        //        if (L2[i] == 'x')
        //        {
        //            return 1 + PotHoles(L1, L2, i + 1, true);
        //        }
        //        else
        //        {
        //            return PotHoles(L1, L2, i + 1, false);
        //        }
        //    }
        //    else
        //    {

        //        if (L1[i] == 'x')
        //        {
        //            return 1 + PotHoles(L1, L2, i + 1, false);
        //        }
        //        else
        //        {
        //            return PotHoles(L1, L2, i + 1, true);
        //        }
        //    }
        //}

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

            for (int i = 0; i < n; i++)
            {
                x[i + 1] += x[i];
                if (i + 2 <= n)
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
                                if (c.Count < x[index].Count)
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

        public bool Exist(char[][] board, string word)
        {
            if (board == null || board.Length == 0)
                return false;

            bool[][] v = new bool[board.Length][];
            int k = 0;
            while (k < board.Length)
            {
                v[k] = new bool[board[0].Length];
                k++;
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (Exist(board, word, v, i, j, 0))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Exist(char[][] board, string word, bool[][] v, int i, int j, int k)
        {
            if (k == word.Length)
                return true;

            if (i == -1 || i == board.Length)
                return false;

            if (j == -1 || j == board[0].Length)
                return false;

            if (v[i][j])
                return false;

            if (board[i][j] == word[k])
            {
                v[i][j] = true;
                var status = Exist(board, word, v, i + 1, j, k + 1);
                if (status)
                    return true;
                status = Exist(board, word, v, i - 1, j, k + 1);
                if (status)
                    return true;
                status = Exist(board, word, v, i, j + 1, k + 1);
                if (status)
                    return true;
                status = Exist(board, word, v, i, j - 1, k + 1);
                if (status)
                    return true;
                v[i][j] = false;
            }

            return false;
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            if (nums.Length < 2)
                return nums.Length;

            int l = 2;
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[l - 2] || nums[i] != nums[l - 1])
                {
                    nums[l] = nums[i];
                    l++;
                }
            }

            return l;
        }

        public bool Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return false;

            if (nums.Length == 1)
                return nums[0] == target;

            int i = 0;
            int j = nums.Length - 1;
            int p = 0;

            while (i < j)
            {
                int mid = (i + j) / 2;

                if (nums[i] == target)
                    return true;

                if (nums[j] == target)
                    return true;

                if (nums[mid] == target)
                    return true;

                if ((nums[i] == nums[mid])
                && (nums[j] == nums[mid]))
                {
                    i++;
                    j--;
                    continue;
                }

                if (mid > 0 && nums[mid] < nums[mid - 1])
                {
                    p = mid;
                    break;
                }

                if (mid < nums.Length - 1 && nums[mid] > nums[mid + 1])
                {
                    p = mid + 1;
                    break;
                }

                if (nums[mid] > nums[j])
                {
                    i = mid + 1;
                }
                else
                {
                    j = mid - 1;
                }
            }

            if (Array.BinarySearch(nums, p, nums.Length - p, target) > -1)
                return true;

            if (Array.BinarySearch(nums, 0, p, target) > -1)
                return true;

            return false;
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> r = new List<IList<int>>();

            Array.Sort(nums);
            Eval(r, new List<int>(), nums, 0);
            return r;
        }

        private void Eval(IList<IList<int>> r, List<int> x, int[] nums, int index)
        {
            r.Add(new List<int>(x));

            for (int i = index; i < nums.Length; i++)
            {
                if (i != index && nums[i] == nums[i - 1])
                    continue;
                x.Add(nums[i]);
                Eval(r, x, nums, i + 1);
                x.RemoveAt(x.Count - 1);
            }
        }

        public IList<string> RestoreIpAddresses(string s)
        {
            IList<string> r = new List<string>();

            if (s == null || s.Length < 4 || s.Length > 12)
                return r;

            Eval(r, new List<string>(), s, 0);
            return r;
        }

        private void Eval(IList<string> r, List<string> sets, string s, int index)
        {
            if (sets.Count == 4)
            {
                if (index == s.Length)
                    r.Add(string.Join('.', sets));
                return;
            }

            if (index >= s.Length)
                return;
            int len = Math.Min(3, s.Length - index);
            for (int i = len; i > 0; i--)
            {
                var x = s.Substring(index, i);
                var num = Convert.ToInt32(x);
                if (num < 256 && (x[0] != '0' || (num == 0 && x.Length == 1)))
                {
                    sets.Add(x);
                    Eval(r, sets, s, index + i);
                    sets.RemoveAt(sets.Count - 1);
                }
            }
        }

        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> r = new List<IList<string>>();
            if (s == null || s.Length == 0)
                return r;
            Eval(r, new List<string>(), 0, s);
            return r;
        }

        private void Eval(IList<IList<string>> r, List<string> set, int index, string s)
        {
            if (index == s.Length)
            {
                r.Add(new List<string>(set));
                return;
            }

            for (int i = index; i < s.Length; i++)
            {
                if (IsPalindrome(s, index, i))
                {
                    set.Add(s.Substring(index, i - index + 1));
                    Eval(r, set, i + 1, s);
                    set.RemoveAt(set.Count - 1);
                }
            }
        }

        private bool IsPalindrome(string s, int i, int j)
        {
            while (i <= j)
            {
                if (s[i] != s[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }


        public int LongestCommonSubsequence(string text1, string text2)
        {
            Dictionary<(int, int), int> d = new();
            return LongestCommonSubsequence(d, text1, text2, text1.Length - 1, text2.Length - 1);
        }

        private int LongestCommonSubsequence(Dictionary<(int, int), int> d, string a, string b, int i, int j)
        {
            if (d.ContainsKey((i, j)))
                return d[(i, j)];

            if (i == -1 || j == -1)
                return d[(i, j)] = 0;

            if (a[i] == b[j])
            {
                return d[(i, j)] = 1 + LongestCommonSubsequence(d, a, b, i - 1, j - 1);
            }
            else
            {
                return d[(i, j)] = Math.Max(LongestCommonSubsequence(d, a, b, i - 1, j),
                              LongestCommonSubsequence(d, a, b, i, j - 1));
            }
        }

        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return 1;

            int[] tail = new int[nums.Length];
            int len = 1;
            tail[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > tail[len - 1])
                {
                    tail[len] = nums[i];
                    len++;
                }
                else
                {
                    int idx = GetLowerBound(tail, nums[i], len);
                    tail[idx] = nums[i];
                }
            }

            return len;
        }

        private int GetLowerBound(int[] a, int t, int n)
        {
            int s = 0;
            int e = n - 1;

            while (s < e)
            {
                int mid = (s + e) / 2;

                if (t > a[mid])
                {
                    s = mid + 1;
                }
                else
                    e = mid;
            }

            return s;
        }

        public int MaxLength(IList<string> arr)
        {
            if (arr == null || arr.Count() == 0)
                return 0;

            int res = 0;

            List<HashSet<char>> col = new List<HashSet<char>>();

            foreach (var s in arr)
            {
                int len = s.Length;
                HashSet<char> set = new HashSet<char>();
                bool dup = false;
                foreach (var c in s)
                {
                    if (set.Contains(c))
                    {
                        dup = true;
                        break;
                    }
                    set.Add(c);
                }

                if (dup)
                    continue;

                col.Add(set);
                res = Math.Max(res, len);

                if (col.Count == 1)
                    continue;

                for (int i = col.Count - 1; i >= 0; i--)
                {
                    var x = col[i];
                    bool conflict = false;
                    foreach (var a in set)
                    {
                        if (x.Contains(a))
                        {
                            conflict = true;
                            break;
                        }
                    }

                    if (conflict)
                        continue;

                    int len1 = x.Count;
                    var cand = new HashSet<char>(set);
                    foreach (var a in x)
                    {
                        cand.Add(a);
                    }

                    col.Add(cand);
                    res = Math.Max(res, len + len1);
                }
            }

            return res;
        }

        public int TotalFruit(int[] fruits)
        {
            Dictionary<int, int> d = new();
            int max = 0;
            int curr = 0;
            int index = 0;
            foreach (var f in fruits)
            {
                if (d.ContainsKey(f))
                {
                    d[f]++;
                }
                else
                {
                    d.Add(f, 1);
                }

                curr++;

                while (d.Count > 2)
                {
                    d[fruits[index]]--;
                    if (d[fruits[index]] == 0)
                        d.Remove(fruits[index]);
                    index++;
                    curr--;
                }
                max = Math.Max(max, curr);
            }

            return max;
        }

        public int GetFilters(int[] a)
        {
            double sum = a.Sum();
            PriorityQueue<double, double> q = new PriorityQueue<double, double>();
            foreach (var x in a)
            {
                q.Enqueue(x, -x);
            }
            double target = sum / 2;
            int c = 0;
            while (sum > target)
            {
                c++;
                double max = q.Dequeue();
                double newVal = max / 2;
                sum -= newVal;
                q.Enqueue(newVal, newVal);
            }
            return c;
        }
    }
}