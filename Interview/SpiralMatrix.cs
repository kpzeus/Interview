namespace Interview
{
    public class SpiralMatrix
    {
        public static int[,] GetMatrix(int v)
        {
            if (v < 1) 
                return new int[0, 0];

            var m = new int[v, v];

            int i = 1;

            int t = v * v;

            int r = 0;
            int c = 0;

            int l = -1;
            int u = v;

            while (i <= t)
            {
                //Right
                while(c < u && i <= t)
                {
                    m[r, c] = i;
                    c++;
                    i++;
                }                
                c--;
                r++;

                //Down
                while (r < u && i <= t)
                {
                    m[r, c] = i;
                    r++;
                    i++;
                }
                r--;
                c--;

                u--;

                //Left
                while (c > l && i <= t)
                {
                    m[r, c] = i;
                    c--;
                    i++;
                }
                c++;
                r--;

                l++;

                //Top
                while (r > l && i <= t)
                {
                    m[r, c] = i;
                    r--;
                    i++;
                }
                r++;
                c++;
            }

            return m;
        }
    }
}
