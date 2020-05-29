using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFour
{
    // Challenge22: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3337/
    // Given a string, sort it in decreasing order based on the frequency of characters.
    // Input:
    // "tree"
    // Output:
    // "eert"   
    // Explanation:
    // 'e' appears twice while 'r' and 't' both appear once.
    // So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
    // Input:
    // "cccaaa"
    // Output:
    // "cccaaa"
    // Explanation:
    // Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
    // Note that "cacaca" is incorrect, as the same characters must be together.

    public class SortCharactersByFrequency
    {
        public static void Init()
        {
            var res1 = SortUsingApproach1("tree");
        }

        private static string SortUsingApproach1(string s)
        {
            if(string.IsNullOrEmpty(s))
                return string.Empty;

            if (s.Length == 1)
                return s;

            var dict = new Dictionary<char, int>();

            foreach (var eachChar in s)
            {
                //dict.TryAdd(eachChar, dict.GetValueOrDefault(eachChar, 0) + 1);
                if (dict.ContainsKey(eachChar))
                    dict[eachChar]++;
                else
                {
                    dict[eachChar] = 1;
                }
            }

            var sortedDict = from entry in dict orderby entry.Value descending select entry;
            //dict=dict.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);

            var output = new StringBuilder(s.Length);
            foreach (var (key, value) in sortedDict)
                output.Append(key, value);

            return output.ToString();
        }
    }
}
