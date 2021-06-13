using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Interview
{
    public class Autocomplete
    {
        // Trie node class
        public class Node
        {
            public string Prefix { get; set; }
            public Dictionary<char, Node> Children { get; set; }

            // Does this node represent the last character in a word?
            public bool IsWord;

            public Node(String prefix)
            {
                this.Prefix = prefix;
                this.Children = new Dictionary<char, Node>();
            }
        }

        // The trie
        private Node trie;

        private string lastLookup = null;
        private Node lastLookupNode = null;

        public Autocomplete()
        {
            trie = new Node("");
        }

        // Construct the trie from the dictionary
        public Autocomplete(String[] dict)
        {
            trie = new Node("");
            foreach (String s in dict)
                InsertWord(s);
        }

        // Insert a word into the trie
        public void InsertWord(String s)
        {
            // Iterate through each character in the string. If the character is not
            // already in the trie then add it
            Node curr = trie;
            for (int i = 0; i < s.Length; i++)
            {
                if (!curr.Children.ContainsKey(s[i]))
                {
                    curr.Children.Add(s[i], new Node(s.Substring(0, i + 1)));
                }
                curr = curr.Children[s[i]];
                if (i == s.Length - 1)
                    curr.IsWord = true;
            }
        }

        // Find all words in trie that start with prefix
        public List<String> GetWordsForPrefix(String pre)
        {
            List<String> results = new List<String>();
            Node curr = trie;

            if (lastLookup !=null && pre.StartsWith(lastLookup) && pre.Length == lastLookup.Length + 1)
            {
                curr = lastLookupNode;
                var nextChar = pre[pre.Length - 1];
                if (curr.Children.ContainsKey(nextChar))
                {
                    curr = curr.Children[nextChar];
                }
                else
                {
                    return results;
                }
            }
            else
            {
                // Iterate to the end of the prefix
                foreach (char c in pre.ToCharArray())
                {
                    if (curr.Children.ContainsKey(c))
                    {
                        curr = curr.Children[c];
                    }
                    else
                    {
                        return results;
                    }
                }
            }

            lastLookup = pre;
            lastLookupNode = curr;

            // At the end of the prefix, find all child words
            FindAllChildWords(curr, results);
            return results;
        }

        // Recursively find every child word
        private void FindAllChildWords(Node n, List<String> results)
        {
            if (n.IsWord)
                results.Add(n.Prefix);
            foreach (var c in n.Children.Keys)
            {
                FindAllChildWords(n.Children[c], results);
            }
        }
    }
}
