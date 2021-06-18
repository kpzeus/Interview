using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        if (r.N == 0)
        {
            return 1;
        }

        if (r.IsReal())
        {
            var x = r.Exprational(realNumber);

            return (double)x.N / (double)x.D;
        }
        else
        {
            int n = r.N;
            int d = r.D;

            var x = Math.Pow(realNumber, n);
            var val = x.NthRoot(d);

            return val;
        }
    }

    public static double NthRoot(this double A, double N)
    {
        Random rand = new Random();

        // initially guessing a random number between
        // 0 and 9
        double xPre = rand.Next(10);


        // smaller eps, denotes more accuracy
        double eps = 0.0000001;

        // initializing difference between two
        // roots by INT_MAX
        double delX = 2147483647;

        // xK denotes current value of x
        double xK = 0.0;

        // loop untill we reach desired accuracy
        while (delX > eps)
        {
            // calculating current value from previous
            // value by newton's method
            xK = ((N - 1.0) * xPre + A / Math.Pow(xPre, N - 1)) / N;
            delX = Math.Abs(xK - xPre);
            xPre = xK;
        }

        return xK;
    }
}

public struct RationalNumber
{
    public RationalNumber(int numerator, int denominator)
    {
        N = numerator;
        D = denominator;

        if (D < 0)
        {
            D = Math.Abs(D);
            N = N * -1;
        }

        if (denominator == 0) throw new InvalidOperationException();

        int gcd = GCD(this.N, this.D);

        N = N / gcd;
        D = D / gcd;

        if (N == 0) D = 1;
    }

    public int N { get; }

    public int D { get; }

    internal RationalNumber Reduce()
    {
        int gcd = GCD(this.N, this.D);

        return new RationalNumber(this.N / gcd, this.D / gcd);
    }

    private int GCD(int a, int b)
    {
        int r1 = Math.Abs(a);
        int r2 = Math.Abs(b);

        if (r1 == r2) return r1;

        int max = Math.Min(r1, r2);

        int gcd = 1;

        for (int i = 2; i <= max; i++)
        {
            if (r1 % i == 0 && r2 % i == 0) gcd = i;
        }

        return gcd;
    }

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        int n = a.N * b.D + a.D * b.N;
        int d = a.D * b.D;

        return new RationalNumber(n, d);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        int n = a.N * b.D - a.D * b.N;
        int d = a.D * b.D;

        return new RationalNumber(n, d);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        int n = a.N * b.N;
        int d = a.D * b.D;

        return new RationalNumber(n, d);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        int n = a.N * b.D;
        int d = a.D * b.N;

        return new RationalNumber(n, d);
    }

    internal RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(this.N), this.D);
    }

    public bool IsNegative()
    {
        return this.N < 0;
    }

    public bool IsReal()
    {
        return this.D == 1;
    }

    public RationalNumber Exprational(int v)
    {
        if (v == 0)
        {
            return new RationalNumber(1, 1);
        }

        if (this.N == 0) return new RationalNumber(0, 1);

        RationalNumber r;

        var n = Math.Pow(Math.Abs(N), v);
        var d = Math.Pow(D, v);

        if (this.IsNegative())
        {
            r = new RationalNumber(-1 * (int)n, (int)d);
        }
        else
        {
            r = new RationalNumber((int)n, (int)d);
        }

        return r;
    }

    public override bool Equals(object obj)
    {
        var x = (RationalNumber)obj;

        return this.N == x.N && this.D == x.D;
    }

    public override int GetHashCode()
    {
        return Tuple.Create(N, D).GetHashCode();
    }
}
