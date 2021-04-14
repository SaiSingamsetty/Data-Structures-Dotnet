using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.OtherPlatforms
{
    public static class ThiefAndCoins
    {
        public static void Execute()
        {
            var tc1 = new int[3][];
            tc1[0] = new[] {1, 3, 3};
            tc1[1] = new[] {2, 1, 4};
            tc1[2] = new[] {0, 6, 4};

            var res1 = FindMaxDist(tc1);
        }

        private static int FindMaxDist(int[][] arr)
        {
            var rows = arr.Length;
            var cols = arr[0].Length;
            var maxSoFar = int.MinValue;

            var temp = new int[rows, cols];

            for (var i = 0; i < cols; i++)
            {

                for (var j = 0; j < rows; j++)
                {

                    if (i == 0)
                    {
                        temp[j, i] = arr[j][i];
                        continue;
                    }

                    if (j == 0)
                    {
                        temp[j, i] = arr[j][i] + Math.Max(temp[j, i - 1], temp[j + 1, i - 1]);
                    }
                    else if (j == rows - 1)
                    {
                        temp[j, i] = arr[j][i] + Math.Max(temp[j - 1, i - 1], temp[j, i - 1]);
                    }
                    else
                    {
                        temp[j, i] = arr[j][i] + Math.Max(temp[j - 1, i - 1], Math.Max(temp[j, i - 1], temp[j + 1, i - 1]));
                    }

                    if (temp[j, i] > maxSoFar)
                        maxSoFar = temp[j, i];
                }

            }

            return maxSoFar;
        }
    }


}
