namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekTwo
{
    // LeetCode Day14 : https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3329/
    // Implement a trie with insert, search, and startsWith methods.
    // Trie trie = new Trie();
    // trie.insert("apple");
    // trie.search("apple");   // returns true
    // trie.search("app");     // returns false
    // trie.startsWith("app"); // returns true
    // trie.insert("app");   
    // trie.search("app");     // returns true

    // Note: 
    // You may assume that all inputs are consist of lowercase letters a-z.
    // All inputs are guaranteed to be non-empty strings.

    public class ImplementTrie
    {
        public static void Init()
        {
            var trie1 = new Trie();
            trie1.Insert("apple");
            var res11 = trie1.Search("apple");
            var res12 = trie1.Search("app");
            var res13 = trie1.StartsWith("app");
            trie1.Insert("app");
            var res14 = trie1.Search("app");
        }
    }

    public class Trie
    {
        public TrieNode Root;

        public Trie()
        {
            Root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var temp = Root;
            foreach (var eachChar in word)
            {
                if (temp.ChildNodes[eachChar - 'a'] == null)
                    temp.ChildNodes[eachChar - 'a'] = new TrieNode(); // if the specific child node is not yet initiated

                temp = temp.ChildNodes[eachChar - 'a']; // If it is initiated, then go one level down
            }

            temp.EndsHere = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var temp = Root;

            foreach (var eachChar in word)
            {
                if (temp.ChildNodes[eachChar - 'a'] == null)
                    return false;

                temp = temp.ChildNodes[eachChar - 'a'];
            }

            return temp.EndsHere;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var temp = Root;

            foreach (var eachChar in prefix)
            {
                if (temp.ChildNodes[eachChar - 'a'] == null)
                    return false;

                temp = temp.ChildNodes[eachChar - 'a'];
            }

            return true;
        }
    }

    public class TrieNode
    {
        public TrieNode()
        {
            EndsHere = false;
            ChildNodes = new TrieNode[26];
        }

        public bool EndsHere { get; set; }

        public TrieNode[] ChildNodes { get; set; }
    }
}