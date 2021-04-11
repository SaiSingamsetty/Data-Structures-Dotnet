using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Dictionaries
{
    public static class SherlockAndAnagrams
    {
        public static void Execute()
        {
            var res1 = Find("abba"); //4
            var res2 = Find("kkkk"); //10
        }

        private static int Find(string s)
        {
            var lookUp = new Dictionary<string, int>();

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; i + j <= s.Length; j++)
                {
                    var temp = s.Substring(i, j).ToCharArray();
                    Array.Sort(temp);
                    var str = new string(temp);

                    if (lookUp.ContainsKey(str))
                    {
                        lookUp[str]++;
                    }
                    else
                    {
                        lookUp[str] = 1;
                    }
                }
            }

            /*
             * if they are 3 k's (k, k, k) in the look up
             * total pairs will be kk, kk, kk [1,2  1,3  2,3]
             * Formula to pick two combinations : nC2
             * -> n*n-1 / 2
             */

            var totalPairs = 0;
            foreach (var eachKeyValue in lookUp)
            {
                totalPairs += (eachKeyValue.Value * (eachKeyValue.Value - 1) / 2);
            }

            return totalPairs;
        }
    }
}
