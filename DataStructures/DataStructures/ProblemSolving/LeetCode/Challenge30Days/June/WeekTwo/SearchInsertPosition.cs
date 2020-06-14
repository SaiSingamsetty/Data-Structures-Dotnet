namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekTwo
{
    // Challenge 10:https://leetcode.com/problems/search-insert-position/
    // LC 35
    // Given a sorted array and a target value, return the index if the target is found.
    // If not, return the index where it would be if it were inserted in order.
    // You may assume no duplicates in the array.
    // Example 1:
    // Input: [1,3,5,6], 5
    // Output: 2
    // Example 2:
    // Input: [1,3,5,6], 2
    // Output: 1
    // Example 3:
    // Input: [1,3,5,6], 7
    // Output: 4

    public class SearchInsertPosition
    {
        public static void Init()
        {
            var res1 = FindUsingApproach1(new[] { 1, 2, 3, 5, 7 }, 5);
            var res2 = FindUsingApproach1(new[] { 1, 2, 3, 5, 7 }, 6);
            var res3 = FindUsingApproach2(new[] { 1, 3, 5, 6 }, 5); //2
            var res4 = FindUsingApproach2(new[] { 1, 3, 5, 6 }, 2); //1
            var res5 = FindUsingApproach2(new[] { 1, 3, 5, 6 }, 7); //4
            var res6 = FindUsingApproach2(new[] { 1, 3, 5, 6 }, 0); //0
        }

        #region Approach 1: TC: O(N), SC : O(1)
        
        private static int FindUsingApproach1(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                {
                    return i;
                }
            }
            return nums.Length;
        }

        #endregion

        #region Approach 2: Binary Search TC: O(logN)

        private static int FindUsingApproach2(int[] nums, int target)
        {
            var start = 0;
            var end = nums.Length - 1;

            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                if (nums[mid] == target)
                    return mid;

                if (target < nums[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return start;
        }

        #endregion

    }
}
