using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    public static class NumberSplitting
    {
        public static void Execute()
        {
            var res1 = Find(5); //6
            var res2 = Find(6); //9
        }

        private static int Find(int n)
        {
            var maxProduct = new int[n + 1];
            maxProduct[1] = 0;
            maxProduct[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    maxProduct[i] = new[] {j * maxProduct[i - j], j * (i - j), maxProduct[i]}.Max();
                }
            }

            return maxProduct[n];
        }
    }
}
