using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Arrays
{
    //https://www.hackerrank.com/challenges/new-year-chaos/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays

    public static class NewYearChaos
    {
        public static void Execute()
        {
            Find(new[] {2, 1, 5, 3, 4}); // 3
            Find(new[] {2, 5, 1, 3, 4}); // Too chaotic
        }

        private static void Find(int[] q)
        {
            var isChaotic = false;
            var bribes = 0;

            for (var i = 0; i < q.Length; i++)
            {
                var currentValue = q[i];
                var originalValue = i + 1;

                if (currentValue - originalValue > 2)
                {
                    isChaotic = true;
                    break;
                }

                for (var j = Math.Max(q[i] - 2, 0); j < i; j++)
                {
                    if (q[j] > q[i])
                        bribes++;
                }
            }
            if(!isChaotic)
                Console.WriteLine("Total bribes : " + bribes);
            else
            {
                Console.WriteLine("Too chaotic");
            }
        }
    }
}
