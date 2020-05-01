using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekFour
{
    //Challenge 23: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/531/week-4/3308/
    // Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.
    // Input: [5,7]
    // Output: 4

    public class BitwiseAndOfNumbersRange
    {
        public static void Init()
        {
            Console.WriteLine(RangeBitwiseAnd(5, 7));
        }

        //https://www.youtube.com/watch?v=-qrpJykY2gE

        private static int RangeBitwiseAnd(int m, int n)
        {
            //Starting from MSB (left most 1), by right shifting we are checking
            //how many bits are in common between two no.
            //for those common bits, AND will give the same number.
            //Adding zeros to the result common number by left shifting that count times.

            var counter = 0;
            while (m != n)
            {
                m = m >> 1;
                n = n >> 1;
                counter++;
            }

            return m << counter;
        }
    }
}