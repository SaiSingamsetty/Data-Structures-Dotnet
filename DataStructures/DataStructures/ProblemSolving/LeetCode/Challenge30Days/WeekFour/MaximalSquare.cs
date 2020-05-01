using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekFour
{
    // Challenge 27: https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3312/
    // Given a 2D binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.

    public class MaximalSquare
    {
        public static void Init()
        {
            char[][] arr =
            {
                new[] {'0', '1', '1', '0', '1'},
                new[] {'1', '1', '1', '0', '0'},
                new[] {'1', '1', '1', '1', '0'},
                new[] {'1', '1', '1', '0', '1'}
            };
            Console.WriteLine(FindMaxSquare(arr));
        }

        #region Dynamic Programming; Time Complexity: O(m*n); Space Complexity: O(m*n)

        //https://www.youtube.com/watch?v=_Lf1looyJMU
        //https://www.geeksforgeeks.org/maximum-size-sub-matrix-with-all-1s-in-a-binary-matrix/

        // In order to be a 2 * 2 Matrix, its top, left, top left cells has to be 1 for sure.
        // We are taking min of all the three sides to ensure they are all 1's and it forms 2 * 2 Matrix.

        private static int FindMaxSquare(char[][] matrix)
        {
            var rows = matrix.Length;
            if (rows == 0)
                return 0;

            var cols = matrix[0].Length;

            var dpMatrix = new int[rows + 1, cols + 1];
            var largest = 0;

            for (var i = 1; i <= rows; i++)
            {
                for (var j = 1; j <= cols; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dpMatrix[i, j] = 1 + Math.Min(dpMatrix[i - 1, j],
                                             Math.Min(dpMatrix[i, j - 1], dpMatrix[i - 1, j - 1]));
                        if (largest < dpMatrix[i, j])
                            largest = dpMatrix[i, j];
                    }
                }
            }

            return largest * largest;
        }

        #endregion
    }
}