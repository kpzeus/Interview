using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class MatrixQns
    {
        public int UniquePaths(int m, int n)
        {
            var dp = new int[m][];

            int i = 0;
            while (i < m)
            {
                dp[i] = new int[n];
                i++;
            }

            i = 0;
            int j = 0;
            while (j < n)
            {
                dp[i][j] = 1;
                j++;
            }

            i = 0;
            j = 0;
            while (i < m)
            {
                dp[i][j] = 1;
                i++;
            }

            i = 1;
            j = 1;
            while (i < m)
            {
                j = 1;
                while (j < n)
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                    j++;
                }
                i++;
            }

            return dp[m - 1][n - 1];
        }

        public static void Rotate(int[][] matrix)
        {
            int n = matrix.Length;

            if (n == 1)
                return;

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[n - 1 - j][i];
                    matrix[n - 1 - j][i] = matrix[n - 1 - i][n - 1 - j];
                    matrix[n - 1 - i][n - 1 - j] = matrix[j][n - 1 - i];
                    matrix[j][n - 1 - i] = temp;
                }
            }

            return;
        }
    }
}
