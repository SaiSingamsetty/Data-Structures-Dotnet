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
            var arr = new[] {0, 1};
            Console.WriteLine(CanJumpThrough(arr));
        }

        //https://www.youtube.com/watch?v=muDPTDrpS28

        private static bool CanJumpThrough(int[] nums)
        {
            var reachable = 0;

            for (var i = 0; i < nums.Length; i++)
            {
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