using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekOne
{
    // Challenge 7: https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3353/
    // You are given coins of different denominations and a total amount of money.
    // Write a function to compute the number of combinations that make up that amount.
    // You may assume that you have infinite number of each kind of coin.
    // Input: amount = 5, coins = [1, 2, 5]
    // Output: 4
    // Explanation: there are four ways to make up the amount:
    // 5=5
    // 5=2+2+1
    // 5=2+1+1+1
    // 5=1+1+1+1+1

    public class CoinChange2
    {
        public static void Init()
        {
            var res1 = FindUsingApproach1(5, new int[] {1, 2, 5});
            var res2 = FindUsingApproach2(5, new int[] { 1, 2, 5 });
        }

        #region Approach 1: Dynamic Programming TC, SC: O(M * N); M - Amount, N - Coins length

        private static int FindUsingApproach1(int amount, int[] coins)
        {
            var dp = new int[coins.Length + 1, amount + 1]; 

            for (var i = 0; i <= coins.Length ; i++)
            {
                for (var j = 0; j <= amount ; j++)
                {
                    if (j == 0)
                        dp[i, j] = 1;
                    else if (i == 0)
                        dp[i, j] = 0;
                    else
                    {
                        dp[i, j] = dp[i - 1, j] + (j - coins[i - 1] < 0 ? 0 : dp[i, j - coins[i - 1]]);
                    }
                }
            }

            return dp[coins.Length, amount];
        }

        #endregion

        #region Approach 2: Dynamic Programming (Optimized Space Complexity for Approach 1); TC < O(M*N), SC: O(M) (M-Amount, N-coins length) 

        private static int FindUsingApproach2(int amount, int[] coins)
        {
            var dp = new int[amount + 1];
            dp[0] = 1;

            foreach (var eachCoin in coins)
            {
                for (var j = eachCoin; j <= amount; j++)
                {
                    dp[j] += dp[j - eachCoin];
                }
            }

            return dp[amount];
        }

        #endregion

    }
}
