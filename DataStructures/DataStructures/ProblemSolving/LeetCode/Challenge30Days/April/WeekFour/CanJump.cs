using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekFour
{
    // Challenge25: https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3310/
    // Given an array of non-negative integers, you are initially positioned at the first index of the array. 
    // Each element in the array represents your maximum jump length at that position. 
    // Determine if you are able to reach the last index.
    // Input: [2,3,1,1,4]
    // Output: true
    // Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
    // Input: [3,2,1,0,4]
    // Output: false
    // Explanation: You will always arrive at index 3 no matter what. Its maximum
    // jump length is 0, which makes it impossible to reach the last index.


    public class CanJump
    {
        public static void Init()
        {
            var input1 = new[] {0, 1};
            var res1 = CanJumpThrough(input1);

            var input2 = new[] {2, 3, 1, 1, 4};
            var res2 = CanJumpThrough(input2);
        }

        // https://www.youtube.com/watch?v=muDPTDrpS28
        // Peak and Valley approach
        // For every point check the maximum reach-ability.

        private static bool CanJumpThrough(int[] nums)
        {
            var reachable = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                // If the pointer crosses the max reachable index (for every point till now ) return false
                // For ex, Max reachable index is 6, the pointer is at 7 now
                // the pointer is at such a position where we cant jump from any 
                // index in the array to the current pointer (7), So return false.
                if (i > reachable)
                    return false;

                var maxIndexReachForThisNum = i + nums[i];
                if (maxIndexReachForThisNum > reachable)
                    reachable = maxIndexReachForThisNum;
            }

            return true;
        }
    }
}