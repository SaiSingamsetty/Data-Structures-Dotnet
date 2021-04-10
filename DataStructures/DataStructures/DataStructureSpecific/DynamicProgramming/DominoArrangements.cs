using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    public static class DominoArrangements
    {
        public static void Execute()
        {
            var res1 = Find(5); //8
        }

        private static int Find(int n)
        {
            var ways = new int[n + 1];
            ways[0] = 1; // base case
            ways[1] = 1; // base case

            for (var i = 2; i <= n; i++)
            {
                /*
                 * observe all cases for ways(5)
                 * two patterns
                 * A:
                 * last col with Vertical domino
                 * B:
                 * last col with two Horizontal dominos
                 */
                ways[i] = ways[i - 1] + ways[i - 2];
            }

            return ways[n];
        }
    }
}
