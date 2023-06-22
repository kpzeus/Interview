using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    internal class SubMatrixSumToTarget
    {
        public int SubarraySum(int[] temp, int tar)
        {
            int prefixSum = 0;
            int cnt = 0;
            Dictionary<int, int> mp = new Dictionary<int, int>();
            mp[0] = 1;
            for (int i = 0; i < temp.Length; i++)
            {
                prefixSum += temp[i];
                int find = prefixSum - tar;
                if (mp.ContainsKey(find))
                    cnt += mp[find];
                if (!mp.ContainsKey(prefixSum))
                    mp[prefixSum] = 0;
                mp[prefixSum]++;
            }
            return cnt;
        }

        public int NumSubmatrixSumTarget(int[][] matrix, int target)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                int[] temp = new int[m];
                for (int j = i; j < n; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        temp[k] += matrix[j][k];
                    }
                    ans += SubarraySum(temp, target);
                }
            }
            return ans;
        }

        public static void Test()
        {
            var matrix = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 1, 6 },
                new int[] { 7, 8, 9 },
            };

            Console.WriteLine(new SubMatrixSumToTarget().NumSubmatrixSumTarget(matrix, 8));
        }
    }
}
