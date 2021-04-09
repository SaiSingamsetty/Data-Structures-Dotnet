using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DataStructureSpecific.DynamicProgramming
{
    //https://www.geeksforgeeks.org/count-ways-reach-nth-stair/
    public static class StairwayToHeaven
    {
        public static void Execute()
        {
            var res4 = FindUsingBottomUp(5); //8
            var res5 = FindUsingBottomUpWithFaultyStair(5, 3); //2
        }

        //TE: O(N), SE: O(N)
        private static int FindUsingBottomUp(int n)
        {
            var memory = new int[n + 1];
            memory[0] = 1; // the only way to do this to do nothing
            memory[1] = 1; // 1 step

            for (var i = 2; i <= n; i++)
            {
                /* Either we can take one step or two steps
                 * If we are calculating for 6, to reach 6,
                 * there are two ways : either 2 steps from 4
                 * or 1 step from 5. So calculating by taking
                 * data of last two possibilities.
                 */
                memory[i] = memory[i - 1] + memory[i - 2];
            }

            return memory[n];
        }

        //TE: O(N), SE: O(N)
        private static int FindUsingBottomUpWithFaultyStair(int n, int faultAt)
        {
            var memory = new int[n + 1];
            memory[0] = 1; // the only way to do this to do nothing
            memory[1] = 1; // 1 step

            for (var i = 2; i <= n; i++)
            {
                /* Either we can take one step or two steps
                 * If we are calculating for 6, to reach 6,
                 * there are two ways : either 2 steps from 4
                 * or 1 step from 5. So calculating by taking
                 * data of last two possibilities.
                 */
                if (i == faultAt)
                {
                    memory[i] = 0;
                }
                else
                {
                    memory[i] = memory[i - 1] + memory[i - 2];
                }
            }

            return memory[n];
        }

        //TE: O(N), SE: O(N)
        private static int FindUsingTopDown(int n)
        {
            var memory = new int[n + 1];

            var res = RecursiveForTopDown(n, memory);
            return res;
        }

        private static int RecursiveForTopDown(int n, int[] memory)
        {
            if (n == 0 || n == 1)
                return 1;

            if (n <= 0)
                return 0;

            if (memory[n] > 0)
                return memory[n];

            memory[n] = RecursiveForTopDown(n - 1, memory) + RecursiveForTopDown(n - 2, memory);
            return memory[n];
        }
    }
}
