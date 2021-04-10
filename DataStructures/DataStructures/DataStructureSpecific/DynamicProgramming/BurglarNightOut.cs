using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    public static class BurglarNightOut
    {
        public static void Execute()
        {
            var res1 = FindUsingApproach1(new[] {2, 8, 4, 1}); //9
            var res2 = FindUsingApproach1(new[] {3, 8, 10, 4, 1, 7}); //20
        }

        private static int FindUsingApproach1(int[] money)
        {
            var dp = new int[money.Length];
            dp[0] = money[0];
            dp[1] = money[1];

            for (int i = 2; i < dp.Length; i++)
            {
                /*
                 * at i,
                 * there are two ways:
                 * Consider that ith position home
                 *      money at i + dp[i-2]    because i-1 has to be avoided to rob
                 * Not consider that ith position home
                 *      dp[i-1]                 as we are not robbing at i, we can take value calculated at i-1
                 *
                 * Out of these two values, we can take that max and consider for ith position
                 */
                dp[i] = Math.Max(dp[i - 1], money[i] + dp[i - 2]);
            }

            return dp[money.Length - 1];
        }


    }
}
