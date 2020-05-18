using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekThree
{
    // Challenge 18: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3333/
    // Given two strings s1 and s2, write a function to return true if s2 contains the permutation of s1.
    // In other words, one of the first string's permutations is the substring of the second string.
    // Example 1:
    // Input: s1 = "ab" s2 = "eidbaooo"
    // Output: True
    // Explanation: s2 contains one permutation of s1 ("ba").
    // Example 2:
    // Input:s1= "ab" s2 = "eidboaoo"
    // Output: False

    /* Similar to Challenge 17 (Anagrams) */

    public class PermutationInAString
    {
        public static void Init()
        {
            var res1 = Execute("ab", "eidbaooo");
            var res2 = Execute("a", "b");
            var res3 = Execute("adc", "dcda");
        }

        #region Approach 1: Same as Find All Anagrams in String

        private static bool Execute(string s1, string s2)
        {
            var s1Hash = new int[26];
            var s2Hash = new int[26];
            int start = 0, end = 0;
            var windowSize = s1.Length;
            var lengthOfString = s2.Length;

            if (lengthOfString < windowSize)
                return false;

            while (end < windowSize)
            {
                s1Hash[s1[end] - 'a']++;
                s2Hash[s2[end] - 'a']++;
                end++;
            }

            end--;

            while (end < lengthOfString)
            {
                if (s1Hash.SequenceEqual(s2Hash))
                    return true;
                end++;
                if (end != lengthOfString)
                    s2Hash[s2[end] - 'a']++;
                s2Hash[s2[start] - 'a']--;

                start++;

            }

            return false;
        }

        private static bool CompareArraysHelper(int[] a, int[] b)
        {
            for (var i = 0; i < 25; i++)
            {
                if (a[i] != b[i])
                    return false;
            }

            return true;
        }

        #endregion
    }
}
