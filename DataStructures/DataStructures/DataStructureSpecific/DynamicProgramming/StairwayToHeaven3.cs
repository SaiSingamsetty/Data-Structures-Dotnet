using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    public static class StairwayToHeaven3
    {
        public static void Execute()
        {
            var res1 = Find(new int[] {2, 1, 3, 1, 2}, 5);
        }

        private static int Find(int[] fee, int steps)
        {
            var minFee = new int[fee.Length + 1];
            minFee[0] = 0; //base case
            minFee[1] = fee[0];
            minFee[2] = Math.Min(minFee[1] + fee[1], minFee[0] + fee[0]);

            for (int i = 3; i <= fee.Length ; i++)
            {
                minFee[i] = Math.Min(minFee[i - 1] + fee[i - 1],
                    Math.Min(minFee[i - 2] + fee[i - 2], minFee[i - 3] + fee[i - 3]));
            }

            return minFee[steps];
        }

        /*
         LEET CODE 746
         * You are given an integer array cost where cost[i] is the cost of ith step on a staircase.
         * Once you pay the cost, you can either climb one or two steps.
           You can either start from the step with index 0, or the step with index 1.
           Return the minimum cost to reach the top of the floor.
         *
         * {
                var minFee = new int[fee.Length + 1];
                minFee[0] = 0; //base case
                minFee[1] = 0;
            
                for (int i = 2; i <= fee.Length ; i++)
                {
                    minFee[i] = Math.Min(minFee[i - 1] + fee[i - 1], minFee[i - 2] + fee[i - 2]);
                }

                return minFee[fee.Length];
            }
         */
    }
}
