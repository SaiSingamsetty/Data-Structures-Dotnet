using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.DynamicProgramming
{
    // BestTimeToBuyAndSellStock I 
    // Leetcode : https://leetcode.com/explore/featured/card/top-interview-questions-easy/97/dynamic-programming/572/
    // Say you have an array for which the ith element is the price of a given stock on day i. 
    // If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit. 
    // Note that you cannot sell a stock before you buy one.

    public class BestTimeToBuyAndSellStock
    {
        public static void Init()
        {
            var res1 = FindUsingApproach1(new[] { 7, 1, 5, 3, 6, 4 });
            var res2 = FindUsingApproach2(new[] { 7, 1, 5, 3, 6, 4 });
        }

        #region Approach 1: Brute Force, TC: O(N2); SC: O(1)

        private static int FindUsingApproach1(int[] prices)
        {
            var maxProfit = 0;
            for (var i = 0; i < prices.Length - 1; i++)
            {
                for (var j = i + 1; j < prices.Length; j++)
                {
                    var profit = prices[j] - prices[i];
                    if (profit > maxProfit)
                        maxProfit = profit;
                }
            }
            return maxProfit;

        }

        #endregion

        #region Approach 2: One Pass, TC: O(N), SC: O(1)

        private static int FindUsingApproach2(int[] prices)
        {
            var minPrice = int.MaxValue;
            var maxProfit = 0;
            foreach (var eachPrice in prices)
            {
                if (eachPrice < minPrice)
                    minPrice = eachPrice;
                else if (eachPrice - minPrice > maxProfit)
                    maxProfit = eachPrice - minPrice;
            }

            return maxProfit;
        }

        #endregion

    }
}
