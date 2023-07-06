using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    internal class Fuel
    {
        private int cost = 0;
        private Dictionary<int, List<int>> d = null;
        private HashSet<int> visited = null;

        public int solution(int[] A, int[] B)
        {
            d = new Dictionary<int, List<int>>();
            visited = new HashSet<int>();
            int n = A.Length;
            cost = 0;
            int i = 0;
            while (i < n)
            {
                if (!d.ContainsKey(A[i]))
                    d.Add(A[i], new List<int>());
                if (!d.ContainsKey(B[i]))
                    d.Add(B[i], new List<int>());
                d[A[i]].Add(B[i]);
                d[B[i]].Add(A[i]);
                i++;
            }

            Visit(0);

            return cost;
        }

        private int Visit(int node)
        {
            if(visited.Contains(node)) 
                return 0;

            visited.Add(node);
            int total = 1;
            foreach (var neighbour in d[node])
            {
                if (!visited.Contains(neighbour))
                {
                    var people = Visit(neighbour);
                    total += people;
                }
            }

            if (node > 0)
            {
                if (total > 5)
                {
                    cost += (total / 5);
                }
                cost++;
            }

            return total;
        }
    }
}
