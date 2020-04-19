using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekThree
{
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

    }
}
