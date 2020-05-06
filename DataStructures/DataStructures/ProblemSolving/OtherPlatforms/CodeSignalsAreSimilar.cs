using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.OtherPlatforms
{
    // Problem Statement:
    // Two arrays are called similar if one can be obtained from another by swapping at most one pair of elements in one of the arrays.
    //Example 
    // For A = [1, 2, 3] and B = [1, 2, 3], the output should be areSimilar(A, B) = true
    // The arrays are equal, no need to swap any elements.
    // For A = [1, 2, 3] and B = [2, 1, 3], the output should be areSimilar(A, B) = true.
    // We can obtain B from A by swapping 2 and 1 in B.
    // For A = [1, 2, 2] and B = [2, 1, 1], the output should be areSimilar(A, B) = false.
    // Any swap of any two elements either in A or in B won't make A and B equal.

    public class CodeSignalsAreSimilar
    {
        public static void Init()
        {
            var a = new[] { 1, 2, 3, 4, 5 };
            var b = new[] { 1, 2, 5, 4, 3 };

            Console.WriteLine(Check(a, b));
        }

        private static bool Check(int[] a, int[] b)
        {
            var errorList = new List<int>();
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    errorList.Add(i);
            }

            if (errorList.Count == 0)
                return true;
            if (errorList.Count != 2)
                return false;

            var index1 = errorList[0];
            var index2 = errorList[1];

            if (a[index1] == b[index2] && a[index2] == b[index1])
                return true;
            return false;
        }
    }
}
