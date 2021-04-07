using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    public static class OnTheWayHome
    {
        public static void Execute()
        {
            var res1 = Find1(4, 4);
        }

        private static int Find1(int m, int n)
        {
            var memory = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                memory[i, 0] = 1;
            }

            for (int i = 0; i < m; i++)
            {
                memory[0, i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    memory[i, j] = memory[i, j - 1] + memory[i - 1, j];
                }
            }

            return memory[m - 1, n - 1];
        }

        private static int Find2(int m, int n)
        {
            var memory = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                memory[i,n - 1] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                memory[m - 1, i] = 1;
            }

            for (var i = m - 2; i >= 0; i--)
            {
                for (var j = n - 2; j >= 0; j--)
                {
                    memory[i, j] = memory[i, j + 1] + memory[i + 1, j];
                }
            }

            return memory[0,0];
        }
    }
}
