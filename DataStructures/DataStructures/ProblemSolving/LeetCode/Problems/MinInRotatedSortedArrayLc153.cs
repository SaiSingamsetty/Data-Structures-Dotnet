using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    public static class MinInRotatedSortedArrayLc153
    {
        public static void Execute()
        {
            var res1 = Find(new int[] {7, 8, 9, 10, 11, 1, 2}); //1
        }

        private static int Find(int[] arr)
        {
            var length = arr.Length;
            if (length == 1 || arr[0] < arr[length - 1])
            {
                return arr[0];
            }

            var res = BinSearch(arr, 0, length - 1);
            return res;
        }

        private static int BinSearch(int[] arr, int start, int end)
        {
            while (start < end)
            {
                int mid = (start + end) / 2;

                if (arr[mid] > arr[mid + 1])
                {
                    return arr[mid + 1];
                }

                if (arr[mid] > arr[start])
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }
            }

            return -1;
        }
    }
}
