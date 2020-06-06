using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne
{
    // LC169: https://leetcode.com/problems/majority-element/
    // Challenge 6: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3320/
    // Given an array of size n, find the majority element.
    // The majority element is the element that appears more than n/2 times.
    // You may assume that the array is non-empty and the majority element always exist in the array.

    public class MajorityElement
    {
        public static void Init()
        {
            Console.WriteLine(FindMajorityElementUsingBmAlgo(new[] {2, 2, 1, 1, 1, 2, 2}));
        }

        #region Approach 1 : Using Dictionary TC: O(n), SC: O(n) 

        private static int FindMajorityElementUsingDict(int[] nums)
        {
            if (nums.Length == 0)
                return -1;
            if (nums.Length == 1)
                return nums[0];

            var threshold = nums.Length / 2;
            var dict = new Dictionary<int, int>();

            foreach (var eachNum in nums)
                if (!dict.ContainsKey(eachNum))
                {
                    dict.Add(eachNum, 1);
                }
                else
                {
                    dict[eachNum]++;
                    if (dict[eachNum] > threshold)
                        return eachNum;
                }

            return -1;
        }

        #endregion

        #region Approach 2 Boyer-Moore Voting Algorithm TC: O(n), SC: O(1)

        private static int FindMajorityElementUsingBmAlgo(int[] nums)
        {
            var count = 0;
            var candidate = -1;

            // With this loop we will finally get the majority element
            foreach (var eachNum in nums)
            {
                if (count == 0)
                    candidate = eachNum;

                var temp = candidate == eachNum ? 1 : -1;
                count = count + temp;
            }

            //This loop just confirms the majority element is really majority
            count = 0;
            foreach (var eachNum in nums)
                if (eachNum == candidate)
                    count++;

            return count > nums.Length / 2 ? candidate : int.MinValue;
        }

        #endregion

        #region Approach 3: Sorting TC: O(nlogn), SC: O(1)

        // For any value of n, the majority element will be available at n/2 position
        // For n = 5, _ _ _ _ _ : as the majority element exists for sure. It should repeat
        // for more than n/2 times :- >= 2 ( 3, 4..) 
        // Trying to fill majority element from start or end of n=5 array. It will occupy index 2 position
        // For n= 4, possible cases: >= n/2 (3, 4)
        // Here also it occupies n/2 
        // no matter what value the majority element has in relation to the rest of the array,
        // returning the value at n/2 will never be wrong

        private static int FindMajorityElementBySorting(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }

        #endregion
    }
}