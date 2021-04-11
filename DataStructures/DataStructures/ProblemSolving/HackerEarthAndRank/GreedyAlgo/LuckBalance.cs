using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.GreedyAlgo
{
    public static class LuckBalance
    {
        public static void Execute()
        {
            var res1 = Find(3,
                new[] {new[] {5, 1}, new[] {2, 1}, new[] {1, 1}, new[] {8, 1}, new[] {10, 0}, new[] {5, 0}});
        }

        private static int Find(int k, int[][] contests)
        {
            var luckBal = 0;

            var impContArray = new int[contests.Length];
            var impPointer = 0;

            for (int i = 0; i < contests.Length; i++)
            {
                if (contests[i][1] == 0)
                    luckBal += contests[i][0];
                else
                {
                    impContArray[impPointer] = contests[i][0];
                    impPointer++;
                }
            }

            Array.Sort(impContArray);
            for (int i = contests.Length - 1; i >= 0 ; i--)
            {
                if(impContArray[i] <= 0)
                    break;

                if(i >= contests.Length - k)
                    luckBal += impContArray[i];
                else
                {
                    luckBal -= impContArray[i];
                }
            }

            return luckBal;
        }
    }
}
