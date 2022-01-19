using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class MyCircularQueue
    {
        int[] l;
        int h = -1;
        int t = -1;
        int count = 0;
        public MyCircularQueue(int k)
        {
            l = new int[k];
        }

        public bool EnQueue(int value)
        {
            if (IsFull())
                return false;
            t = (t + 1) % l.Length;
            l[t] = value;
            if (h == -1)
                h = 0;
            count++;
            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty())
                return false;
            count--;
            h++;
            if (h == l.Length)
                h = 0;
            return true;
        }

        public int Front()
        {
            if(IsEmpty())
                return -1;

            return l[h];
        }

        public int Rear()
        {
            if (IsEmpty())
                return -1;

            return l[t];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsFull()
        {
            return count == l.Length;
        }
    }
}
