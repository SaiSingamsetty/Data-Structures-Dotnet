using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.DynPro
{
    public static class Candies
    {
        public static void Execute()
        {
            var res1 = Find(10, new[] {2, 4, 2, 6, 1, 7, 8, 9, 2, 1});

            var list = new List<int>();
            for (int i = 100000; i >= 1; i--)
            {
                list.Add(i);
            }

            var res2 = Find(100000, list.ToArray());
        }

        private static long Find(int n, int[] arr)
        {
            var leftToRight = new long[arr.Length];

            for (long i = 0; i < arr.Length; i++)
            {
                leftToRight[i] = 1;
            }

            for (long i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    leftToRight[i] = leftToRight[i - 1] + 1;
                }
            }


            var rightToLeft = new long[arr.Length];

            for (long i = 0; i < arr.Length; i++)
            {
                rightToLeft[i] = 1;
            }

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] > arr[i + 1])
                {
                    rightToLeft[i] = rightToLeft[i + 1] + 1;
                }
            }

            long sum = 0;
            for (long i = 0; i < arr.Length; i++)
            {
                sum += Math.Max(leftToRight[i], rightToLeft[i]);
            }
            
            return sum;
        }
    }
}
