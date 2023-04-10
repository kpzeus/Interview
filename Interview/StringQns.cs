using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public class StringQns
    {
        public bool IsValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            if (s.Length % 2 == 1)
                return false;

            Stack st = new();
            int i = 0;
            while (i < s.Length)
            {
                if ("({[".Contains(s[i]))
                {
                    st.Push(s[i]);
                }
                else
                {
                    if (")}]".Contains(s[i]))
                    {
                        if (st.Count == 0)
                            return false;

                        var c = (char)st.Pop();
                        var c2 = ' ';

                        switch (c)
                        {
                            case '(':
                                c2 = ')';
                                break;
                            case '{':
                                c2 = '}';
                                break;
                            case '[':
                                c2 = ']';
                                break;

                            default:
                                return false;
                        }
                        if (s[i] != c2)
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }

                i++;
            }

            return st.Count == 0;
        }

        public static String RemoveDuplicates(Char[] a)
        {
            if (a == null)
                return null;

            if (a.Length == 1)
                return new string(a);

            HashSet<int> h = new HashSet<int>();

            int j = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (h.Contains(a[i]))
                {
                    continue;
                }
                else
                {
                    h.Add(a[i]);
                    a[j] = a[i];
                    j++;
                }
            }

            string r = "";
            int k = 0;
            while (k < j)
            {
                r = r + a[k];
                k++;
            }
            return r;
        }

        public int Compress(char[] chars)
        {
            char c;
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < chars.Length; i++)
            {
                c = chars[i];
                int t = 0;
                while (i < chars.Length && c == chars[i])
                {
                    t++;
                    i++;
                }

                s.Append(c);
                if (t > 1)
                    s.Append(t);

                i--;
            }

            int k = 0;
            while (k < s.Length)
            {
                chars[k] = s[k];
                k++;
            }

            return s.Length;
        }

        public static string ValidIPAddress(string IP)
        {
            if (IP == null)
                return "Neither";

            var v4Seg = IP.Split(".");
            var v6Seg = IP.Split(":");

            if (v4Seg.Length == 4)
            {
                int i = 0;
                while (i < 4)
                {
                    int val = 0;
                    if (v4Seg[i].Length < 1 || v4Seg[i].Length > 3)
                        return "Neither";
                    if (int.TryParse(v4Seg[i], out val))
                    {
                        if (val >= 0 && val <= 255)
                        {
                            if (v4Seg[i].StartsWith("0") && v4Seg[i].Length > 1)
                                return "Neither";
                        }
                        else
                            return "Neither";
                    }
                    else
                        return "Neither";
                    i++;
                }

                return "IPv4";
            }

            if (v6Seg.Length == 8)
            {
                int i = 0;
                while (i < 8)
                {
                    if (v6Seg[i].Length >= 1 && v6Seg[i].Length <= 4)
                    {
                        int j = 0;
                        while (j < v6Seg[i].Length)
                        {
                            if ((v6Seg[i][j] >= '0' && v6Seg[i][j] <= '9')
                               ||
                               (v6Seg[i][j] >= 'a' && v6Seg[i][j] <= 'f')
                               ||
                               (v6Seg[i][j] >= 'A' && v6Seg[i][j] <= 'F'))
                            {

                            }
                            else
                                return "Neither";
                            j++;
                        }
                    }
                    else
                        return "Neither";
                    i++;
                }

                return "IPv6";
            }

            return "Neither";
        }

        public static string AddBinary(string a, string b)
        {
            StringBuilder sb = new StringBuilder();

            int i = a.Length - 1;
            int j = b.Length - 1;
            int carry = 0;
            while (i > -1 || j > -1)
            {
                int sum = carry;

                if (i > -1)
                {
                    sum += a[i] - '0';
                    i--;
                }

                if (j > -1)
                {
                    sum += b[j] - '0';
                    j--;
                }

                sb.Insert(0, sum % 2);
                carry = sum / 2;
            }

            if (carry > 0)
            {
                sb.Insert(0, 1);
            }

            return sb.ToString();
        }

        public static string ReverseWords(string s)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = s.Length - 1; i > -1; i--)
            {
                if (s[i] == ' ')
                    continue;

                int j = i;
                while (j > -1 && s[j] != ' ')
                {
                    j--;
                }
                j++;

                sb.Append(s.Substring(j, i - j + 1));
                sb.Append(" ");
                i = j - 1;
            }

            return sb.ToString().Trim();
        }

        public static string ReverseWordsInLine(string s)
        {
            s = Reverse(s);

            int j = 0;
            for(int i=0;i < s.Length; i++)
            {
                if (s[i] != ' ')
                    continue;

                s = Reverse(s, j, i - 1);

                while (i < s.Length && s[i] == ' ')
                {
                    i++;                    
                }

                j = i;
            }

            if(s[s.Length - 1] != ' ')
                s = Reverse(s, j, s.Length - 1);

            return s;
        }
        public static string Reverse(string x)
        {
            if (x == null || x.Length < 2)
                return x;

            return Reverse(x, 0, x.Length - 1);
        }

        public static string Reverse(string x, int s, int e)
        {
            if (x == null || x.Length < 2)
                return x;

            var v = x.ToCharArray();

            while(s < e)
            {
                var t = v[s];
                v[s] = v[e];
                v[e] = t;
                s++;
                e--;
            }

            return new string(v);
        }

        public static string ROT13(string x)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in x)
            {
                if (char.IsLetter(c))
                {
                    int l = c;
                    l = l + 13;

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

        public static string MinWindowSubstring(string n, string k)
        {
            var dic = new Dictionary<char, int>();

            foreach (var s in k)
            {
                if (dic.ContainsKey(s))
                    dic[s] = dic[s] + 1;
                else
                    dic[s] = 1;
            }

            for (int i = k.Length; i <= n.Length; i++)
            {
                for (int j = 0; j < n.Length; j++)
                {
                    if (j + i <= n.Length)
                    {
                        var sub = n.Substring(j, i).ToCharArray();
                        var match = true;
                        foreach(var pair in dic)
                        {
                            if(sub.Count(s => s == pair.Key) < dic[pair.Key])
                            {
                                match = false;
                            }
                        }

                        if (match)
                        {
                            return new string(sub);
                        }
                    }
                }
            }

            return "";
        }
    }
}