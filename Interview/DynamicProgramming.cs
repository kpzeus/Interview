using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class DynamicProgramming
    {
        public long MostPoints(int[][] questions)
        {
            int n = questions.Length;
            long[] dp = new long[n + 1];
            for (int i = n - 1; i >= 0; i--)
            {
                int point = questions[i][0];
                int jump = questions[i][1];

                int nextQuestion = Math.Min(n, i + jump + 1);
                dp[i] = Math.Max(dp[i + 1], point + dp[nextQuestion]);
            }
            return dp[0];
        }
    }
}
