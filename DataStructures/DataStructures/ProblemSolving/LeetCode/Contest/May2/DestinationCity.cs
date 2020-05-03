using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May2
{
    //https://leetcode.com/problems/destination-city/
    //Refactor

    public class DestinationCity
    {
        public static void Init()
        {
            var path1 = new List<string>()
            {
                "B",
                "C"
            };
            var path2 = new List<string>()
            {
                "D",
                "B"
            };
            var path3 = new List<string>()
            {
                "C",
                "A"
            };
            var res = FindDestCity(new List<IList<string>> { path1, path2, path3 });
        }

        private static string FindDestCity(IList<IList<string>> paths)
        {
            var startCities = new List<string>();
            var destCities = new List<string>();

            foreach(var eachPath in paths)
            {
                startCities.Add(eachPath[0]);
                destCities.Add(eachPath[1]);
            }

            var res = destCities.Where(destCity => !startCities.Contains(destCity)).First();
            return res;
        }
    }
}
