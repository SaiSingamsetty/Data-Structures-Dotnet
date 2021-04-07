using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Strings
{
    public static class CommonChild
    {
        public static void Execute()
        {
            var res1 = Find("SHINCHAN", "NOHARAAA"); //3
            var res2 = Find("AAA", "BBB"); //0
            var res3 = Find("ABCDEF", "FBDAMN"); //2
        }

        private static int Find(string s1, string s2)
        {
            var s1LookUp = new Dictionary<char, int>();
            foreach (var eachChar in s1)
            {
                if (s1LookUp.ContainsKey(eachChar))
                    s1LookUp[eachChar]++;
                else
                {
                    s1LookUp[eachChar] = 1;
                }
            }

            var counter = 0;
            foreach (var eachChar in s2)
            {
                if (s1LookUp.ContainsKey(eachChar) && s1LookUp[eachChar] > 0)
                {
                    counter++;
                    s1LookUp[eachChar]--;
                }
            }

            return counter;
        }
    }
}
