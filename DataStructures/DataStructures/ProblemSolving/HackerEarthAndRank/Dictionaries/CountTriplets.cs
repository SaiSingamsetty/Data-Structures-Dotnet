using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Dictionaries
{
    public static class CountTriplets
    {
        public static void Execute()
        {
            var res1 = Count(new List<long>() {1, 3, 9, 9, 27, 81}, 3);
        }

        private static long Count(List<long> arr, long r)
        {
            var counter = 0L;

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    for (int k = j + 1; k < arr.Count; k++)
                    {
                        var first = arr[k] / arr[j];
                        var second = arr[j] / arr[i];
                        if (Math.Abs(new[] {first, second, r}.Average() - r) == 0)
                        {
                            counter++;
                            break;
                        }
                    }
                }
            }

            return counter;
        }
    }
}
