using System;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Arrays
{
    // LEETCODE https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/549/
    //Challenge1
    /*
        Given a non-empty array of integers, every element appears twice except for one. Find that single one.
        Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
        
        Input: [2,2,1]
        Output: 1
    */

    public class SingleNumber
    {
        public static void Init()
        {
            var arr = new[] {1, 2, 3, 1, 3};
            var result = GetSingleNumber(arr);
            Console.WriteLine("Response:  " + result);
        }

        private static int GetSingleNumber(int[] nums)
        {
            for (var i = 0; i + 1 < nums.Length; i++)
            {
                nums[i + 1] = nums[i] ^ nums[i + 1];
            }

            return nums[nums.Length - 1];
        }
    }
}