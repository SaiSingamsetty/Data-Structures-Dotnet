using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Dictionaries
{
    public static class TwoStrings
    {
        public static void Execute()
        {
            var res1 = Check("hello", "world");
        }

        private static string Check(string s1, string s2)
        {
            var isMatch = false;
            var lookUpS1 = new Dictionary<char, int>();
            foreach (var eachChar in s1)
            {
                if (lookUpS1.ContainsKey(eachChar))
                    lookUpS1[eachChar]++;
                else
                {
                    lookUpS1[eachChar] = 1;
                }
            }

            foreach (var eachChar in s2)
            {
                if (lookUpS1.ContainsKey(eachChar))
                {
                    isMatch = true;
                    break;
                }
            }

            return (isMatch ? "YES" : "NO");
        }
    }
}
