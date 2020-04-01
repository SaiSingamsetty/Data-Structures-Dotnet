using System;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Arrays
{
    // LEETCODE https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/727/
    /*
     * Given nums = [1,1,2]       
       Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.
     */
    public static class RemDupsFromSortedArr
    {
        public static void Init()
        {
            var intArray = new[] {1, 1, 2};
            var result = RemoveDuplicatesFromSortedArray(intArray);
            Console.WriteLine("Result: " + result);
        }

        private static int RemoveDuplicatesFromSortedArray(int[] nums)
        {
            int? prevValue = null;
            var counter = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                var currentValue = nums[i];
                if (currentValue == prevValue)
                    continue;

                prevValue = currentValue;
                nums[counter] = nums[i];
                counter++;
            }

            //Verifying contents of array through pass by reference
            nums = nums.Take(counter).ToArray();

            return counter;
        }
    }
}