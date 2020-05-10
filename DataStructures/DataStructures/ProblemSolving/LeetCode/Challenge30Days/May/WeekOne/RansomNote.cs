using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne
{
    public class RansomNote
    {
        public static void Init()
        {
            Console.WriteLine(CanConstruct("aa", "ab"));
        }

        private static bool CanConstruct(string ransomNote, string magazine)
        {
            var dict = new Dictionary<char, int>();

            foreach (var eachChar in magazine)
            {
                if (dict.ContainsKey(eachChar))
                    dict[eachChar]++;
                else
                    dict.Add(eachChar, 1);
            }

            foreach (var eachChar in ransomNote)
            {
                if (dict.ContainsKey(eachChar) && dict[eachChar] > 0)
                    dict[eachChar]--;
                else
                    return false;
            }

            return true;
        }
    }
}