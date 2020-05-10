using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne
{
    // Challenge 1: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3316/
    // Implement a function to find the first bad version. You should minimize the number of calls to the API.

    public class FirstBadVersion
    {
        public static void Init()
        {
            Console.WriteLine(FindFirstBadVersion(6));
        }

        #region Binary Search Approach (TC: O(log n), SC: O(1))

        private static int FindFirstBadVersion(int n)
        {
            var start = 1;
            var end = n;

            while (start < end)
            {
                var mid = start + (end - start) / 2; //Overflow handling

                if (IsBadVersion(mid))
                    end = mid; //If the mid one is bad, then first bad version will be definitely 'before' or 'equal' to mid
                else
                {
                    start = mid + 1; // If the mid one is good, then first bad version will be 'after' mid
                }
            }

            return start;
        }

        private static bool IsBadVersion(long version)
        {
            if (version == 3 || version == 5 || version == 6)
                return true;
            return false;
        }

        #endregion
    }
}