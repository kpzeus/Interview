using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class RotationalCipher
    {
        public static string Rotate(string x, int steps)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in x)
            {
                if (char.IsLetter(c))
                {
                    int l = c;
                    l = l + steps;

                    if (char.IsLower(c))
                    {
                        if (l > 'z')
                        {
                            l = 'a' + (l - 'z' - 1);
                        }
                    }
                    else
                    {
                        if (l > 'Z')
                        {
                            l = 'A' + (l - 'Z' - 1);
                        }
                    }

                    sb.Append((char)l);
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
