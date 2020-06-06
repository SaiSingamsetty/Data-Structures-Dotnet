using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Arrays
{
    //LEETCODE:https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/546/
    //Given an array of integers, return indices of the two numbers such that they add up to a specific target. 
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /*
       Given nums = [2, 7, 11, 15], target = 9, 
       Because nums[0] + nums[1] = 2 + 7 = 9,
       return [0, 1].
     */


    public class TwoSum
    {
        public static void Init()
        {
            var inputArray = new[] {2, 7, 11, 15};
            var target = 9;

            var response = GetIndicesUsingDictionary(inputArray, target);
            Console.WriteLine(string.Join(',', response));
        }

        //This is called Brute Force, Time Complexity O(n2)
        private static int[] GetIndicesBruteForceApproach(int[] nums, int target)
        {
            //{ 2, 11, 7, 15 }

            for (var i = 0; i < nums.Length; i++)
            {
                var firstNum = nums[i];
                for (var j = i + 1; j < nums.Length; j++)
                {
                    var secondNum = nums[j];
                    if (firstNum + secondNum == target)
                        return new[] {i, j};
                }
            }

            return new int[] { };
        }

        private static int[] GetIndicesUsingDictionary(int[] nums, int target)
        {
            //{ 2, 7, 11, 15 }
            //Maintaining compliment values in dictionary or any other faster data structure will help
            var dict = new Dictionary<int, int>();
            var counter = 0;

            foreach (var num in nums)
            {
                var compliment = target - num;
                if (dict.ContainsKey(compliment))
                    return new[] {dict[compliment], counter};

                if (dict.ContainsKey(num))
                    dict[num] = counter;
                else
                    dict.Add(num, counter);


                counter++;
            }

            return new int[] { };
        }
    }
}