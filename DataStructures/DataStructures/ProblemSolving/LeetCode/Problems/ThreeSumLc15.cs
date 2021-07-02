using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    //https://leetcode.com/problems/3sum/

    public static class ThreeSumLc15
    {
        public static void Execute()
        {
            var res1 = Find(new[] { -1, 0, 1, 2, -1, -4 }, 0);
            var res2 = Find(new[] { 0, 0, 0 }, 0); // [0, 0, 0]
        }
        
        private static IList<IList<int>> Find(int[] nums, int target)
        {
            //Sorting will bring same numbers in the array next to each other.
            Array.Sort(nums);

            IList<IList<int>> res = new List<IList<int>>();
            for (int pivot = 0; pivot < nums.Length; pivot++)
            {
                //No need to pivot on the same number as the one previously used.
                if (pivot > 0 && nums[pivot] == nums[pivot - 1])
                {
                    continue;
                }
                
                int targetSum = target - (nums[pivot]);

                int startIndex = pivot + 1;
                int endIndex = nums.Length - 1;

                while (startIndex < endIndex)
                {
                    int sumOfValuesAtStartAndEndIndex = nums[startIndex] + nums[endIndex];
                    if (sumOfValuesAtStartAndEndIndex == targetSum)
                    {
                        res.Add(new int[] { nums[pivot], nums[startIndex], nums[endIndex] });

                        //No need to look at the same number if its already is in the result.
                        while (startIndex < endIndex && nums[startIndex] == nums[startIndex + 1])
                        {
                            startIndex++;
                        }

                        //No need to look at the same number if its already is in the result.
                        while (startIndex < endIndex && nums[endIndex] == nums[endIndex - 1])
                        {
                            endIndex--;
                        }

                        startIndex++;
                        endIndex--;
                    }
                    else
                    {
                        //If sumOfValuesAtStartAndEndIndex is less than the targetSum,
                        //we need to increase the sumOfValuesAtStartAndEndIndex
                        //by taking the next big number.
                        if (sumOfValuesAtStartAndEndIndex < targetSum)
                        {
                            startIndex++;
                        }
                        //Else we need to decrease the sumOfValuesAtStartAndEndIndex,
                        //by taking the next smaller number.
                        else
                        {
                            endIndex--;
                        }
                    }
                }
            }

            return res;
        }
        
    }
}
