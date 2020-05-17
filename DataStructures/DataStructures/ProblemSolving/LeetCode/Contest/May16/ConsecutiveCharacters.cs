using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May16
{
    // Leetcode 1446 : https://leetcode.com/problems/consecutive-characters/
    // Given a string s, the power of the string is the maximum length of a non-empty substring that contains only one unique character.
    // Return the power of the string.
    // Input: s = "leetcode"
    // Output: 2
    // Explanation: The substring "ee" is of length 2 with the character 'e' only.
    // Input: s = "abbcccddddeeeeedcba"
    // Output: 5
    // Explanation: The substring "eeeee" is of length 5 with the character 'e' only.


    public class ConsecutiveCharacters
    {
        public static void Init()
        {
            var res1 = FindMaxPower("leetcode"); // 2
            var res2 = FindMaxPower("abbcccddddeeeeedcba"); //5
            var res3 = FindMaxPower("triplepillooooow"); //5
            var res4 = FindMaxPower("hooraaaaaaaaaaay"); //11
            var res5 = FindMaxPower("tourist"); //1
        }

        private static int FindMaxPower(string s)
        {
            if (s.Length == 1)
                return 1;

            var maxPowerTillNow = 1;
            var counter = 1;

            for(var i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    counter++;
                    if (maxPowerTillNow < counter)
                        maxPowerTillNow = counter;
                }
                else
                {
                    counter = 1;
                }
            }

            return maxPowerTillNow;
        }
    }
}
