using System;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May2
{
    //https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/
    //Incomplete

    public class LongContSubArrAbsDiffLessThanEqualToLimit
    {
        public static void Init()
        {
            var res = Find(new[] {8, 2, 4, 7}, 4);
        }

        private static int Find(int[] nums, int limit)
        {
            var finalRes = 1;
            var sumTillNow = 0;
            var pointer = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                sumTillNow -= nums[i];
                var abs = Math.Abs(sumTillNow);

                if (abs > limit)
                {
                    sumTillNow = 0;
                    pointer++;
                    continue;
                }

                if (pointer == i)
                {
                    sumTillNow = Math.Abs(sumTillNow);
                    continue;
                }

                finalRes = i - pointer + 1;
                sumTillNow += nums[i];
            }

            return finalRes;
        }
    }
}