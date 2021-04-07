using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.DynPro
{
    public static class Abbreviation
    {
        public static void Execute()
        {
            var res1 = Find("daBcd", "ABC");
        }

        private static string Find(string a, string b)
        {
            var response = AbbreviationFunction(a, b);
            return response ? "YES" : "NO";
        }

        private static bool AbbreviationFunction(string a, string b)
        {
            var aLen = a.Length;
            var bLen = b.Length;

            if (a[aLen-1] == b[bLen-1])
            {
                return AbbreviationFunction(a.Substring(0, aLen - 1), b.Substring(0, bLen - 1));
            }

            if (a[aLen - 1] + 26 == b[bLen - 1])
            {
                var x = AbbreviationFunction(a.Substring(0, aLen - 1), b.Substring(0, bLen))
                        || AbbreviationFunction(a.Substring(0, aLen - 1), b.Substring(0, bLen));
            }

            if(IsLowerCase(a[aLen - 1]))
            {
                return AbbreviationFunction(a.Substring(0, aLen - 1), b);
            }

            return true;
        }

        private static bool IsLowerCase(char c)
        {
            return (c > 'a' && c < 'z');
        }
    }
}
