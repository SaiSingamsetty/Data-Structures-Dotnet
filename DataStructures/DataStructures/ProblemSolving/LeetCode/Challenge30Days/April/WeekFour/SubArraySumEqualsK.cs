using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekFour
{
    // Challenge22: https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3307/
    // Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.
    // Input:nums = [1,1,1], k = 2
    // Output: 2

    public class SubArraySumEqualsK
    {
        public static void Init()
        {
            var arr = new[] {3, 4, 7, 2, -3, 1, 4, 2};
            Console.WriteLine("Count: " + SubArraySum_Approach2(arr, 7));
        }

        #region Approach 1 Using  Dictionary to store frequency of sum

        //https://www.youtube.com/watch?v=HbbYPQc-Oo4
        //https://www.geeksforgeeks.org/number-subarrays-sum-exactly-equal-k/
        //https://codeshare.io/2KR9qo
        //https://www.youtube.com/watch?v=YkacnIOt2jM **** Must watch

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

        #endregion

        #region Approach 2 Same as Approach 1 with Index Storage and Printing Sub arrays

        private static int SubArraySum_Approach2(int[] nums, int k)
        {
            var lookUp = new Dictionary<int, List<int>>
            {
                {0, new List<int>() {-1}}
            };

            var sumSoFar = 0;
            var counter = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                sumSoFar += nums[i];

                if (lookUp.ContainsKey(sumSoFar - k))
                {
                    var curList = lookUp[sumSoFar - k];
                    counter += curList.Count;

                    foreach (var i1 in curList)
                    {
                        PrintSubArray(nums, i1 + 1, i);
                    }
                }

                if (!lookUp.ContainsKey(sumSoFar))
                    lookUp.Add(sumSoFar, new List<int>() {i});
                else
                {
                    lookUp[sumSoFar].Add(i);
                }
            }

            return counter;
        }

        private static void PrintSubArray(int[] arr, int i, int j)
        {
            for (int k = i; k < j + 1; k++)
            {
                Console.Write(arr[k] + " ");
            }

            Console.WriteLine();
        }

        #endregion
    }
}