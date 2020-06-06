using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFive
{
    // Challenge 30: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/538/week-5-may-29th-may-31st/3345/
    // We have a list of points on the plane.  Find the K closest points to the origin (0, 0).
    // (Here, the distance between two points on a plane is the Euclidean distance.)
    // You may return the answer in any order.  The answer is guaranteed to be unique (except for the order that it is in.)

    // Input: points = [[1,3],[-2,2]], K = 1
    // Output: [[-2,2]]
    // Explanation: 
    // The distance between (1, 3) and the origin is sqrt(10).
    // The distance between (-2, 2) and the origin is sqrt(8).
    // Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
    // We only want the closest K = 1 points from the origin, so the answer is just [[-2,2]].

    // Input: points = [[3,3],[5,-1],[-2,4]], K = 2
    // Output: [[3,3],[-2,4]]
    // (The answer [[-2,4],[3,3]] would also be accepted.)

    public class ClosestPoints
    {
        public static void Init()
        {
            var input1 = new int[2][];
            input1[0] = new[] {1, 3};
            input1[1] = new[] {-2, 2};
            var res1 = FindUsingApproach1(input1, 1);
        }

        #region Approach 1: TC: O(NlogN)

        private static int[][] FindUsingApproach1(int[][] points, int K)
        {
            var lookUp = new Dictionary<int, double>();

            for (var i = 0; i < points.Length; i++)
            {
                var sum = Math.Pow(points[i][0], 2) + Math.Pow(points[i][1], 2);
                lookUp.Add(i, sum);
            }

            var sortedLookUp = lookUp.OrderBy(x => x.Value).ToList();
            var arr = new int[K][];

            for (var i = 0; i < K; i++)
            {
                var keyValue = sortedLookUp.ElementAt(i);
                var point = points[keyValue.Key];
                arr[i] = new[] {point[0], point[1]};
            }

            return arr;
        }

        #endregion

        #region Approach 2: Optimized code of Approach 1

        private static int[][] FindUsingApproach2(int[][] points, int K)
        {
            return points.ToList().OrderBy(p => FindDistanceFromOrigin(p[0], p[1])).Take(K).ToArray();
        }

        private static double FindDistanceFromOrigin(int x, int y)
        {
            // Ignoring square root for comparisons
            return Math.Pow(x, 2.0) + Math.Pow(y, 2.0);
        }

        #endregion
    }
}