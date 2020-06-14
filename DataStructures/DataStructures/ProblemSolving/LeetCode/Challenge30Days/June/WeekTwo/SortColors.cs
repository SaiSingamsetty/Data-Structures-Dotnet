using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekTwo
{
    // Challenge 11: https://leetcode.com/problems/sort-colors/
    // LC 75
    // Given an array with n objects colored red, white or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white and blue.
    // Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
    // Note: You are not suppose to use the library's sort function for this problem.
    // Example:
    // Input: [2,0,2,1,1,0]
    // Output: [0,0,1,1,2,2]

    public class SortColors
    {
        public static void Init()
        {
            SortUsingApproach2(new[] { 2, 1, 0, 1, 2, 0, 1 });
        }


        #region Approach 1: Two Pass Approach

        /*
         * Two Pass Approach
         * First Pass to get the count of each color
         * Second pass to fill the array
         */

        #endregion

        #region Approach 2: Sort

        /*
         * Sort array (This is not allowed to solve as it is just in built)
         */

        #endregion

        #region Approach 2: One Pass Approach

        private static void SortUsingApproach2(int[] nums)
        {
            var p0 = 0;
            var p2 = nums.Length - 1;
            var p = 0;

            while (p <= p2)
            {
                if (nums[p] == 0)
                {
                    nums[p] = nums[p0];
                    nums[p0] = 0;
                    p++;
                    p0++;
                }
                else if (nums[p] == 1)
                {
                    p++;
                }
                else
                {
                    nums[p] = nums[p2];
                    nums[p2] = 2;
                    p2--;
                }
            }

        }

        #endregion
    }
}
