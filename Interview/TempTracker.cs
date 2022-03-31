using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class TempTracker
    {
        private LinkedList<(DateTime,double)> list;

        public TempTracker()
        {
            list = new();
        }

        public void Record(double temp)
        {
            DateTime limit = DateTime.Now.AddSeconds(-3);
            while (list.Count > 0 && list.First.Value.Item1 < limit)
            {
                list.RemoveFirst();
            }
            while (list.Count > 0 && list.Last.Value.Item1 < limit)
            {
                list.RemoveLast();
            }
            var newNode = new LinkedListNode<(DateTime, double)>((DateTime.Now, temp));
            if (list.Count > 0)
            {
                if (list.First.Value.Item2 <= temp)
                    list.AddFirst(newNode);
                else
                {
                    var curr = list.First;
                    LinkedListNode<(DateTime, double)> prev = null;
                    while(curr != null && curr.Value.Item2 > temp)
                    {
                        prev = curr;
                        curr = curr.Next;
                    }
                    list.AddAfter(prev, newNode);
                }
            }
            else
                list.AddFirst(newNode);
        }

        public double? GetMax()
        {
            DateTime limit = DateTime.Now.AddSeconds(-3);
            while (list.Count > 0 && list.First.Value.Item1 < limit)
            {
                list.RemoveFirst();
            }
            while (list.Count > 0 && list.Last.Value.Item1 < limit)
            {
                list.RemoveLast();
            }
            if (list.Count > 0)
            {
                return list.First.Value.Item2;
            }

            return null;
        }
    }
}
