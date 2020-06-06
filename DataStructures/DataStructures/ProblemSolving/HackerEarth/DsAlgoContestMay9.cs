using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.HackerEarth
{
    // Hacker Earth
    // https://www.hackerearth.com/challenges/competitive/data-structures-and-algorithms-coding-contest-may-2020/problems/
    public class DsAlgoContestMay9
    {
        //Incomplete

        public static void Init()
        {
            //3
            RosesInShop();

            //1
            Construct();
        }

        private static void Construct()
        {
            var cases = Convert.ToInt32(Console.ReadLine());
            var list = new List<int[]>();

            while (cases > 0)
            {
                var temp = Console.ReadLine();
                list.Add(temp.Split(' ').Select(int.Parse).ToArray());

                cases--;
            }

            foreach (var eachInput in list)
            {
                var zeroCount = eachInput[0];
                var oneCount = eachInput[1];
            }
        }

        private static List<string> GenerateBinaryStrings(int zeroCount, int oneCount)
        {
            var list = new List<string>();
            while (zeroCount > 0 || oneCount > 0)
            {
            }

            return list;
        }


        private static void RosesInShop()
        {
            var count = Convert.ToInt32(Console.ReadLine());
            var temp = Console.ReadLine();
            if (string.IsNullOrEmpty(temp))
                return;

            var smells = temp.Split(' ').Select(int.Parse).ToList();

            var max = 1;
            var valley = 0;

            var prev = smells[0];
            var beforePrev = smells[0];
            for (var i = 1; i < count; i++)
                if (smells[i] > prev)
                {
                    max++;
                    prev = smells[i];
                    beforePrev = i >= 1 ? smells[i - 1] : smells[0];
                }
                else
                {
                    valley++;
                    if (smells[i] < beforePrev || valley > 2)
                        Console.WriteLine(max);
                    if (smells[i] > beforePrev)
                    {
                        max++;
                        prev = smells[i];
                        beforePrev = i >= 1 ? smells[i - 1] : smells[0];
                    }
                }

            Console.WriteLine(max);
        }
    }
}