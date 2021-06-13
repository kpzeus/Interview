using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview
{

    public class Dominoes
    {
        public static bool CanChain((int, int)[] dominoes)
        {
            if (dominoes == null || dominoes.Length < 1)
                return true;

            var d = dominoes.ToList();

            var item = d[0];
            d.Remove(item);

            return CanChain(item.Item1, item.Item2, d);
        }

        public static bool CanChain(int start, int end, List<(int,int)> dominoes)
        {
            if(dominoes.Count == 0)
            {
                return start == end;
            }

            foreach (var item in dominoes)
            {
                if(item.Item1 == end || item.Item2 == end)
                {
                    var remains = new List<(int, int)>(dominoes);
                    remains.Remove(item);

                    if (CanChain(start, item.Item1 == end ? item.Item2 : item.Item1, remains))
                        return true;
                }
            }

            return false;
        }
    }
}
