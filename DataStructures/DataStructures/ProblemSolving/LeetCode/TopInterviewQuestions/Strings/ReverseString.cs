using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Strings
{
    //LEETCODE: https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/879/
    /*
       Write a function that reverses a string. The input string is given as an array of characters char[].       
       Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.       
       You may assume all the characters consist of printable ascii characters.
     */

    public class ReverseString
    {
        public static void Init()
        {
            var stringArray = new[] { 's', 'a', 'i', 't' };
            var response = ReverseStringArray(stringArray);
            Console.WriteLine(string.Join(',', response));
        }

        private static IEnumerable<char> ReverseStringArray(IList<char> s)
        {
            for (int i = 0, j = s.Count - 1; i < s.Count / 2; i++, j--)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }

            return s;
        }
    }
}
