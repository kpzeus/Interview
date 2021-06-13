using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class Bob
    {
        public static string Response(string v)
        {
            var allCaps = true;

            if (string.IsNullOrWhiteSpace(v))
                return "Fine. Be that way!";

            var isQuestion = v.Trim().EndsWith("?");

            var hasLetters = false;

            foreach (var c in v)
            {
                if(char.IsLetter(c))
                {
                    if (char.IsLower(c))
                    {
                        allCaps = false;
                    }
                    hasLetters = true;
                }
            }

            if (allCaps && hasLetters)
            {
                if (isQuestion)
                    return "Calm down, I know what I'm doing!";

                return "Whoa, chill out!";
            }

            if (isQuestion)
                return "Sure.";

            return "Whatever.";
        }
    }
}
