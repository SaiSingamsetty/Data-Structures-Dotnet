using System;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekTwo
{
    // Challenge 8: https://leetcode.com/problems/power-of-two/
    // LC  231
    // Given an integer, write a function to determine if it is a power of two.

    public class PowerOfTwo
    {
        public static void Init()
        {
            var res1 = FindUsingApproach1(1);
            var res2 = FindUsingApproach1(16);
            var res3 = FindUsingApproach2(21);
        }

        private static bool FindUsingApproach1(int n)
        {
            if (n <= 0)
                return false;
            var binaryFormat = Convert.ToString(n, 2);
            return binaryFormat.ToCharArray().Count(x => x == '1') == 1;
        } 

        private static bool FindUsingApproach2(int n)
        {
            if (n <= 0) return false;
            if (n == 1) return true;

            while (n > 1)
            {
                if (n % 2 != 0) return false;
                n = n / 2;
            }

            return true;
        }
    }
}
