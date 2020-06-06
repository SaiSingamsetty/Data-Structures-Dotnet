using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Arrays
{
    // LEETCODE: https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/578/
    // Given an array of integers, find if the array contains any duplicates.

    public class HasDuplicate
    {
        public static void Init()
        {
            var arr = new[] {1, 2, 3, 2};
            var resultThroughHashMethod = HasDuplicate_Hashtable(arr);
            Console.WriteLine("Result through Hash Method: " + resultThroughHashMethod);

            var resultThroughSortMethod = HasDuplicate_Sorting(arr);
            Console.WriteLine("Result through Sorting Method: " + resultThroughSortMethod);
        }

        private static bool HasDuplicate_Hashtable(int[] nums)
        {
            var hash = new HashSet<int>();

            foreach (var num in nums)
            {
                if (hash.Contains(num))
                    return true;
                hash.Add(num);
            }

            return false;
        }

        private static bool HasDuplicate_Sorting(int[] nums)
        {
            Array.Sort(nums);

            for (var i = 0; i + 1 < nums.Length; i++)
                if (nums[i] == nums[i + 1])
                    return true;

            return false;
        }
    }
}