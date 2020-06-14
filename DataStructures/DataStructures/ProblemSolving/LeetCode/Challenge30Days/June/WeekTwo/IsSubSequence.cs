using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekTwo
{
    // Challenge 9: https://leetcode.com/problems/is-subsequence/
    // LC 392
    // Given a string s and a string t, check if s is subsequence of t.
    // 
    // A subsequence of a string is a new string which is formed from the original string by deleting some
    // (can be none) of the characters without disturbing the relative positions of the remaining characters.
    // (ie, "ace" is a subsequence of "abcde" while "aec" is not).
    // Input: s = "abc", t = "ahbgdc"
    // Output: true
    // Input: s = "axc", t = "ahbgdc"
    // Output: false

    public class IsSubSequence
    {
        public static void Init()
        {
            var res1 = FindUsingApproach1("acb", "ahbgdc");
            var res2 = FindUsingApproach1("abc", "ahbgdc");
            var res3 = FindUsingApproach1("aaaaaa", "bbaaaa");
        }

        private static bool FindUsingApproach1(string s, string t)
        {
            if (s.Length > t.Length)
                return false;
            if (s.Length == 0)
                return true;

            var firstPointer = 0;
            var counter = 0;
            
            foreach (var eachChar in t)
            {
                if(firstPointer >= s.Length)
                    break;
                
                if (eachChar != s[firstPointer])
                    continue;
                firstPointer++;
                counter++;
            }

            return counter == s.Length;
        }
    }
}
