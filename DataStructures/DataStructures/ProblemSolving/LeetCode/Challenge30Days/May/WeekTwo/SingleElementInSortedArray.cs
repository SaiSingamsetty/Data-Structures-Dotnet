namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekTwo
{
    // Challenge 12: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3327/
    // You are given a sorted array consisting of only integers where every element appears exactly twice, except for one element which appears exactly once. Find this single element that appears only once.
    // Input: [1,1,2,3,3,4,4,8,8]
    // Output: 2
    // Note: Your solution should run in O(log n) time and O(1) space.

    public class SingleElementInSortedArray
    {
        public static void Init()
        {
            var res1 = SingleNonDuplicateApproach3(new[] {1, 1, 2, 2, 3, 3, 4, 5, 5});
            var res2 = SingleNonDuplicate(new[] {1});
            var res3 = SingleNonDuplicate(new[] {1, 1, 2});
        }

        #region Approach 1: Counter And Pointer Approach TC: O(M) where M can be less or equal to N, SC: O(1)

        private static int SingleNonDuplicate(int[] nums)
        {
            var pointer = int.MinValue;
            var counter = 0;

            foreach (var num in nums)
            {
                if (pointer == int.MinValue)
                    pointer = num;
                if (pointer == num)
                {
                    counter++;
                }
                else
                {
                    if (counter == 1)
                        return pointer;
                    counter = 1;
                    pointer = num;
                }
            }

            return pointer;
        }

        #endregion

        #region Approach 2: Using XOR TC: O(N), SC: O(1)

        private static int SingleNonDuplicateApproach2(int[] nums)
        {
            if (nums.Length == 0)
                return -1;

            var res = nums[0];

            for (var i = 1; i < nums.Length; i++)
                res ^= nums[i];

            return res;
        }

        #endregion

        #region Approach 3: Binary Search Approach O(logn)

        public static int SingleNonDuplicateApproach3(int[] nums)
        {
            var low = 0;
            var high = nums.Length - 1;
            while (low < high)
            {
                var mid = low + (high - low) / 2;
                if (mid % 2 == 1) mid--;
                if (nums[mid + 1] == nums[mid]) low = mid + 2;
                else high = mid;
            }

            return nums[low];
        }

        #endregion

        #region Approoach 4: Alternate Skip (O(N/2))

        public static int SingleNonDuplicateApproach1(int[] nums)
        {
            for (var i = 0; i < nums.Length - 1; i += 2)
                if (nums[i] != nums[i + 1])
                    return nums[i];

            return nums[nums.Length - 1];
        }

        #endregion
    }
}