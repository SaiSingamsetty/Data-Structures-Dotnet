using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekOne
{
    //LEETCODE: Challenge7 https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/528/week-1/3289/
    //Given an integer array arr, count element x such that x + 1 is also in arr. 
    //If there are duplicates in arr, count them separately.
    //Input: arr = [1,2,3]
    // Output: 2
    // Explanation: 1 and 2 are counted cause 2 and 3 are in arr.
    // for [1, 1, 2] Output is 1


    public class CountingElements
    {
        public static void Init()
        {
            var arr = new[] {1, 1, 2};
            var response = CountElements(arr);
            Console.WriteLine(response);
        }

        private static int CountElements(int[] arr)
        {
            var hashSet = new HashSet<int>();
            var counter = 0;

            foreach (var i in arr) hashSet.Add(i);

            foreach (var i in arr)
                if (hashSet.Contains(i + 1))
                    counter++;

            return counter;
        }
    }
}