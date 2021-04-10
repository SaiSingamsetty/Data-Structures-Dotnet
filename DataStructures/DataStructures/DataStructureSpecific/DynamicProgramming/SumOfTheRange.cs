using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    public static class SumOfTheRange
    {
        public static void Execute()
        {
            var res1 = Find(new int[] {1, 2, 3, 4}, 1, 2);
        }

        private static int Find(int[] arr, int i, int j)
        {
            /*
             * Sum from index i to j
             * can be found like
             * sum of elements till j - sum of elements till i-1
             */

            var sumUntilArray = new int[arr.Length];
            sumUntilArray[0] = arr[0];
            for (int k = 1; k < arr.Length; k++)
            {
                sumUntilArray[k] = sumUntilArray[k - 1] + arr[k];
            }

            return sumUntilArray[j] - sumUntilArray[i - 1];

        }
    }
}
