using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May2
{
    //https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/
    //REFACTOR

    public class KidsAndCandies
    {
        public static void Init()
        {
            var res = Check(new int[] { 12, 1, 12 }, 10);
        }

        private static IList<bool> Check(int[] candies, int extraCandies)
        {
            var maxCandies = candies.Max();
            var list = new List<bool>();

            foreach (var eachChild in candies)
            {
                list.Add(eachChild + extraCandies >= maxCandies);
            }

            return list;
        }
    }
}
