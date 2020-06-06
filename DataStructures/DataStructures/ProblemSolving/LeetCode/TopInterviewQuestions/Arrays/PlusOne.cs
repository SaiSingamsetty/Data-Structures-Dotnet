using System;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Arrays
{
    //LEETCODE: https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/559/
    /*
        Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
        Input: [1,2,3]
        Output: [1,2,4]
        Explanation: The array represents the integer 123
        Input: [9, 9]
        Output: [1, 0, 0]
     */

    public class PlusOne
    {
        public static void Init()
        {
            var arr = new[] {1, 2, 9};
            var response = PlusOneForArray(arr);
            Console.WriteLine("Response: " + response);
        }

        private static int[] PlusOneForArray(int[] digits)
        {
            var carry = 1;
            var length = digits.Length;

            for (var i = length - 1; i >= 0; i--)
                if (carry > 0)
                {
                    var temp = digits[i] + carry;
                    if (temp > 9)
                    {
                        digits[i] = temp % 10;
                    }
                    else
                    {
                        digits[i] = digits[i] + carry;
                        carry = 0;
                    }
                }

            if (carry > 0)
            {
                var newArray = new int[length + 1];
                newArray[0] = carry;
                digits.CopyTo(newArray, 1);
                return newArray;
            }

            return digits;
        }
    }
}