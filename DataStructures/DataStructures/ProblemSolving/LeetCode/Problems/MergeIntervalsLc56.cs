using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    public static class MergeIntervalsLc56
    {
        public static void Execute()
        {
            var res1 = Merge(new int[3][]
            {
                new int[2]{1, 4},
                new int[2]{0, 2},
                new int[2]{3, 5},
                //new int[2]{15, 18}
            });

        }

        private static int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (x, y) => x[0] - y[0]);

            var output = new List<int[]> {intervals[0]};

            for (var i = 1; i < intervals.Length; i++)
            {
                var prevInterval = output.Last();
                var interval = intervals[i];

                if (interval[0] <= prevInterval[1])
                {
                    output.Last()[1] = Math.Max(interval[1], output.Last()[1]);
                }
                else
                {
                    output.Add(interval);
                }
            }

            return output.ToArray();
        }
    }
}
