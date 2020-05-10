using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekTwo
{
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
