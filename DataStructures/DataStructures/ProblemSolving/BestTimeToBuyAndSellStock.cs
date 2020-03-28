using System.Collections.Generic;

namespace DataStructures.ProblemSolving
{
    //LEETCODE https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/564/

    using System;

    public static class BestTimeToBuyAndSellStock
    {
        public static void Init()
        {
            var inputArray = new[] { 1, 7, 2, 3, 6, 7, 6, 7 };
            var profitPeakValleyApproach = FindProfit_PeakValleyApproach(inputArray);
            Console.WriteLine("Profit through Peak Valley Approach: " + profitPeakValleyApproach);

            var profitSimpleOnePassApproach = FindProfit_SimpleOnePass(inputArray);
            Console.WriteLine("Profit through Simple One Pass Approach: " + profitSimpleOnePassApproach);
        }

        //Peak Valley Approach Time complexity : O(n) Single pass.
        private static int FindProfit_PeakValleyApproach(IReadOnlyList<int> prices)
        {
            var i = 0;
            var maxProfit = 0;

            while (i < prices.Count - 1)
            {
                //Find Valley
                while (i < prices.Count - 1 && prices[i] >= prices[i + 1])
                {
                    i++;
                }

                var valley = prices[i];

                //Find Peak
                while (i < prices.Count - 1 && prices[i] <= prices[i + 1])
                {
                    i++;
                }

                var peak = prices[i];
                maxProfit += peak - valley;

            }

            return maxProfit;
        }

        //Simple One Pass Approach Time complexity : O(n) Single pass.
        private static int FindProfit_SimpleOnePass(IReadOnlyList<int> prices)
        {
            var maxProfit = 0;

            for (var i = 1; i < prices.Count; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxProfit += prices[i] - prices[i - 1];
            }

            return maxProfit;
        }




    }
}
