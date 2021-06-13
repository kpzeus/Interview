using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class Clock
    {
        int minutes = 0;

        public Clock(int h, int m)
        {
            minutes = m + h * 60;
        }

        public object Add(int v)
        {
            var c = new Clock(0, this.minutes + v);
            return c;
        }

        public object Subtract(int v)
        {
            var c = new Clock(0, this.minutes - v);
            return c;
        }

        public override bool Equals(object obj)
        {
            var c = obj as Clock;

            if (c == null)
                return false;

            return string.Compare(this.ToString(), c.ToString()) == 0;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            if(minutes < 0)
            {
                minutes = minutes % 1440;
                minutes = 1440 + minutes;
            }

            var h = minutes / 60;
            h = h % 24;
            var m = minutes % 60;
            return h.ToString("00") + ":" + m.ToString("00");
        }
    }
}
