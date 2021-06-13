using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public class LRUCache
    {
        Dictionary<int, int> m = new Dictionary<int, int>();
        List<int> l = new List<int>();
        int c = 0;

        public LRUCache(int capacity)
        {
            c = capacity;
        }

        public int Get(int key)
        {
            if (m.ContainsKey(key))
            {
                l.Remove(key);
                l.Add(key);
            }
            else
            {
                return -1;
            }

            return m[key];
        }

        public void Put(int key, int value)
        {
            if (m.ContainsKey(key))
            {
                l.Remove(key);
                m.Remove(key);
            }
            else if (m.Count == c)
            {
                var x = l.First();
                l.Remove(x);
                m.Remove(x);
            }

            m.Add(key, value);
            l.Add(key);
        }
    }
}
