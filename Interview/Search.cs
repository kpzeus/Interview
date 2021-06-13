using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class Pos
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int C { get; set; }
        public List<Pos> trail { get; set; }

        public Pos GetPos(int offsetX, int offsetY)
        {
            var p = new Pos();
            p.X = this.X + offsetX;
            p.Y = this.Y + offsetY;
            p.C = this.C + 1;
            if (this.trail == null)
                this.trail = new List<Pos>();

            p.trail = new List<Pos>();
            p.trail.AddRange(this.trail);
            p.trail.Add(this);

            return p;
        }
    }

    public class Search
    {
        int[][] m;
        Queue<Pos> q = new Queue<Pos>();

        public Search(int[][] m)
        {
            this.m = m;
        }

        public int GetMinPath(Pos s, Pos e)
        {
            q.Clear();

            q.Enqueue(s);

            while(q.Count > 0)
            {
                var a = q.Dequeue();

                if(a.X == e.X && a.Y == e.Y)
                {
                    return a.C;
                }

                this.Enqueue(a, -2, -1);
                this.Enqueue(a, -1, -2);
                this.Enqueue(a, 1, 2);
                this.Enqueue(a, 2, 1);
                this.Enqueue(a, -2, 1);
                this.Enqueue(a, 1, -2);
                this.Enqueue(a, 2, -1);
                this.Enqueue(a, -1, 2);
            }

            return -1;
        }

        public void Enqueue(Pos a, int offsetX, int offSetY)
        {
            var p = a.GetPos(offsetX, offSetY);

            if (IsValid(p))
            {
                q.Enqueue(p);
            }
        }

        bool IsValid(Pos a)
        {
            if (a.X < 0 || a.Y < 0 || a.Y > m.Length || a.X > m[0].Length)
            {
                return false;
            }

            return true;
        }
    }
}
