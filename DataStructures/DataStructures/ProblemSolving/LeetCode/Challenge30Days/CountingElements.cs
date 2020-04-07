using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days
{
    public class CountingElements
    {
        public static void Init()
        {
            var arr = new[] { 1, 1, 2 };
            var response = CountElements(arr);
            Console.WriteLine(response);
        }

        private static int CountElements(int[] arr)
        {
            var hashSet = new HashSet<int>();
            var counter = 0;

            foreach (var i in arr)
            {
                hashSet.Add(i);
            }

            foreach (var i in arr)
            {
                if (hashSet.Contains(i+1))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
