using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Dictionaries
{
    public static class RansomNote
    {
        public static void Execute()
        {
            CheckMagazine(new[] {"give", "me", "one", "grand", "today"}, new[] {"give", "one", "today"});
            CheckMagazine(new[] {"two", "times", "three", "not", "four"}, new[] {"two", "times", "two"});
        }

        private static void CheckMagazine(string[] magazine, string[] note)
        {
            var lookUp = new Dictionary<string, int>();
            var isMatch = true;

            foreach (var s in magazine)
            {
                if (lookUp.ContainsKey(s))
                {
                    lookUp[s]++;
                }
                else
                {
                    lookUp[s] = 1;
                }
            }

            foreach (var s in note)
            {
                if (lookUp.ContainsKey(s) && lookUp[s] > 0)
                {
                    lookUp[s]--;
                }
                else
                {
                    isMatch = false;
                    break;
                }
            }

            Console.WriteLine(isMatch ? "Yes" : "No");
        }
    }
}
