using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne
{
    // Challenge 2: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3317/
    // You're given strings J representing the types of stones that are jewels, and S representing the stones you have.
    // Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.
    // Input: J = "aA", S = "aAAbbbb"
    // Output: 3


    public class JewelsAndStones
    {
        public static void Init()
        {
            Console.WriteLine(FindNoJewels("aA", "aAAbbbbb"));
        }

        #region Approach 1: TC: Linear, SC: Constant

        private static int FindNoJewels(string J, string S)
        {
            var count = 0;
            foreach (var eachChar in S)
            {
                if (J.Contains(eachChar))
                {
                    count++;
                }
            }

            return count;
        }

        #endregion

        #region Approach 2: LINQ and Func Delegates (built in functions: optimized code)

        public int NumJewelsInStones(string J, string S)
        {
            return S.Count(c => J.Contains(c));
        }

        #endregion

        #region Approach 3: TC: O(m*n), SC: O(m) (J len -m, S len -n) Using Extra Space (Hashset)

        private static int FindNoOfJewelsUsingHashSet(string J, string S)
        {
            var hashSet = new HashSet<char>();
            var counter = 0;
            foreach (var eachChar in J)
            {
                hashSet.Add(eachChar);
            }

            foreach (var eachChar in S)
            {
                if (hashSet.Contains(eachChar))
                    counter++;
            }

            return counter;
        }

        #endregion
    }
}