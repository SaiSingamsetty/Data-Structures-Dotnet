using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Arrays
{
    //https://www.hackerrank.com/challenges/minimum-swaps-2/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays

    public static class MinimumSwaps
    {
        public static void Execute()
        {
            var res1 = Find(new[] {2, 3, 4, 1, 5}); // 3
        }

        private static int Find(int[] arr)
        {
            var swaps = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == i + 1) continue;

                var temp = arr[i];
                arr[i] = arr[temp - 1];
                arr[temp - 1] = temp;
                swaps++;
                i--;
            }
            
            return swaps;
        }
    }
}
