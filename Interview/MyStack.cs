using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class MyStack
    {
        Queue<int> q1 = new();
        Queue<int> q2 = new();
        int top = -1;
        public MyStack()
        {

        }

        public void Push(int x)
        {
            q1.Enqueue(x);
            top = x;
        }

        public int Pop()
        {
            while (q1.Count > 1)
            {
                top = q1.Dequeue();
                q2.Enqueue(top);
            }
            var x = q1.Dequeue();
            var temp = q1;
            q1 = q2;
            q2 = temp;

            return x;
        }

        public int Top()
        {
            return top;
        }

        public bool Empty()
        {
            return q1.Count + q2.Count == 0;
        }
    }
}
