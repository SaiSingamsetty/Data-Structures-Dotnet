using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    public static class Stock
    {
        public static void Execute()
        {
            var res1 = FindMaxProfitUsingApproach2(new int[] {8, 1, 2, 4, 6, 3});
        }

        private static int FindMaxProfitUsingApproach1(int[] price)
        {
            var minimumTillDay = new int[price.Length];
            var profitTillDay = new int[price.Length];
            var highestProfit = int.MinValue;

            minimumTillDay[0] = price[0];
            for (int i = 1; i < price.Length; i++)
            {
                minimumTillDay[i] = Math.Min(price[i], minimumTillDay[i - 1]);
            }

            for (int i = 0; i < price.Length; i++)
            {
                profitTillDay[i] = price[i] - minimumTillDay[i];
                if (profitTillDay[i] > highestProfit)
                    highestProfit = profitTillDay[i];
            }

            return highestProfit;
        }

        private static int FindMaxProfitUsingApproach2(int[] price)
        {
            var minimumTillDay = int.MaxValue;
            var profitTillDay = new int[price.Length];
            var highestProfit = int.MinValue;
            
            for (int i = 0; i < price.Length; i++)
            {
                minimumTillDay = Math.Min(minimumTillDay, price[i]);
                profitTillDay[i] = price[i] - minimumTillDay;
                if (profitTillDay[i] > highestProfit)
                    highestProfit = profitTillDay[i];
            }

            return highestProfit;
        }
    }
}
