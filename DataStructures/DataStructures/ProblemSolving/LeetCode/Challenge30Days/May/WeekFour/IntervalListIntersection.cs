using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFour
{
    // Challenge 23: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3338/
    // Given two lists of closed intervals, each list of intervals is pairwise disjoint and in sorted order.
    // Return the intersection of these two interval lists.
    // (Formally, a closed interval [a, b] (with a <= b) denotes the set of real numbers x with a <= x <= b.  The intersection of two closed intervals is a set of real numbers that is either empty, or can be represented as a closed interval.  For example, the intersection of [1, 3] and [2, 4] is [2, 3].)
    // Input: A = [[0,2],[5,10],[13,23],[24,25]], B = [[1,5],[8,12],[15,24],[25,26]]
    // Output: [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]

    public class IntervalListIntersection
    {
        public static void Init()
        {
            var a1 = new int[4][];
            a1[0] = new[] {0, 2};
            a1[1] = new[] {5, 10};
            a1[2] = new[] {13, 23};
            a1[3] = new[] {24, 25};

            var b1 = new int[4][];
            b1[0] = new[] {1, 5};
            b1[1] = new[] {8, 12};
            b1[2] = new[] {15, 24};
            b1[3] = new[] {25, 26};

            var res1 = Find(a1, b1);
        }

        private static int[][] Find(int[][] A, int[][] B)
        {
            var aPointer = 0; // {0, 2}  or  {3, 5}
            var bPointer = 0; // {1, 5}  or  {1, 4}
            var output = new List<int[]>();

            while (aPointer < A.Length && bPointer < B.Length)
            {
                if (A[aPointer][1] >= B[bPointer][0] && A[aPointer][0] < B[bPointer][1]
                    ||
                    A[aPointer][0] <= B[bPointer][1] && A[aPointer][1] > B[bPointer][0])
                    output.Add(new[]
                        {Math.Max(A[aPointer][0], B[bPointer][0]), Math.Min(A[aPointer][1], B[bPointer][1])});
                if (A[aPointer][1] < B[bPointer][1])
                    aPointer++;
                else
                    bPointer++;
            }

            return output.ToArray();
        }
    }
}