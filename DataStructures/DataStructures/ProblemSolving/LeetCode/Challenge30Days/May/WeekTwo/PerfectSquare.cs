namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekTwo
{
    // Challenge 9: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3324/
    // Given a positive integer num, write a function which returns True if num is a perfect square else False.
    // Note: Do not use any built-in library function such as sqrt.
    // Example 1:
    // Input: 16
    // Output: true
    // Example 2:
    // Input: 14
    // Output: false

    public class PerfectSquare
    {
        public static void Init()
        {
            var testCase1 = CheckIfItIsPerfect1(16);
            var testCase2 = CheckIfItIsPerfect2(11);
        }

        #region Approach 1: Perfect Squares: 1, 1+3, 1+3+5, 1+3+5+7

        private static bool CheckIfItIsPerfect1(int num)
        {
            var i = 1;
            while (num > 0)
            {
                num -= i;
                i += 2;
            }

            return num == 0;
        }

        #endregion


        #region Approach 2: Binary Search Approach

        private static bool CheckIfItIsPerfect2(int num)
        {
            if (num < 1) return false;
            if (num == 1) return true;
            long min = 1;
            long max = num;
            while (min <= max)
            {
                var mid = (min + max) / 2;
                if (mid * mid == num) return true;
                if (mid * mid > num) max = mid - 1;
                else min = mid + 1;
            }

            return false;
        }

        #endregion
    }
}