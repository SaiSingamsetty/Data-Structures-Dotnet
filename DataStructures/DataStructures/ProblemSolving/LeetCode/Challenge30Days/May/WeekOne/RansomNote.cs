using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne
{
    // Challenge 3: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3318/
    // Given an arbitrary ransom note string and another string containing letters from all the magazines, write a function that will return true if the ransom note can be constructed from the magazines ; otherwise, it will return false.
    // Each letter in the magazine string can only be used once in your ransom note.
    // Input: ransomNote = "a", magazine = "b"
    // Output: false
    // Input: ransomNote = "aa", magazine = "ab"
    // Output: false
    // Input: ransomNote = "aa", magazine = "aab"
    // Output: true


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