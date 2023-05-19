using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class ConsistentHashing
    {
        private readonly SortedDictionary<int, string> ring;
        private readonly int virtualNodes;

        public ConsistentHashing(int virtualNodes = 10)
        {
            ring = new SortedDictionary<int, string>();
            this.virtualNodes = virtualNodes;
        }

        public void AddNode(string node)
        {
            for (int i = 0; i < virtualNodes; i++)
            {
                string virtualNode = $"{node}-VNode-{i}";
                int hash = GetHash(virtualNode);
                ring[hash] = node;
            }
        }

        public void RemoveNode(string node)
        {
            for (int i = 0; i < virtualNodes; i++)
            {
                string virtualNode = $"{node}-VNode-{i}";
                int hash = GetHash(virtualNode);
                ring.Remove(hash);
            }
        }

        public string GetNode(string key)
        {
            int hash = GetHash(key);

            // Find the first node in the ring that is greater than or equal to the hash
            foreach (int nodeHash in ring.Keys)
            {
                if (nodeHash >= hash)
                    return ring[nodeHash];
            }

            // If no node is found, wrap around to the first node in the ring
            return ring[ring.Keys.First()];
        }

        private int GetHash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                return BitConverter.ToInt32(hashBytes, 0);
            }
        }
    }
}
