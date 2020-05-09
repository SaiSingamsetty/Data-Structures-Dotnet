using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekTwo
{
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
                long mid = (min + max) / 2;
                if (mid * mid == num) return true;
                if (mid * mid > num) max = mid - 1;
                else min = mid + 1;
            }
            return false;

        }

        #endregion

    }
}
