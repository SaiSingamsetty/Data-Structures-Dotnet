using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Sorting
{
    public static class BubbleSort
    {
        public static void Execute()
        {
            var res1 = SortByBubbleSort(new int[] {3, 1, 5, 2, 4});
        }

        private static int[] SortByBubbleSort(int[] a)
        {
            var swaps = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        var temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        swaps++;
                    }
                }
            }

            Console.WriteLine($"Array is sorted in {swaps} swaps.");
            Console.WriteLine($"First element: {a[0]}");
            Console.WriteLine($"Last element: {a[a.Length - 1]}");

            return a;
        }
    }
}
