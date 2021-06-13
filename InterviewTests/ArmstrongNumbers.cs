using System;
using System.Collections.Generic;

namespace InterviewTests
{
    internal class ArmstrongNumbers
    {
        internal static bool IsArmstrongNumber(int v)
        {
            if (v < 0)
                throw new ArgumentException();

            int d = v;
            List<int> digits = new List<int>();
            double sum = 0;

            while(d > 0)
            {
                int rem = d % 10;
                digits.Add(rem);
                d = d / 10;
            }

            int p = digits.Count;
            foreach(var x in digits)
            {
                sum += Math.Pow(x, p);
            }

            return sum == v;
        }
    }
}