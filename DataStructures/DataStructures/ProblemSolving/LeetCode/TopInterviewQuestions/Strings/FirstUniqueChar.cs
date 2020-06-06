using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Strings
{
    //LEETCODE: https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/881/
    // Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.
    //s = "leetcode"
    // return 0. 
    // s = "loveleetcode",
    // return 2.

    public class FirstUniqueChar
    {
        public static void Init()
        {
            var str = "leetcode";
            Console.WriteLine(FindFirstUniqueCharUsingBuiltInFunc(str));
        }

        private static int FindFirstUniqueChar(string s)
        {
            // if char does not present in dict, add it
            // if exists, then make value in dict to 0 to neglect
            var dict = new Dictionary<char, int>();
            var pointer = 1; // not to confuse with multiplier 0 in the logic

            foreach (var eachChar in s)
            {
                if (dict.ContainsKey(eachChar))
                    dict[eachChar] = dict[eachChar] * 0;
                else
                    dict.Add(eachChar, pointer);

                pointer++;
            }

            return dict.FirstOrDefault(keyValue => keyValue.Value != 0).Value - 1;
        }

        private static int FindFirstUniqueCharUsingIntArray(string s)
        {
            var arr = new int[26];

            foreach (var eachChar in s) arr[eachChar - 'a']++;

            for (var i = 0; i < s.Length; i++)
                if (arr[s[i] - 'a'] == 1)
                    return i;

            return -1;
        }

        private static int FindFirstUniqueCharUsingBuiltInFunc(string s)
        {
            for (var i = 0; i < s.Length; i++)
                if (s.IndexOf(s[i]) == s.LastIndexOf(s[i]))
                    return i;

            return -1;
        }
    }
}