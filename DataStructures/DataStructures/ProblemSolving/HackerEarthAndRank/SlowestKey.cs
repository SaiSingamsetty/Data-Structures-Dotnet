using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank
{
    //ZestMoney Coding Que 1

    public static class SlowestKey
    {
        public static void Execute()
        {
            var key = FindSlowest(new[] {new[] {0, 2}, new[] {1, 3}, new[] {0, 7}});
            //key should be 'a'
        }

        private static char FindSlowest(int[][] keyTimes)
        {
            var maxDiff = keyTimes[0][1];
            var keyPressed = (char) (keyTimes[0][0] + 'a');
            var prevKeyTime = keyTimes[0][1];

            for (int i = 1; i < keyTimes.Length; i++)
            {
                int diffWithPrev = keyTimes[i][1] - prevKeyTime;
                if (diffWithPrev > maxDiff)
                {
                    maxDiff = diffWithPrev;
                    keyPressed = (char)(keyTimes[i][0] + 'a');
                }

                prevKeyTime = keyTimes[i][1];
            }

            return keyPressed;
        }

    }
}
