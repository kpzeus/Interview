using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public class WordLadder
    {
        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
                return 0;

            Queue<Item> q = new Queue<Item>();
            q.Enqueue(new Item(beginWord, 1));

            while (q.Count > 0)
            {
                var x = q.Dequeue();

                if (x.word == endWord)
                    return x.len;

                for (int i = 0; i < wordList.Count; i++)
                {
                    if (isAdjacent(wordList[i], x.word))
                    {
                        q.Enqueue(new Item(wordList[i], x.len + 1));
                        wordList.Remove(wordList[i]);
                        i--;
                    }
                }
            }

            return 0;
        }

        public static bool isAdjacent(string a, string b)
        {
            int c = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    c++;
                if (c > 1)
                    return false;
            }

            return c == 1;
        }

        public class Item
        {
            public string word;
            public int len;

            public Item(string word, int len)
            {
                this.word = word;
                this.len = len;
            }
        }
    }
}
