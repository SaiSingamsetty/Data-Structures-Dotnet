using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekThree
{
    //Challenge17: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/530/week-3/3302/
    //Given a 2d grid map of '1's (land) and '0's (water), count the number of islands.
    //An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
    //You may assume all four edges of the grid are all surrounded by water.

    public class NoOfIslands
    {
        public static void Init()
        {
            var arr = new[]
            {
                new[] {'1', '1', '0', '0', '0'},
                new[] {'1', '1', '0', '0', '0'},
                new[] {'0', '0', '1', '0', '0'},
                new[] {'0', '0', '0', '1', '1'}
            };
            var res = FindNoOfIslandsUsingDepthFirstApproach(arr);
            Console.WriteLine(res);
        }

        //Reference: https://www.youtube.com/watch?v=__98uL6wst8
        private static int FindNoOfIslandsUsingDepthFirstApproach(char[][] grid)
        {
            var rows = grid.Length;
            if (rows == 0)
                return 0;

            var cols = grid[0].Length;

            var noOfIslands = 0;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        MarkFieldAsVisited(grid, i, j, rows, cols);
                        noOfIslands++;
                    }
                }

            }

            return noOfIslands;
        }

        private static void MarkFieldAsVisited(char[][] grid, int x, int y, int rows, int cols)
        {
            if (x < 0 || y < 0 || x >= rows || y >= cols || grid[x][y] != '1')
                return;

            grid[x][y] = '2';

            MarkFieldAsVisited(grid, x + 1, y, rows, cols);
            MarkFieldAsVisited(grid, x - 1, y, rows, cols);
            MarkFieldAsVisited(grid, x, y + 1, rows, cols);
            MarkFieldAsVisited(grid, x, y - 1, rows, cols);

        }
    }
}
