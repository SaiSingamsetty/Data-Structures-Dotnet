using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFour
{
    public class PossibleBiPartition
    {
        public static void Init()
        {
            Check(4, new[] {new[] {1, 2}, new[] {1, 3}, new[] {2, 4}});
        }

        private static bool Check(int N, int[][] dislikes)
        {
            var groups = new int[N];
            Array.Fill(groups, -1);

            var adj = new List<int>[N];

            for (var i = 0; i < N; i++) adj[i] = new List<int>();

            foreach (var p in dislikes)
            {
                adj[p[0] - 1].Add(p[1] - 1);
                adj[p[1] - 1].Add(p[0] - 1);
            }

            for (var i = 0; i < N; ++i)
                if (groups[i] == -1 && !dfs(adj, groups, i, 0))
                    return false;

            return true;
        }

        private static bool dfs(List<int>[] adj, int[] groups, int v, int grp)
        {
            if (groups[v] == -1)
                groups[v] = grp;
            else
                return groups[v] == grp;

            foreach (var n in adj[v])
                if (!dfs(adj, groups, n, 1 - grp))
                    return false;

            return true;
        }
    }
}