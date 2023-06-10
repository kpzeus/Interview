using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    internal class MaximumValue
    {
        private int n;
        private int index;

        public long Check(long a)
        {
            long leftOffset = Math.Max(a - index, 0);
            long result = (a + leftOffset) * (a - leftOffset + 1) / 2;
            long rightOffset = Math.Max(a - ((n - 1) - index), 0);
            result += (a + rightOffset) * (a - rightOffset + 1) / 2;
            return result - a;
        }

        public int MaxValue(int n, int index, int maxSum)
        {
            this.n = n;
            this.index = index;

            maxSum -= n;
            int left = 0;
            int right = maxSum;

            while (left < right)
            {
                int mid = (left + right + 1) / 2;
                if (Check(mid) <= maxSum)
                    left = mid;
                else
                    right = mid - 1;
            }
            int result = left + 1;
            return result;
        }
    }
}
