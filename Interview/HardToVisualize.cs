using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class HardToVisualize
    {
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
