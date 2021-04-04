using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Arrays
{
    public static class HourGlassSum
    {
        public static void Execute()
        {
            
        }

        private static int Sum(int[][] mat)
        {
            const int r = 6;
            const int c = 6;

            var maxSum = int.MinValue;
            for (var i = 0; i < r - 2; i++)
            {
                for (var j = 0; j < c - 2; j++)
                {
                    // Considering mat[i][j] as top
                    // left cell of hour glass.
                    var sum = (mat[i][j] + mat[i][j + 1] +
                               mat[i][j + 2]) + (mat[i + 1][j + 1]) +
                              (mat[i + 2][j] + mat[i + 2][j + 1] +
                               mat[i + 2][j + 2]);

                    // If previous sum is less then
                    // current sum then update
                    // new sum in max_sum
                    maxSum = Math.Max(maxSum, sum);
                }
            }
            return maxSum;
        }
    }
}
