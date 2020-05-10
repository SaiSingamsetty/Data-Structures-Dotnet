using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May10
{
    public class BuildArrayWithStackOperations
    {
        // LC 1441
        // https://leetcode.com/problems/build-an-array-with-stack-operations/
        // Given an array target and an integer n. In each iteration, you will read a number from  list = {1,2,3..., n}.
        // Build the target array using the following operations:
        // Push: Read a new element from the beginning list, and push it in the array.
        // Pop: delete the last element of the array.
        // If the target array is already built, stop reading more elements.
        // You are guaranteed that the target array is strictly increasing, only containing numbers between 1 to n inclusive.
        // Return the operations to build the target array.
        // You are guaranteed that the answer is unique.

        public static void Init()
        {
            var res1 = BuildArray(new[] {2, 3, 4}, 4);
            var res2 = BuildArray(new[] {1, 2, 3}, 3);
            var res3 = BuildArray(new[] {1, 2}, 4);
            var res4 = BuildArray(new[] {1, 3}, 3);
        }


        /*
         * List: 1,2,3,4
         * target -> 2,3,4
         */
        private static IList<string> BuildArray(int[] target, int n)
        {
            var loop = 1;
            var operations = new List<string>();
            var targetPointer = 0;
            while (loop <= n && targetPointer < target.Length)
            {
                if (target[targetPointer] != loop)
                {
                    operations.Add("Push");
                    operations.Add("Pop");
                }
                else
                {
                    operations.Add("Push");
                    targetPointer++;
                }

                loop++;
            }

            return operations;
        }
    }
}