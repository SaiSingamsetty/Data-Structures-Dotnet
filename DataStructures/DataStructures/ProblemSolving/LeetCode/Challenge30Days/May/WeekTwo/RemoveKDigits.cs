using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekTwo
{
    // Challenge 13: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3328/
    // Given a non-negative integer num represented as a string, remove k digits from the number so that the new number is the smallest possible.
    // Note:
    // The length of num is less than 10002 and will be ≥ k.
    // The given num does not contain any leading zero.

    public class RemoveKDigits
    {
        public static void Init()
        {
            var res1 = RemoveDigitsApproach2("1432219", 3);
            var res2 = RemoveDigitsApproach1("100200", 2);
            var res3 = RemoveDigitsApproach2("123", 2);
        }

        #region Approach 1: Using Stack (TC: O(N) for iterating through all elements, SC: O(N) for using stack)

        private static string RemoveDigitsApproach1(string num, int k)
        {
            var stack = new Stack<char>();

            foreach (var eachChar in num)
            {
                while (stack.Count != 0 && k > 0 && eachChar < stack.Peek())
                {
                    stack.Pop();
                    k--;
                }

                if (stack.Count == 0 && eachChar == '0'
                ) //No need to add 0's when the stack is empty as it just leading 0's
                    continue;

                stack.Push(eachChar);
            }

            /*
            * Now remove the largest values from the top of the stack
            * If the num is 123 and the stack will be filled with all digits by end of above loop
            * So we should remove if stack is not empty and k value is still greater than 0
           */
            while (stack.Count > 0 && k > 0)
            {
                stack.Pop();
                k--;
            }

            if (stack.Count == 0)
                return "0";

            var temp = string.Empty;
            while (stack.Count > 0)
            {
                temp = stack.Pop() + temp;
            }

            return temp;
        }

        #endregion

        #region Approach 2: Using Stack, String Builder (faster)

        private static string RemoveDigitsApproach2(string num, int k)
        {
            var stack = new Stack<char>();

            foreach (var eachChar in num)
            {
                while (stack.Count != 0 && k > 0 && eachChar < stack.Peek())
                {
                    stack.Pop();
                    k--;
                }

                if (stack.Count == 0 && eachChar == '0'
                ) //No need to add 0's when the stack is empty as it just leading 0's
                    continue;

                stack.Push(eachChar);
            }

            /*
             * Now remove the largest values from the top of the stack
             * If the num is 123 and the stack will be filled with all digits by end of above loop
             * So we should remove if stack is not empty and k value is still greater than 0
            */
            while (stack.Count > 0 && k > 0)
            {
                stack.Pop();
                k--;
            }

            if (stack.Count == 0)
                return "0";

            var sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            var charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        #endregion
    }
}