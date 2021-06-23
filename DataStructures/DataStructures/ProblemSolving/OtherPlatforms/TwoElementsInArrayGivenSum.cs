using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.OtherPlatforms
{
    public static class TwoElementsInArrayGivenSum
    {
        public static void Execute()
        {
            var r1 = DoesExists(new[] {2, 5, 1, 6, 7}, 22);
        }

        private static bool DoesExists(int[] arr, int sum)
        {
            var s = new HashSet<int>();
            foreach (var eachElement in arr)
            {
                var temp = sum - eachElement;

                if (s.Contains(temp)) return true;
                s.Add(eachElement);
            }

            return false;
        }
    }
}