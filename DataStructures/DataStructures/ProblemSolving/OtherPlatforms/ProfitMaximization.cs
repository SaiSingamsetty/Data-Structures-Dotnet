using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.OtherPlatforms
{
    //Drive - Cimpress - Online Round

    public static class ProfitMaximization
    {
        public static void Execute()
        {
            var res1 = Find(new[] {1, 2, 3, 4, 9, 8});
        }

        private static int Find(int[] p)
        {
            var length = p.Length;
            var dp = new int[length];

            for (int i = 0; i < length; i++)
            {
                dp[i] = p[i];
            }

            var maxSoFar = int.MinValue;
            for (int i = 1; i < length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (p[i] > p[j] && p[i] % p[j] == 0 && dp[i] < dp[j] + p[i])
                    {
                        dp[i] = dp[j] + p[i];
                        if (maxSoFar < dp[i])
                            maxSoFar = dp[i];
                    }
                }
            }

            return maxSoFar;
        }
    }
}
