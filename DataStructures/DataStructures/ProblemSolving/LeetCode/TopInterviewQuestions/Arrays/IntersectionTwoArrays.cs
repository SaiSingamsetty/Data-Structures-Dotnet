using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Arrays
{
    //LEETCODE:https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/674/
    //Given two arrays, write a function to compute their intersection.

    public class IntersectionTwoArrays
    {
        public static void Init()
        {
            var inputArray1 = new int[] {1, 2, 2, 1};
            var inputArray2 = new int[] {2, 2};
            var response = Intersect(inputArray1, inputArray2);
            Console.WriteLine(string.Join(',', response));

        }

        private static int[] Intersect(int[] nums1, int[] nums2)
        {
            var dict = new Dictionary<int, int>();
            var outputList = new List<int>();

            foreach (var num1 in nums1)
            {
                if (dict.ContainsKey(num1))
                {
                    dict[num1] += 1;
                }
                else
                {
                    dict.Add(num1, 1);
                }
            }

            foreach (var num2 in nums2)
            {
                if (dict.ContainsKey(num2) && dict[num2] > 0)
                {
                    outputList.Add(num2);
                    dict[num2] -= 1;
                }
            }

            return outputList.ToArray();

        }
    }
}
