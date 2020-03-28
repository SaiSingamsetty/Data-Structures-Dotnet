using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving
{
    //LEETCODE https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/646/
    /*
       Input: [1,2,3,4,5,6,7] and k = 3
       Output: [5,6,7,1,2,3,4]
       Explanation:
       rotate 1 steps to the right: [7,1,2,3,4,5,6]
       rotate 2 steps to the right: [6,7,1,2,3,4,5]
       rotate 3 steps to the right: [5,6,7,1,2,3,4]
     */

    public class RotateArrayByNSteps
    {
        public static void Init()
        {
            var inputArray = new[] { 1, 2, 3, 4, 5, 6, 7};
            const int n = 3;
            var response = RotateArrayByGivenNoOfSteps(inputArray, n);
            Console.WriteLine(string.Join(' ', response));
        }

        private static IEnumerable<int> RotateArrayByGivenNoOfSteps(int[] nums, int k)
        {
            k %= nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
            return nums;
        }

        private static void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                var temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
    }
}
