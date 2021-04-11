using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.GreedyAlgo
{
    public static class MinAbsDiffOfAnArray
    {
        public static void Execute()
        {
            var res1 = Find(new[] {-2, 2, 4});
            var res2 = Find(new[] { 1, -3, 71, 68, 17 });
        }

        private static int Find(int[] arr)
        {
            arr.MySort();

            var minDiff = int.MaxValue;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var diff = Math.Abs(arr[i] - arr[i + 1]);
                if (diff < minDiff)
                    minDiff = diff;
            }

            return minDiff;
        }

        private static void MySort(this int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        var temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
        }
    }
}
