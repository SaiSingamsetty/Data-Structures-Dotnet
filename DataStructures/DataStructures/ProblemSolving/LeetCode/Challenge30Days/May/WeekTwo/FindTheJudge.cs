using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekTwo
{
    // Challenge 10: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/535/week-2-may-8th-may-14th/3325/
    // In a town, there are N people labeled from 1 to N.  There is a rumor that one of these people is secretly the town judge.
    // If the town judge exists, then:
    // The town judge trusts nobody.
    // Everybody (except for the town judge) trusts the town judge.
    // There is exactly one person that satisfies properties 1 and 2.
    // You are given trust, an array of pairs trust[i] = [a, b] representing that the person labeled a trusts the person labeled b.
    // If the town judge exists and can be identified, return the label of the town judge.  Otherwise, return -1.
    // Example 1:
    // Input: N = 2, trust = [[1,2]]
    // Output: 2
    // Example 2:
    // Input: N = 3, trust = [[1,3],[2,3]]
    // Output: 3
    // Example 3:
    // Input: N = 3, trust = [[1,3],[2,3],[3,1]]
    // Output: -1
    // Example 4:
    // Input: N = 3, trust = [[1,2],[2,3]]
    // Output: -1
    // Example 5:
    // Input: N = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]]
    // Output: 3
    // Note:
    // 1 <= N <= 1000
    // trust.length <= 10000
    // trust[i] are all different
    // trust[i][0] != trust[i][1]
    // 1 <= trust[i][0], trust[i][1] <= N

    public class FindTheJudge
    {
        public static void Init()
        {
            var res1 = FindUsingApproach1(4, new[]
            {
                new[] {1, 3},
                new[] {1, 4},
                new[] {2, 3},
                new[] {2, 4},
                new[] {4, 3}
            });
            var res2 = FindUsingApproach2(4, new[]
            {
                new[] {1, 3},
                new[] {1, 4},
                new[] {2, 3},
                new[] {2, 4},
                new[] {4, 3}
            });
        }

        #region Approach 1: Using Dictionary

        private static int FindUsingApproach1(int N, int[][] trust)
        {
            if (!trust.Any())
                return N;

            var lookUp = new Dictionary<int, int>();
            var pointerForCandidate = -1;

            foreach (var eachTrust in trust)
            {
                var people = eachTrust[0];
                var candidate = eachTrust[1];

                if (!lookUp.ContainsKey(people))
                {
                    lookUp[people] = -1;
                }
                else
                {
                    lookUp[people]--;
                    if (pointerForCandidate == people)
                        pointerForCandidate = -1;
                }

                if (!lookUp.ContainsKey(candidate))
                {
                    lookUp[candidate] = 1;
                    if (lookUp[candidate] == N - 1)
                        pointerForCandidate = candidate;
                }
                else
                {
                    lookUp[candidate]++;
                    if (lookUp[candidate] == N - 1)
                        pointerForCandidate = candidate;
                }
            }

            return pointerForCandidate;
        }

        #endregion

        #region Approach 2: Using Arrays

        private static int FindUsingApproach2(int N, int[][] trust)
        {
            if (trust.Length < N - 1)
            {
                return -1;
            }

            var beingPublic = new int[N + 1];
            var beingJudge = new int[N + 1];

            foreach (var relation in trust)
            {
                var people = relation[0];
                var candidate = relation[1];
                beingPublic[people]++;
                beingJudge[candidate]++;
            }

            for (var i = 1; i <= N; i++)
            {
                if (beingJudge[i] == N - 1 && beingPublic[i] == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion
    }
}