using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class RotatedArraySearch
    {
        public long[] values;

        public RotatedArraySearch(params long[] values)
        {
            this.values = values;
        }

        public static long GetIndex(long[] values,long val)
        {
            return Get(values, val, 0, values.Length - 1);
        }

        private static long Get(long[] values, long val, long s, long e)
        {
            long pivot = GetPivotIndex(values);

            if(pivot == 0)
            {
                return BinarySearch(values, val, s, e);
            }
            else
            {
                long s1 = BinarySearch(values, val, s, pivot);

                if (s1 != -1)
                    return s1;

                return BinarySearch(values, val, pivot + 1, e);
            }
        }

        private static long GetPivotIndex(long[] values)
        {
            long s = 0;
            long e = values.Length - 1;

            while(s != e && values[s] > values[e])
            {
                long mid = (s + e) / 2;

                if (values[mid] > values[s])
                {
                    s = mid;
                }
                else
                    e = mid;
            }

            return s;
        }

        private static long BinarySearch(long[] values, long val, long s, long e)
        {
            if (values[s] == val)
            {
                return s;
            }

            if (values[e] == val)
            {
                return e;
            }

            long mid = (s + e) / 2;

            if (values[mid] == val)
            {
                return mid;
            }

            if (mid == s || mid == e)
                return -1;

            if (values[s] < val && values[mid] > val)
                return BinarySearch(values, val, s, mid);

            if (values[e] > val && values[mid] < val)
                return BinarySearch(values, val, mid, e);

            return -1;
        }
    }
}
