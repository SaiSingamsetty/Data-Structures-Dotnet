using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    public static class LongestIncreasingSubSequence
    {
        public static void Execute()
        {
            var res1 = FindUsingRecursiveApproach(new int[] { -1, 4, 3, 5, 2, 8 });
        }

        //Dynamic Programming
        private static int FindUsingApproach1(int[] arr)
        {
            var longest = 1; //at-least length of 1 is obvious
            var lis = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                lis[i] = 1;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    //LIS at i should be less than (LIS at j) + 1
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                    {
                        //if the condition satisfies
                        //LIS at i should be 1 + LIS at j
                        lis[i] = lis[j] + 1;
                        if (longest < lis[i])
                            longest = lis[i];
                    }
                }
            }

            return longest;
        }

        //Recursion TE: O(2*n) SE: O(n)
        private static int FindUsingRecursiveApproach(int[] arr)
        {
            var output = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                output = Math.Max(output, RecursionHelper(arr, i));
            }

            return output;
        }

        private static int RecursionHelper(int[] arr, int index)
        {
            var output = 1;
            if (index <= 0)
                return output;

            for (int i = index - 1; i >= 0; i--)
            {
                if (arr[i] < arr[index])
                {
                    output = Math.Max(output, 1 + RecursionHelper(arr, i));
                }
            }

            return output;
        }
    }
}
