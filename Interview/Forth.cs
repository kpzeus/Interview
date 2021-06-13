using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview
{
    public class Forth
    {
        static Stack<int> s = new Stack<int>();

        static Dictionary<string, string> udfs = new Dictionary<string, string>();

        private static bool AddIfUdf(string exp)
        {
            var tokens = exp.Split(' ');

            if (tokens.Length > 0)
            {
                if (tokens[0] == ":")
                {
                    if (tokens.Length < 4)
                        throw new InvalidOperationException();

                    if (tokens[tokens.Length - 1] != ";")
                        throw new InvalidOperationException();

                    string udf = tokens[1].ToLower();

                    int val = -1;
                    if(int.TryParse(udf, out val))
                        throw new InvalidOperationException();

                    if (!udfs.ContainsKey(udf))
                        udfs.Add(udf, "");

                    string udfTemp = "";

                    for (int i = 2; i < tokens.Length - 1; i++)
                    {
                        var t = tokens[i].ToLower();

                        while (udfs.ContainsKey(t))
                        {
                            t = udfs[t];
                        }

                        udfTemp += t + " ";
                    }

                    udfs[udf] = udfTemp;

                    udfs[udf] = udfs[udf].Trim();

                    return true;
                }
            }

            return false;
        }

        private static string ProcessUdfs(string exp)
        {
            var tokens = exp.Split(' ').ToList();

            bool hitUdf = true;
            while (hitUdf)
            {
                hitUdf = false;
                for (int i = 0; i < tokens.Count; i++)
                {
                    if (udfs.ContainsKey(tokens[i]))
                    {
                        tokens[i] = udfs[tokens[i]];
                        hitUdf = true;
                    }
                }

                if (hitUdf)
                {
                    string newExp = string.Join(' ', tokens);
                    tokens = newExp.Split(' ').ToList();
                }
            }

            return string.Join(' ', tokens);
        }

        public static string Evaluate(string[] vs)
        {
            s.Clear();

            udfs.Clear();

            StringBuilder output = new StringBuilder();

            foreach(var expItem in vs)
            {
                var exp = expItem.ToLower();

                if (AddIfUdf(exp))
                    continue;

                exp = ProcessUdfs(exp);

                var tokens = exp.Split(' ');

                foreach(var tokenItem in tokens)
                {
                    int val = -1;
                    string token = tokenItem.ToLower();

                    if (int.TryParse(token, out val))
                    {
                        s.Push(val);
                    }
                    else
                    {
                        int a = 0;
                        int b = 0;

                        //Operations
                        switch (token)
                        {
                            case "+":
                                if (s.Count < 2)
                                    throw new InvalidOperationException();
                                b = s.Pop();
                                a = s.Pop();
                                s.Push(a + b);
                                break;

                            case "-":
                                if (s.Count < 2)
                                    throw new InvalidOperationException();
                                b = s.Pop();
                                a = s.Pop();
                                s.Push(a - b);
                                break;

                            case "*":
                                if (s.Count < 2)
                                    throw new InvalidOperationException();
                                b = s.Pop();
                                a = s.Pop();
                                s.Push(a * b);
                                break;

                            case "/":
                                if (s.Count < 2)
                                    throw new InvalidOperationException();
                                b = s.Pop();
                                a = s.Pop();
                                if (b == 0)
                                    throw new InvalidOperationException();
                                s.Push(a / b);
                                break;

                            case "dup":
                                if (s.Count < 1)
                                    throw new InvalidOperationException();
                                a = s.Peek();
                                s.Push(a);
                                break;

                            case "drop":
                                if (s.Count < 1)
                                    throw new InvalidOperationException();
                                s.Pop();
                                break;

                            case "swap":
                                if (s.Count < 2)
                                    throw new InvalidOperationException();
                                b = s.Pop();
                                a = s.Pop();
                                s.Push(b);
                                s.Push(a);
                                break;

                            case "over":
                                if (s.Count < 2)
                                    throw new InvalidOperationException();
                                b = s.Pop();
                                a = s.Pop();
                                s.Push(a);
                                s.Push(b);
                                s.Push(a);
                                break;

                            default:
                                if (!udfs.ContainsKey(token))
                                    throw new InvalidOperationException();
                                token = udfs[token];
                                break;
                        }
                    }
                }
            }

            while (s.Count > 0)
            {
                output.Insert(0, s.Pop().ToString() + " ");
            }

            if(output.Length > 0)
                output.Length = output.Length - 1;

            return output.ToString();
        }
    }
}
