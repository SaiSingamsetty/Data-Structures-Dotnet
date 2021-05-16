using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    public static class SubSetSum
    {
        public static void Execute()
        {
            var test1 = FindUsingDynPro(new[] { 7, 3, 2, 5, 8 }, 14); //7,2,5
            var test2 = FindUsingDynPro(new[] { 8, 3, 2, 5, 8 }, 14); //7,2,5
        }

        //Naive
        //Find all subsets - 2 pow n and loop and check if matches the target : O(n * pow(2, n))

        //Recursion
        private static bool FindUsingRecursion(int[] arr, int target)
        {
            var output = RecursionHelper(arr, arr.Length - 1, target);
            return output;
        }

        private static bool RecursionHelper(int[] arr, int length, int target)
        {
            if (target == 0)
            {
                return true;
            }

            if (length < 0 || target < 0)
            {
                return false;
            }

            var include = RecursionHelper(arr, length - 1, target - arr[length]);
            var exclude = RecursionHelper(arr, length - 1, target);
            return include || exclude;
        }

        //Using Dynamic Programming - Bottom Up Approach
        private static bool FindUsingDynPro(int[] arr, int target)
        {
            Array.Sort(arr);

            //dp[i,j] : Answer with : arr of length i, target value of j
            var dp = new bool[arr.Length, target + 1];

            //For target as 0, empty sub array can be accepted answer, so TRUE for all cases where Target sum is 0
            for (int i = 0; i < arr.Length; i++)
            {
                dp[i, 0] = true;
            }

            //filling the first row
            for (int i = 1; i < target + 1; i++)
            {
                //Since in this case, only first value in the array is considered. It would be True at arr[0] 
                dp[0, arr[0]] = true;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 1; j < target + 1; j++)
                {
                    if (j < arr[i])
                    {
                        //ignore the current value as it is smaller than target, copy from above row
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        //either ignore current value OR include current value 
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - arr[i]];
                    }
                }
            }

            return dp[arr.Length - 1, target];
        }

    }
}
