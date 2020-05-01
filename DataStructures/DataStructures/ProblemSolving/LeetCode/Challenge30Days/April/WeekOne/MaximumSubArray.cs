using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekOne
{
    //Challenge3
    //Given an integer array nums, find the contiguous sub array (containing at least one number) which has the largest sum and return its sum.

    public class MaximumSubArray
    {
        public static void Init()
        {
            var inputArray = new[] {-2, -3, 4, -1, -2, 1, 5, -3};
            var result = FindMaxSubArraySumUsingKadanesAlgo(inputArray);
            Console.WriteLine(result);

            var dynProResponse = FindMaxSubArraySumUsingDynamicProgramming(inputArray);
            Console.WriteLine(dynProResponse);
        }

        //Kadanes Algo
        private static int FindMaxSubArraySumUsingKadanesAlgo(int[] nums)
        {
            var maxSoFar = int.MinValue;
            var maxEndingHere = 0;

            //For tracing location, these are needed
            var counter = 0;
            var start = 0;
            var end = 0;
            var temp = 0;

            foreach (var num in nums)
            {
                maxEndingHere += num;

                if (maxSoFar < maxEndingHere)
                {
                    maxSoFar = maxEndingHere;
                    // When it finds a value which is greater than 0, then it will not execute second if condition, it means 
                    // the next value might be the start of the max sub array
                    start = temp + 1;
                    end = counter;
                }

                if (maxEndingHere < 0)
                {
                    maxEndingHere = 0;
                    temp = counter; // Every time it refreshes, store the location in temp
                }

                counter++; // similar to i in for loop
            }

            Console.WriteLine("Start and End locations: " + start + ", " + end);
            return maxSoFar;
        }


        //Dynamic Programming #GeeksForGeeks
        private static int FindMaxSubArraySumUsingDynamicProgramming(int[] nums)
        {
            //INPUT: { -2, -3, 4, -1, -2, 1, 5, -3 }
            var maxSoFar = nums[0];
            var curMax = nums[0];
            var size = nums.Length;

            for (var i = 1; i < size; i++)
            {
                curMax = Math.Max(nums[i], curMax + nums[i]);
                maxSoFar = Math.Max(maxSoFar, curMax);
            }

            return maxSoFar;
        }
    }
}