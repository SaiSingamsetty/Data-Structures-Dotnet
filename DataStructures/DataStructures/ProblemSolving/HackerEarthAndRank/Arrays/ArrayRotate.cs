using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Arrays
{
    //https://www.hackerrank.com/challenges/ctci-array-left-rotation/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays

    public class ArrayRotate
    {
        public static void Execute()
        {
            var res1 = RotateLeftFaster(new[] {1, 2, 3, 4, 5}, 6);
        }

        private static int[] RotateLeft(int[] a, int d)
        {
            d = d % a.Length;
            while (d > 0)
            {
                var temp = a[0];

                for (int i = 0, j = 1; j < a.Length; i++, j++)
                {
                    a[i] = a[j];
                }

                a[^1] = temp;

                d--;
            }

            return a;
        }

        private static int[] RotateLeftFaster(int[] a, int d)
        {
            var n = a.Length;
            d = d % n;
            var rotated = new int[n];

            Array.Copy(a, d, rotated, 0, n - d);
            Array.Copy(a, 0, rotated, n - d, d);

            return rotated;
        }
    }
}
