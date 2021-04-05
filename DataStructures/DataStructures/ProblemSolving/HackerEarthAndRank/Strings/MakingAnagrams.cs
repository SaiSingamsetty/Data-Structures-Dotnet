using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Strings
{
    //https://www.hackerrank.com/challenges/ctci-making-anagrams/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=strings
    public static class MakingAnagrams
    {
        public static void Execute()
        {
            var res1 = Make("cde", "abc"); //4
            var res2 = Make("abatibbb", "batad"); //5
            var res4 = Make("axyz", "agg"); //5
            var res3 = Make("fcrxzwscanmligyxyvym", "jxwtrhvujlmrpdoqbisbwhmgpmeoke"); //30
        }

        private static int Make(string a, string b)
        {
            var aLookUp = new Dictionary<char, int>();
            var bCounter = 0;

            foreach (var eachChar in a)
            {
                if (aLookUp.ContainsKey(eachChar))
                {
                    aLookUp[eachChar]++;
                }
                else
                {
                    aLookUp[eachChar] = 1;
                }
            }

            foreach (var eachChar in b)
            {
                //If that char is/was in aLookUp, update the look up else increment bCounter to track
                //extra characters of b

                if (aLookUp.ContainsKey(eachChar))
                {
                    aLookUp[eachChar]--;
                }
                else
                {
                    bCounter++;
                }
            }

            var unique = aLookUp.Sum(x => x.Value >= 0 ? x.Value : -1 * x.Value) + bCounter;
            return unique;
        }
    }
}
