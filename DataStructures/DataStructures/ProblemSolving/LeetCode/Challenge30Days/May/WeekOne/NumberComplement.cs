using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne
{
    // Challenge 4: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3319/
    // Given a positive integer num, output its complement number. The complement strategy is to flip the bits of its binary representation.
    // Input: num = 5
    // Output: 2
    // Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
    // Input: num = 1
    // Output: 0
    // Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
    // The given integer num is guaranteed to fit within the range of a 32-bit signed integer.
    // num >= 1
    // You could assume no leading zero bit in the integer’s binary representation.
    // This question is the same as 1009: https://leetcode.com/problems/complement-of-base-10-integer/

    public class NumberComplement
    {
        public static void Init()
        {
            Console.WriteLine(FindComplement(5));
        }

        private static int FindComplement(int num)
        {
            int result = 0;
            int i = 0;
            while (num > 0)
            {
                if ((num & 1) == 0)
                    result += 1 << i;

                i += 1;
                num >>= 1;
            }

            return result;
        }
    }
}