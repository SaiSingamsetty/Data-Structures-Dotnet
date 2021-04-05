using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Strings
{
    //https://www.hackerrank.com/challenges/alternating-characters/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=strings
    public static class AlternatingCharacters
    {
        public static void Execute()
        {
            var res1 = Find("AAABBB"); // 4
            var res2 = Find("ABABABAB"); //0

        }

        private static int Find(string s)
        {
            var counter = 0;

            var prevChar = s[0];
            for (var i = 1; i < s.Length; i++)
            {
                var currentChar = s[i];
                if (currentChar == prevChar)
                    counter++;

                prevChar = currentChar;
            }

            return counter;
        }
    }
}
