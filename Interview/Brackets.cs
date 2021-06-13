using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview
{
    class Brackets
    {
        public static HashSet<string> GetCombinationsParantheses(int noOfPairs)
        {
            HashSet<string> combinations = new HashSet<string>();

            if (noOfPairs <= 0) return combinations;

            if (noOfPairs == 1)
            {
                combinations.Add("()");
                return combinations;
            }

            HashSet<string> previousCombinations = GetCombinationsParantheses(noOfPairs - 1);

            StringBuilder sb = new StringBuilder();
            foreach (var combination in previousCombinations)
            {
                sb.Clear();
                sb.Append(combination);
                for (int i = 0; i < combination.Length; i++)
                {

                    sb.Insert(i, "()");
                    combinations.Add(sb.ToString());
                    sb.Remove(i, 2);
                }
            }

            return combinations;
        }

        public static int BracketCombinations(int num)
        {
            var x = GetCombinationsParantheses(num);

            x.ToList().ForEach(a => Console.WriteLine(a));
            
            return x.Count;
        }
    }
}
