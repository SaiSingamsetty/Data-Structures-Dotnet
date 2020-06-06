using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekOne
{
    // Challenge 3: https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3349/
    // There are 2N people a company is planning to interview. The cost of flying the i-th person to city A is costs[i][0],
    // and the cost of flying the i-th person to city B is costs[i][1].
    // Return the minimum cost to fly every person to a city such that exactly N people arrive in each city.
    // Input: [[10,20],[30,200],[400,50],[30,20]]
    // Output: 110
    // Explanation: 
    // The first person goes to city A for a cost of 10.
    // The second person goes to city A for a cost of 30.
    // The third person goes to city B for a cost of 50.
    // The fourth person goes to city B for a cost of 20. 
    // The total minimum cost is 10 + 30 + 50 + 20 = 110 to have half the people interviewing in each city.

    public class TwoCityScheduling
    {
        public static void Init()
        {
            var res1 = FindUsingApproach1(new[] {new[] {10, 20}, new[] {30, 200}, new[] {400, 50}, new[] {30, 20}});
            var res2 = FindUsingApproach2(new[] {new[] {10, 20}, new[] {30, 200}, new[] {400, 50}, new[] {30, 20}});
        }

        #region Approach 1: TC: 3*O(N) where N is costs length

        private static int FindUsingApproach1(int[][] costs)
        {
            var minimumSum = 0;
            var totalCount = costs.Length;
            var lookUp = new Dictionary<int[], int>();

            foreach (var eachPair in costs)
            {
                var benefit = eachPair[1] - eachPair[0];
                lookUp.Add(eachPair, benefit);
            }

            var sortedLookup = lookUp.OrderByDescending(x => x.Value).ToList();

            for (var i = 0; i < sortedLookup.Count(); i++)
                if (i < totalCount / 2)
                    minimumSum += sortedLookup[i].Key[0];
                else
                    minimumSum += sortedLookup[i].Key[1];

            return minimumSum;
        }

        #endregion

        #region Approach 2 TC: 2*O(N) where N is costs length

        private static int FindUsingApproach2(int[][] costs)
        {
            var sum = 0;

            Array.Sort(costs, (a, b) => a[0] - a[1] - (b[0] - b[1]));
            var n = costs.Length / 2;

            for (var i = 0; i < n; i++)
                sum += costs[i][0];
            for (var i = n; i < 2 * n; i++)
                sum += costs[i][1];

            //for (var i = 0; i < n; i++)
            //{
            //    sum += costs[i][0] + costs[n + i][1];
            //}

            return sum;
        }

        #endregion
    }
}