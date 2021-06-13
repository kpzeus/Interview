using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview
{
    public class Eval
    {
        public static int Parse(string t)
        {
            // 50 + 4 * ( 8 + 2 )
            List<int> values = new List<int>();
            List<int> ops = new List<int>();

            int current = 0;
            bool ch = false;

            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] >= '0' && t[i] <= '9')
                {
                    current = (current * 10) + int.Parse(t[i].ToString());
                    ch = true;
                }
                else
                {
                    switch (t[i])
                    {
                        case ' ':
                            continue;

                        case '(':
                            StringBuilder sb = new StringBuilder();
                            i++;
                            while (i < t.Length && t[i] != ')')
                            {
                                sb.Append(t[i]);
                                i++;
                            }
                            values.Add(Parse(sb.ToString()));
                            break;

                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            if (ch)
                            {
                                values.Add(current);
                                current = 0;
                                ch = false;
                            }
                            ops.Add(t[i]);                           
                            break;

                        default:
                            throw new InvalidOperationException("Invalid Expression");
                    }
                }
            }

            if(ch)
                values.Add(current);

            if (values.Count == 0)
                throw new InvalidOperationException("Invalid Expression");

            if (values.Count != ops.Count + 1)
                throw new InvalidOperationException("Invalid Expression");

            while (values.Count > 1)
            {
                for (int i = 0; i < ops.Count; i++)
                {
                    if(ops[i] == '/')
                    {
                        if (values[i + 1] == 0)
                        {
                            throw new InvalidOperationException("Divide By Zero");
                        }
                        values[i] = values[i] / values[i + 1];
                        ops.RemoveAt(i);
                        values.RemoveAt(i + 1);
                        i--;
                    }
                }

                for (int i = 0; i < ops.Count; i++)
                {
                    if (ops[i] == '*')
                    {
                        values[i] = values[i] * values[i + 1];
                        ops.RemoveAt(i);
                        values.RemoveAt(i + 1);
                        i--;
                    }
                }

                for (int i = 0; i < ops.Count; i++)
                {
                    if (ops[i] == '+')
                    {
                        values[i] = values[i] + values[i + 1];
                        ops.RemoveAt(i);
                        values.RemoveAt(i + 1);
                        i--;
                    }
                }

                for (int i = 0; i < ops.Count; i++)
                {
                    if (ops[i] == '-')
                    {
                        values[i] = values[i] - values[i + 1];
                        ops.RemoveAt(i);
                        values.RemoveAt(i + 1);
                        i--;
                    }
                }
            }

            return values[0];
        }
    }
}
