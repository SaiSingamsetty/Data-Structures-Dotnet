using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekThree
{
    // Challenge19: https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3304/
    // Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand. 
    // (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]). 
    // You are given a target value to search. If found in the array return its index, otherwise return -1. 
    // You may assume no duplicate exists in the array. 
    // Your algorithm's runtime complexity must be in the order of O(log n).
    // Input: nums = [4,5,6,7,0,1,2], target = 0
    // Output: 4

    public class SearchInRotatedSortedArray
    {
        public static void Init()
        {
            var arr = new int[] {4, 5, 6, 7, 0, 1, 2};
            Console.WriteLine(Search(arr, 0));
        }

        #region Approach 1

        private static int Search(int[] nums, int target)
        {
            var index = -1;

            if (nums.Length == 0)
                return index;

            if (target > nums[0])
            {
                for (var i = 0; i < nums.Length; i++)
                {
                    if (target == nums[i])
                        return i;
                }
            }
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                if (target == nums[i])
                    return i;
            }


            return index;
        }

        #endregion


        //Ref: https://www.youtube.com/watch?v=oTfPJKGEHcc&t=1s
        #region Approach 2 (O(logN) time complexity using Binary Search)

        private static int SearchInRotatedSortedArrayUsingBinarySearch(int[] nums, int target)
        {
            var size = nums.Length;
            var left = 0;
            var right = size - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (target == nums[mid])
                    return mid;

                //To check if the first half is strictly increasing
                if (nums[mid] >= nums[left])
                {
                    if (target >= nums[left] && target <= nums[mid])
                        right = mid - 1;
                    else
                    {
                        left = mid + 1;
                    }

                }
                //second half is strictly increasing
                else
                {
                    if (target >= nums[mid] && target <= nums[right])
                        left = mid + 1;
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }

        #endregion

    }
}
