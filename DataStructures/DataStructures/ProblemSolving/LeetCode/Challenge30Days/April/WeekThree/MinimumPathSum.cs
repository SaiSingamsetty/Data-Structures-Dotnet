using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekThree
{
    //Challenge18: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/530/week-3/3303/
    //Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
    // Note: You can only move either down or right at any point in time.

    //Input:
    // [
    // [1,3,1],
    // [1,5,1],
    // [4,2,1]
    // ]
    // Output: 7
    // Explanation: Because the path 1→3→1→1→1 minimizes the sum.


    public class MinimumPathSum
    {
        public static void Init()
        {
            var arr = new[]
            {
                new[] {1, 2, 5},
                new[] {3, 2, 1}
                //new[] {4, 2, 1}
            };
            Console.WriteLine(FindMinimumPathSum(arr));
        }

        //Recursive Approach
        // minCost(m, n) = min (minCost(m-1, n-1), minCost(m-1, n), minCost(m, n-1)) + cost[m][n]
        // Time complexity of this naive recursive solution is exponential and it is terribly slow.

        private static int FindMinimumPathSum(int[][] grid)
        {
            var rows = grid.Length;
            if (rows == 0)
                return 0;

            var cols = grid[0].Length;
            var tempGrid = new int[rows, cols];
            tempGrid[0, 0] = grid[0][0];

            //Fill first row
            for (var i = 1; i < cols; i++) tempGrid[0, i] = tempGrid[0, i - 1] + grid[0][i];

            //Fill first col
            for (var i = 1; i < rows; i++) tempGrid[i, 0] = tempGrid[i - 1, 0] + grid[i][0];

            //Fill other cells
            for (var i = 1; i < rows; i++)
            for (var j = 1; j < cols; j++)
                tempGrid[i, j] = grid[i][j] + Math.Min(tempGrid[i - 1, j], tempGrid[i, j - 1]);

            return tempGrid[rows - 1, cols - 1];
        }
    }
}