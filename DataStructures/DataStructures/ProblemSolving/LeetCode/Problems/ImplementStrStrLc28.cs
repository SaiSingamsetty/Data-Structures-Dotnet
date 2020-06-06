using System;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    // Leetcode 28: https://leetcode.com/problems/implement-strstr/
    // Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
    // Input: haystack = "hello", needle = "ll"
    // Output: 2
    // Input: haystack = "aaaaa", needle = "bba"
    // Output: -1

    public class ImplementStrStrLc28
    {
        public static void Init()
        {
            Console.WriteLine(ImplStrUsingApproach2("mississippi", "issippi"));
            Console.WriteLine(ImplStrUsingApproach2("bbaa", "aab"));
        }

        #region Approach 1: Loop through each haystack and loop through needle if there is a match

        private static int ImplStrUsingApproach1(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;

            if (needle.Length > haystack.Length)
                return -1;


            for (var i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] != needle[0])
                    continue;
                var index = i;
                var iPointer = i;
                var temp = 0;
                var counter = 1;
                while (iPointer < haystack.Length - 1 && temp < needle.Length - 1)
                {
                    if (haystack[iPointer + 1] != needle[temp + 1])
                    {
                        index = -1;
                        counter = 0;
                        break;
                    }

                    counter++;
                    iPointer++;
                    temp++;
                }

                if (counter == needle.Length)
                    return index;
            }

            return -1;
        }

        #endregion

        #region Approach 2: Optimized Appraoch 1 

        /*
         * Instead of checking for equal condition, check and break if needle[j] != haystack[i+j]
         */

        private static int ImplStrUsingApproach2(string haystack, string needle)
        {
            for (var i = 0;; i++)
            for (var j = 0;; j++)
            {
                if (j == needle.Length) return i;
                if (i + j == haystack.Length) return -1;
                if (needle[j] != haystack[i + j]) break;
            }
        }

        #endregion
    }
}