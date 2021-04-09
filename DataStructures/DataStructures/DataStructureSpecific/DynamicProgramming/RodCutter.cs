using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    public static class RodCutter
    {
        public static void Execute()
        {
            var res1 = FindUsingApproach1(new int[] {2, 4, 5, 7}, 5);
        }

        //bottom up
        private static int FindUsingApproach1(int[] price, int rodLength)
        {
            var rodCuts = new int[rodLength];
            rodCuts[0] = 0;

            for (int i = 1; i < rodLength; i++)
            {
                var maxValue = int.MinValue;

                for (int j = 1; j <= i; j++)
                {
                    //j-1 here for price array starts from cuts 1 to n-1
                    maxValue = Math.Max(maxValue, price[j - 1] + rodCuts[i - j]);
                }

                rodCuts[i] = maxValue;
            }

            return rodCuts[rodLength - 1];
        }
        
    }
}
