using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekThree
{
    // Challenge 17: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3332/
    // Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.
    // Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100. 
    // The order of output does not matter.
    // Input:
    // s: "cbaebabacd" p: "abc"
    // Output:
    // [0, 6]
    // Explanation:
    // The substring with start index = 0 is "cba", which is an anagram of "abc".
    // The substring with start index = 6 is "bac", which is an anagram of "abc".
    // Input:
    // s: "abab" p: "ab"
    // 
    // Output:
    // [0, 1, 2]
    // 
    // Explanation:
    // The substring with start index = 0 is "ab", which is an anagram of "ab".
    // The substring with start index = 1 is "ba", which is an anagram of "ab".
    // The substring with start index = 2 is "ab", which is an anagram of "ab".


    public class FindAllAnagramsInString
    {
        public static void Init()
        {
            var res1 = ExecuteApproach2("cbaebabacd", "abc");
            var res2 = ExecuteApproach2("abab", "ab");
            var res3 = ExecuteApproach1("baa", "aa");
        }

        #region Approach 1 : Looping through; Actual and Temporary lookups {Time limit Exceeded}

        private static IList<int> ExecuteApproach1(string s, string p)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p))
                return new List<int>();

            var list = new List<int>();
            var actualLookUp = new Dictionary<char, int>();
            foreach (var eachChar in p)
                if (actualLookUp.ContainsKey(eachChar))
                    actualLookUp[eachChar]++;
                else
                    actualLookUp[eachChar] = 1;

            for (var i = 0; i < s.Length; i++)
            {
                var tempLookUp = new Dictionary<char, int>();

                for (var j = 0;; j++)
                {
                    if (j == p.Length)
                    {
                        var counter = 0;
                        foreach (var (eachChar, freq) in tempLookUp)
                            if (actualLookUp[eachChar] == freq)
                                counter++;

                        if (counter == actualLookUp.Keys.Count)
                        {
                            list.Add(i);
                            break;
                        }
                    }

                    if (i + j >= s.Length)
                        break;

                    if (!actualLookUp.ContainsKey(s[i + j]))
                    {
                        break;
                    }

                    if (tempLookUp.ContainsKey(s[i + j]))
                        tempLookUp[s[i + j]]++;
                    else
                        tempLookUp[s[i + j]] = 1;
                }
            }

            return list;
        }

        #endregion

        #region Approach 2 : Sliding Window logic

        private static IList<int> ExecuteApproach2(string s, string p)
        {
            var output = new List<int>();
            var sLookUp = new int[26];
            var pLookUp = new int[26];

            var windowSize = p.Length;
            var lengthOfString = s.Length;

            if (lengthOfString < windowSize)
                return output;

            int start = 0, end = 0;

            while (end < windowSize)
            {
                pLookUp[p[end] - 'a']++;
                sLookUp[s[end] - 'a']++;
                end++;
            }

            end--;

            while (end < lengthOfString)
            {
                /* arr1.SequenceEqual(arr2) is also linq built-in function to verify */
                if (CompareArraysHelper(pLookUp, sLookUp))
                    output.Add(start);
                end++;
                if (end != lengthOfString)
                    sLookUp[s[end] - 'a']++;
                sLookUp[s[start] - 'a']--;
                start++;
            }

            return output;
        }

        private static bool CompareArraysHelper(int[] a, int[] b)
        {
            for (var i = 0; i < 25; i++)
                if (a[i] != b[i])
                    return false;

            return true;
        }

        #endregion
    }
}