using System;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Arrays
{
    //LEETCODE: https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/559/
    /*
        Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
        Input: [1,2,3]
        Output: [1,2,4]
        Explanation: The array represents the integer 123
     */

    public class PlusOne
    {
        public static void Init()
        {
            var arr = new[] { 9 };
            var response = PlusOneToArray(arr);
            Console.WriteLine("Response: " + response);
        }

        private static int[] PlusOneToArray(int[] digits)
        {
            var carry = 0;
            if (digits[digits.Length - 1] == 9)
            {
                digits[digits.Length - 1] = 0;
                carry = 1;
            }
            else
            {
                digits[digits.Length - 1] += 1;
                return digits;
            }

            for (var i = digits.Length - 2; i >= 0; i--)
            {
                if (carry == 1)
                {
                    if (digits[i] == 9)
                    {
                        digits[i] = 0;
                        carry = 1;
                        continue;
                    }
                    digits[i] += 1;
                    carry = 0;
                }
            }

            if (carry >= 1)
            {
                var newArray = new int[digits.Length + 1];
                newArray[0] = carry;
                digits.CopyTo(newArray, 1);
                return newArray;
            }

            return digits;
        }
    }
}
