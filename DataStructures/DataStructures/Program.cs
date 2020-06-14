using DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFive;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFour;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne;
using DataStructures.ProblemSolving.LeetCode.Problems;
using System;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekTwo;

namespace DataStructures
{
    public class Program
    {
        private static void Main()
        {
            /* Current Problem */
            

            /* To-Do's and Refactorings */
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