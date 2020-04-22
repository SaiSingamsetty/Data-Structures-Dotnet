using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekFour
{
    // Challenge22: https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3307/
    // Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.
    // Input:nums = [1,1,1], k = 2
    // Output: 2

    public class SubArraySumEqualsK
    {
        public static void Init()
        {
            var arr = new[] { 3, 4, 7, 2, -3, 1, 4, 2 };
            Console.WriteLine(SubArraySum(arr, 7));
        }

        //https://www.youtube.com/watch?v=HbbYPQc-Oo4
        //https://www.geeksforgeeks.org/number-subarrays-sum-exactly-equal-k/

        private static int SubArraySum(int[] nums, int k)
        {
            var lookUp = new Dictionary<int, int>();
            var counter = 0;
            var sumTillNow = 0;

            foreach (var num in nums)
            {
                sumTillNow += num;

                if (sumTillNow == k)
                    counter++;

                if (lookUp.ContainsKey(sumTillNow - k))
                    counter += lookUp[sumTillNow - k];

                if (lookUp.ContainsKey(sumTillNow))
                {
                    lookUp[sumTillNow] += 1;
                }
                else
                {
                    lookUp.Add(sumTillNow, 1);
                }
                
            }

            return counter;
        }
    }
}
