using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFour
{
    // Challenge26: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3341/
    // Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.
    // Input: [0,1,0]
    // Output: 2
    // Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.

    // Reference: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/529/week-2/3298/discuss/99655/Python-O(n)-Solution-with-Visual-Explanation

    public class ContiguousArray
    {
        public static void Init()
        {
            var arr = new[] { 0, 1, 0, 0, 1, 1, 0 };
            var response = MaxLengthOfContiguousArray(arr);
            Console.WriteLine(response);
        }

        private static int MaxLengthOfContiguousArray(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            var count = 0;
            var maxLength = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                count += (nums[i] == 0 ? -1 : 1);

                if (dict.ContainsKey(count))
                    maxLength = Math.Max(maxLength, i - dict[count]);
                else
                    dict[count] = i;

                if (count == 0) //If count ever becomes 0 that means from start till current index i, we have max contiguous array. 
                    maxLength = i + 1;
            }

            return maxLength;
        }
    }
}