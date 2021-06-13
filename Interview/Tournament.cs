using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Interview
{
    public class Score
    {
        public int MP { get; set; }
        public int W { get; set; }
        public int D { get; set; }
        public int L { get; set; }
        public int P { get; set; }
    }

    public class Tournament
    {
        public static void Tally(MemoryStream inStream, MemoryStream outStream)
        {
            var d = new Dictionary<string, Score>();

            using (StreamReader t = new StreamReader(inStream))
            {
                var x = t.ReadLine();
                while (x != null)
                {
                    var set = x.Split(';');

                    if (!d.ContainsKey(set[0]))
                    {
                        d.Add(set[0], new Score());
                    }


                    if (!d.ContainsKey(set[1]))
                    {
                        d.Add(set[1], new Score());
                    }

                    if(set[2] == "win")
                    {
                        d[set[0]].MP += 1;
                        d[set[0]].W += 1;
                        d[set[0]].P += 3;

                        d[set[1]].MP += 1;
                        d[set[1]].L += 1;
                    }

                    if (set[2] == "draw")
                    {
                        d[set[0]].MP += 1;
                        d[set[0]].D += 1;
                        d[set[0]].P += 1;

                        d[set[1]].MP += 1;
                        d[set[1]].D += 1;
                        d[set[1]].P += 1;
                    }

                    if (set[2] == "loss")
                    {
                        d[set[1]].MP += 1;
                        d[set[1]].W += 1;
                        d[set[1]].P += 3;

                        d[set[0]].MP += 1;
                        d[set[0]].L += 1;
                    }

                    x = t.ReadLine();
                }
            }

            using (StreamWriter t = new StreamWriter(outStream))
            {
                t.Write("Team                           | MP |  W |  D |  L |  P");
                d.ToList().OrderByDescending(x => x.Value.P).ThenBy(x => x.Key).ToList().ForEach(
                    x =>
                    {
                        t.Write("\n" + x.Key + GetSpace(x.Key) + "|  "
                            + x.Value.MP + " |  "
                            + x.Value.W + " |  "
                            + x.Value.D + " |  "
                            + x.Value.L + " |  "
                            + x.Value.P);
                    });
            }
        }

        private static string GetSpace(string key)
        {
            var l = 31 - key.Length;

            var s = new StringBuilder();
            int i = 0;
            while (i < l)
            {
                s.Append(' ');
                i++;
            }

            return s.ToString();
        }
    }
}
