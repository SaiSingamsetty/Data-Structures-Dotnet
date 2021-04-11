using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Sorting
{
    public static class MarkAndToys
    {
        public static void Execute()
        {
            var res1 = Find(new int[] {1, 2, 3, 4}, 7);
        }

        private static int Find(int[] prices, int k)
        {
            Array.Sort(prices);
            var arrPointer = 0;

            while (k > 0 && prices[arrPointer] <= k)
            {
                k = k - prices[arrPointer];
                arrPointer++;
            }

            return arrPointer;
        }
    }
}
