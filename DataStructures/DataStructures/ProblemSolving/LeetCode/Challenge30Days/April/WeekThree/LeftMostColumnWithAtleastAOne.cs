using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekThree
{
    // Challenge 21: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/530/week-3/3306/
    // Interactive Problem
    // A binary matrix means that all elements are 0 or 1. For each individual row of the matrix, this row is sorted in non-decreasing order.
    // Given a row-sorted binary matrix binaryMatrix, return leftmost column index(0-indexed) with at least a 1 in it. If such index doesn't exist, return -1.
    // You can't access the Binary Matrix directly.  You may only access the matrix using a BinaryMatrix interface:
    // BinaryMatrix.get(x, y) returns the element of the matrix at index (x, y) (0-indexed).
    // BinaryMatrix.dimensions() returns a list of 2 elements [n, m], which means the matrix is n * m.
    // Submissions making more than 1000 calls to BinaryMatrix.get will be judged Wrong Answer.  Also, any solutions that attempt to circumvent the judge will result in disqualification.
    // For custom testing purposes you're given the binary matrix mat as input in the following four examples. You will not have access the binary matrix directly.


    public class BinaryMatrix
    {
        public int Get(int x, int y)
        {
            return 1;
        }

        public IList<int> Dimensions()
        {
            return new List<int>() {3, 4};
        }
    }

    public class LeftMostColumnWithAtleastAOne
    {
        public static void Init()
        {
            var bn = new BinaryMatrix();
            Console.WriteLine(GetLeftMostColumnIndex(bn));
        }

        #region Approach 1: Ladder Approach O(Rows + Cols) in worst case

        //Ref https://www.youtube.com/watch?v=K2E5fMMAf5U&t=495s

        private static int GetLeftMostColumnIndex(BinaryMatrix binaryMatrix)
        {
            var dimensions = binaryMatrix.Dimensions();
            var rows = dimensions[0];
            var cols = dimensions[1];

            var x = rows - 1;
            var y = cols - 1;
            var result = -1;

            while (x >= 0 && y >= 0)
            {
                if (binaryMatrix.Get(x, y) == 1)
                {
                    result = y;
                    y--;
                }
                else
                {
                    x--;
                }
            }

            return result + 1;
        }

        #endregion
    }
}