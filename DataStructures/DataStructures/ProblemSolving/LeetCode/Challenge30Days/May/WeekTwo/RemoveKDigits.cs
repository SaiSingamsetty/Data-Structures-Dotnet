using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekTwo
{
    // Leetcode: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3328/
    // Day13
    // Given a non-negative integer num represented as a string, remove k digits from the number so that the new number is the smallest possible.
    // Note:
    // The length of num is less than 10002 and will be ≥ k.
    // The given num does not contain any leading zero.

    public class RemoveKDigits
    {
        public static void Init()
        {
            var res1 = Remove("1432219", 3);
        }

        private static string Remove(string num, int k)
        {
            var n = num.Length;
            var stack = new Stack<char>();
            foreach (var eachChar in num)
            {
                while (stack.Count != 0 && k > 0 && stack.Peek() > eachChar)
                { stack.Pop(); k -= 1; }

                if (stack.Count != 0 || eachChar != '0')
                    stack.Push(eachChar);
            }

            //Now remove the largest values from the top of the stack
            while (stack.Count != 0 && k-- > 0)
                stack.Pop();
            if (stack.Count == 0)
                return "0";
            
            //Now retrieve the number from stack into a string (reusing num)
            var temp = string.Empty;
            while (stack.Count != 0)
            {
                temp =  stack.Peek() + temp;
                stack.Pop();
            }
            return temp;

        }

    }
}
