using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.DynPro
{
    // https://www.hackerrank.com/challenges/max-array-sum/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dynamic-programming
    public static class MaxArraySum
    {
        public static void Execute()
        {
            var res1 = Find(new[] { 2, 1, 5, 8 , 4 });
        }

        private static int Find(int[] arr)
        {
            var lookUp = new int[arr.Length];

            lookUp[0] = arr[0];
            lookUp[1] = Math.Max(arr[0], arr[1]);
            for (var i = 2; i < arr.Length; i++)
            {
                // Max till now = Max of (Number itself, number + max value from lookup excluding previous element, previous look up)
                lookUp[i] = Math.Max(arr[i], Math.Max(arr[i] + lookUp[i - 2], lookUp[i - 1]));
            }

            return lookUp[arr.Length - 1];
        }

        //Can avoid look up array and just maintain prevMaxValue lookUp[i - 1] and prevLastMaxValue lookUp[i - 2]
        private static int FindWithLessSpace(int[] arr)
        {
            var prevLastMax = arr[0];
            var prevMax = Math.Max(arr[0], arr[1]);
            for (var i = 2; i < arr.Length; i++)
            {
                // Max till now = Max of (Number itself, number + max value from lookup excluding previous element, previous look up)
                var max = Math.Max(arr[i], Math.Max(arr[i] + prevLastMax, prevMax));
                prevLastMax = prevMax;
                prevMax = max;
            }

            return prevMax;
        }
    }
}
