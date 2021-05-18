using DataStructures.DataStructureSpecific.DynamicProgramming;
using DataStructures.ProblemSolving.HackerEarthAndRank.Dictionaries;
using DataStructures.ProblemSolving.HackerEarthAndRank.DynPro;
using DataStructures.ProblemSolving.HackerEarthAndRank.LinkedLists;
using DataStructures.ProblemSolving.HackerEarthAndRank.Strings;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFive;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFour;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne;
using DataStructures.ProblemSolving.LeetCode.Problems;
using System;
using DataStructures.DataStructureSpecific;
using DataStructures.ProblemSolving.HackerEarthAndRank;
using DataStructures.ProblemSolving.HackerEarthAndRank.Trees;
using DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.LinkedLists;
using DataStructures.ProblemSolving.OtherPlatforms;

namespace DataStructures
{
    public static class Program
    {  
        private static void Main()
        {
            /* Current Problem */
            LowestCommonAncestor.Execute();

            var obj = new LruCacheTest();
            obj.TestCache();

            CountTriplets.Execute();
            StairwayToHeaven2.Execute();
            Abbreviation.Execute();
            CommonChild.Execute();
            SpecialStringAgain.Execute();
            
            /* To-Do and Refactorings */
            Todo();
            Refactor();
            Console.ReadKey();
        }

        private static void Refactor()
        {
            MinEditDistance.Init(); // Not Solved
            CourseSchedule.Init(); // Not solved - GRAPHS
            PossibleBiPartition.Init(); // Not solved - GRAPHS
            ImplementStrStrLc28.Init(); // KMP Algo for ImplementStrStrLc28
            NumberComplement.Init(); // Refactor existing implementation
        }

        private static void Todo()
        {
            //TODO: Lending Cart Problems in Whats-app group
            //TODO: https://leetcode.com/problems/cells-with-odd-values-in-a-matrix/
            //TODO: https://leetcode.com/problems/daily-temperatures/
        }
    }
}