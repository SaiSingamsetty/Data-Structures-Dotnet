using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.Strings
{
    public static class MinimumWindowSubstring
    {
        public static void Execute()
        {
            var res1 = Find("aaat", "at"); //at - 2
        }

        private static string Find(string searchString, string t)
        {
            var lengthOfSearchString = searchString.Length;
            var minWindowSubStrLength = int.MaxValue;
            var minWindowSubStr = string.Empty;

            for (int i = 0; i < searchString.Length; i++)
            {
                for (int j = 1; j < searchString.Length - i; j++)
                {
                    var window = searchString.Substring(i, j + 1);

                    var isProperWindow = DoesStringContainsAllCharacters(window, t);

                    if (isProperWindow && window.Length < minWindowSubStrLength)
                    {
                        minWindowSubStrLength = window.Length;
                        minWindowSubStr = window;
                    }
                }
            }

            return minWindowSubStr;
        }

        private static bool DoesStringContainsAllCharacters(string searchString, string t)
        {
            var tLookUp = new Dictionary<char, int>();
            foreach (var eachChar in t)
            {
                if (tLookUp.ContainsKey(eachChar))
                    tLookUp[eachChar]++;
                else
                {
                    tLookUp[eachChar] = 1;
                }
            }

            foreach (var eachChar in searchString)
            {
                if (tLookUp.ContainsKey(eachChar))
                {
                    var updatedCount = tLookUp[eachChar] - 1;
                    if (updatedCount == 0)
                    {
                        tLookUp.Remove(eachChar);
                    }
                    else
                    {
                        tLookUp[eachChar] = updatedCount;
                    }
                }
            }

            return tLookUp.Keys.Count == 0;
        }
    }
}
