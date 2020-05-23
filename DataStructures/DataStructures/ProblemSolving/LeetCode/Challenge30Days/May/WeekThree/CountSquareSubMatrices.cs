using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekThree
{
    // Challenge 21 : https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3336/
    // Given a m * n matrix of ones and zeros, return how many square sub-matrices have all ones.
    // Input: matrix =
    // [
    // [0,1,1,1],
    // [1,1,1,1],
    // [0,1,1,1]
    // ]
    // Output: 15
    // Explanation: 
    // There are 10 squares of side 1.
    // There are 4 squares of side 2.
    // There is  1 square of side 3.
    // Total number of squares = 10 + 4 + 1 = 15.

    public class CountSquareSubMatrices
    {
        public static void Init()
        {
            var matrix1 = new int[3][];
            matrix1[0] = new[] { 1, 0, 1 };
            matrix1[1] = new[] { 1, 1, 0 };
            matrix1[2] = new[] { 1, 1, 0 };

            var res1 = Count(matrix1);
        }

        /*
         * Algorithm explained here
         * https://www.youtube.com/watch?v=Z2h3rkVXPeQ
         */

        private static int Count(int[][] matrix)
        {
            var rowCount = matrix.Length;
            var colCount = matrix[0].Length;

            var copyMatrix = new int[rowCount, colCount];
            var squareCounter = 0;

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < colCount; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        copyMatrix[i, j] = matrix[i][j];
                        squareCounter += copyMatrix[i, j];
                    }
                    else
                    {
                        if (matrix[i][j] == 0)
                            continue;

                        copyMatrix[i, j] = 1 + Math.Min(copyMatrix[i - 1, j - 1], Math.Min(copyMatrix[i - 1, j], copyMatrix[i, j - 1]));
                        squareCounter += copyMatrix[i, j];
                    }
                }
            }

            return squareCounter;
        }
    }
}
