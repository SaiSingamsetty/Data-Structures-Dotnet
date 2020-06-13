using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.DynamicProgramming
{
    public class HouseRobber
    {
        public static void Init()
        {
            var res1 = RobUsingApproach1(new[] { 2, 7, 9, 3, 1 });
            var res2 = RobUsingApproach2(new[] { 2, 7, 9, 3, 1 });
            var res3 = RobUsingApproach3(new[] { 2, 7, 9, 3, 1 });
            var res4 = RobUsingApproach4(new[] { 2, 7, 9, 3, 1 });
        }


        #region Approach 1: Start from being Recursive [Time Limit Exceeded]

        // Figure out recursive relation.
        // A robber has 2 options: a) rob current house  b) don't rob current house.
        // If an option "a" is selected it means she can't rob previous i-1 house
        // but can safely proceed to the one before previous i-2 and gets all cumulative loot that follows.
        // If an option "b" is selected the robber gets all the possible loot from robbery of i-1 and all the following buildings.
        // So it boils down to calculating what is more profitable:
        // - robbery of current house + loot from houses before the previous
        // - loot from the previous house robbery and any loot captured before that
        // rob(i) = Math.max( rob(i - 2) + currentHouseValue, rob(i - 1) )


        private static int RobUsingApproach1(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            return HelperApp1(nums, nums.Length - 1);
        }

        private static int HelperApp1(int[] nums, int pointer)
        {
            if (pointer < 0)
                return 0;

            return Math.Max(HelperApp1(nums, pointer - 2) + nums[pointer], HelperApp1(nums, pointer - 1));
        }

        #endregion

        #region Approach 2: Recursive + Memoization (Top-Down) TC: O(N)

        // As the prev approach is exceeding time limit, we will try saving some pre calculated results
        // For Ex, { 2, 7, 9, 3, 1 }
        //
        // Our Recursion: [Max of (Rob(i-2) + curValue) or Rob(i-1)]
        // We calculate the value of '2' when calculating for value '9'   (Rob(i-2))
        // We calculate the value of '2' again when calculating for value '7'   (Rob(i-1))
        // If we memoize these values, we can save some time

        private static int[] _memo;

        private static int RobUsingApproach2(int[] nums)
        {
            _memo = new int[nums.Length + 1];
            Array.Fill(_memo, -1);
            return HelperApp2(nums, nums.Length - 1);
        }

        private static int HelperApp2(int[] nums, int pointer)
        {
            if (pointer < 0)
                return 0;

            if (_memo[pointer] >= 0)
                return _memo[pointer];

            var tempRes = Math.Max(HelperApp2(nums, pointer - 2) + nums[pointer], HelperApp2(nums, pointer - 1));
            _memo[pointer] = tempRes;
            return tempRes;
        }

        #endregion

        #region Approach 3: Iterative + Memoization (Bottom-Up)

        private static int RobUsingApproach3(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            var memo = new int[nums.Length + 1];
            memo[0] = 0;
            memo[1] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                memo[i + 1] = Math.Max(memo[i], memo[i - 1] + nums[i]);
            }

            return memo[nums.Length];
        }

        #endregion

        #region Approach 4: Iterative + Two Variables (Bottom-Up)

        private static int RobUsingApproach4(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            var prev1 = 0;
            var prev2 = 0;
            foreach (var num in nums)
            {
                var tmp = prev1;
                prev1 = Math.Max(prev2 + num, prev1);
                prev2 = tmp;
            }
            return prev1;
        }

        #endregion

    }
}
