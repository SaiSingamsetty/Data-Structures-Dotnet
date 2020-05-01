using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekFour
{
    // Challenge26: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/531/week-4/3311/
    // Longest Common Subsequence
    // Given two strings text1 and text2, return the length of their longest common subsequence. 
    // A subsequence of a string is a new string generated from the original string with some characters(can be none) deleted
    // without changing the relative order of the remaining characters. (eg, "ace" is a subsequence of "abcde" while "aec" is not).
    // A common subsequence of two strings is a subsequence that is common to both strings.
    // If there is no common subsequence, return 0.
    // Input: text1 = "abcde", text2 = "ace" 
    // Output: 3  
    // Explanation: The longest common subsequence is "ace" and its length is 3.
    // Input: text1 = "abc", text2 = "abc"
    // Output: 3
    // Explanation: The longest common subsequence is "abc" and its length is 3.
    // Input: text1 = "abc", text2 = "def"
    // Output: 0
    // Explanation: There is no such common subsequence, so the result is 0.

    public class LongestCommonSubSequence
    {
        public static void Init()
        {
            Console.WriteLine(FindLcsUsingDynPro("abcde", "ace"));
            Console.WriteLine(FindLcs("abcde".ToCharArray(), "ace".ToCharArray(), 0, 0));
        }

        #region Basic Approach (Time Consuming and Space Consuming)

        //https://www.geeksforgeeks.org/longest-common-subsequence-dp-4/

        // Consider the input strings “GABC” and “HADC”. Last characters match for the strings. So length of LCS can be written as:
        // L(“GABC”, “HADC”) = 1 + L(“GAB”, “HAD”)

        // Consider the input strings “GAB” and “HAD".
        // Last characters do not match for the strings. So length of LCS can be written as:
        // L(“GAB”, “HAD”) = MAX ( L(“GAB”, “HA”), L(“GA”, “HAD”) )

        private static int FindLcs(char[] str1, char[] str2, int len1, int len2)
        {
            if (len1 == str1.Length || len2 == str2.Length)
            {
                return 0;
            }

            if (str1[len1] == str2[len2])
            {
                return 1 + FindLcs(str1, str2, len1 + 1, len2 + 1);
            }

            return Math.Max(FindLcs(str1, str2, len1 + 1, len2), FindLcs(str1, str2, len1, len2 + 1));
        }

        #endregion

        #region Dynamic Programming

        // Ref: https://www.youtube.com/watch?v=NnD96abizww

        private static int FindLcsUsingDynPro(string text1, string text2)
        {
            var matrix = new int[text1.Length + 1, text2.Length + 1];
            var max = 0;

            for (var i = 1; i <= text1.Length; i++)
            {
                for (var j = 1; j <= text2.Length; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                    }

                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                }
            }

            return max;
        }

        #endregion
    }
}