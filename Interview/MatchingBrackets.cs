using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class MatchingBrackets
    {
        private static Dictionary<char, char> d = new Dictionary<char, char>()
        {
            { '}', '{' },
            { ')', '(' },
            { ']', '[' }
        };

        public static bool IsPaired(string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;

            Stack<char> s = new Stack<char>();

            foreach (var c in value)
            {
                if ("{([".Contains(c))
                    s.Push(c);

                if ("})]".Contains(c))
                {
                    if (s.Count == 0)
                        return false;

                    if (s.Peek() != d[c])
                    {
                        return false;
                    }

                    s.Pop();
                }
            }

            if (s.Count > 0)
                return false;

            return true;
        }
    }
}
