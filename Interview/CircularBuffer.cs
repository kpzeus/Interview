using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public class CircularBuffer<T>
    {
        List<T> items;
        int capacity;
        int lastIndex = 0;
        int writeIndex = 0;

        public CircularBuffer(int capacity)
        {
            this.capacity = capacity;

            items = new List<T>(capacity);

            for (int i = 0; i < capacity; i++)
            {
                items.Add(default(T));
            }
        }

        public T Read()
        {
            if (object.Equals(items[lastIndex], default(T)))
                throw new InvalidOperationException();

            var res = items[lastIndex];

            items[lastIndex] = default(T);

            lastIndex++;

            lastIndex = lastIndex % capacity;

            return res;
        }

        public void Write(T x)
        {
            if (!object.Equals(items[writeIndex], default(T)))
                throw new InvalidOperationException();

            items[writeIndex] = x;
            writeIndex++;

            writeIndex = writeIndex % capacity;
        }

        public void Clear()
        {
            items.Clear();
            for (int i = 0; i < this.capacity; i++)
            {
                items.Add(default(T));
            }
        }

        public void Overwrite(T v)
        {
            if(items.Count(x => !object.Equals(x, default(T))) < capacity)
            {
                Write(v);
                return;
            }

            items[lastIndex] = v;
            lastIndex++;

            lastIndex = lastIndex % capacity;
        }
    }
}
