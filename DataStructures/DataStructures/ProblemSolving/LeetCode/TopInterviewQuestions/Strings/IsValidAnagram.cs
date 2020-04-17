using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Strings
{
    //LEETCODE: https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/882/
    // Given two strings s and t , write a function to determine if t is an anagram of s.
    // Input: s = "anagram", t = "nagaram"
    // Output: true

    public class IsValidAnagram
    {
        public static void Init()
        {
            const string s = "anagram";
            const string t = "nagaray";
            Console.WriteLine(IsAnagramUsingDictionary(s, t));
        }

        //Diff between hashtable and Dictionary
        //https://www.tutorialsteacher.com/articles/difference-between-hashtable-and-dictionary-in-csharp


        //We are using dictionary because it will support even if there are other unicode type characters &,*$ as well.
        private static bool IsAnagramUsingDictionary(string s, string t)
        {
            var dict = new Dictionary<char, int>();

            if (s.Length != t.Length)
                return false;

            foreach (var eachChar in s)
            {
                if (dict.ContainsKey(eachChar))
                {
                    dict[eachChar]++;
                }
                else
                {
                    dict.Add(eachChar, 1);
                }
            }

            foreach (var eachChar in t)
            {
                if (dict.ContainsKey(eachChar))
                {
                    dict[eachChar]--;
                }
                else
                {
                    return false;
                }
            }

            return dict.All(keyValue => keyValue.Value == 0);
        }

        private static bool IsAnagramUsingFixedCharArray(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var table = new int[26];

            foreach (var eachChar in s)
            {
                table[eachChar - 'a']++;
            }

            foreach (var eachChar in t)
            {
                table[eachChar - 'a']--;
                if (table[eachChar - 'a'] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}