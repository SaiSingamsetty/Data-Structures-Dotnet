using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFour
{
    // Challenge 25: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3340/
    // We write the integers of A and B (in the order they are given) on two separate horizontal lines.
    // Now, we may draw connecting lines: a straight line connecting two numbers A[i] and B[j] such that:
    // A[i] == B[j];
    // The line we draw does not intersect any other connecting (non-horizontal) line.
    // Note that a connecting lines cannot intersect even at the endpoints: each number can only belong to one connecting line.
    // Return the maximum number of connecting lines we can draw in this way.

    // Input: A = [1,4,2], B = [1,2,4]
    // Output: 2
    // Explanation: We can draw 2 uncrossed lines as in the diagram.
    // We cannot draw 3 uncrossed lines, because the line from A[1]=4 to B[2]=4 will intersect the line from A[2]=2 to B[1]=2.
    // Input: A = [1,3,7,1,7,5], B = [1,9,2,5,1]
    // Output: 2

    public class UncrossedLines
    {
        public static void Init()
        {
            var res1 = Find(new[] {1, 3, 7, 1, 7, 5}, new[] {1, 9, 2, 5, 1});
        }

        // https://www.youtube.com/watch?v=jLv-5coG-qQ
        // https://www.youtube.com/watch?v=duCx_62nMOA

        private static int Find(int[] A, int[] B)
        {
            var m = A.Length;
            var n = B.Length;

            var dp = new int[m+1,n+1];

            for (var i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    dp[i, j] = A[i - 1] == B[j - 1]
                        ? 1 + dp[i - 1, j - 1]
                        : Math.Max(dp[i, j - 1], dp[i - 1, j]);

                }
            }

            return dp[m, n];
        }
    }
}
