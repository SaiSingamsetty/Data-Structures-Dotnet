using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    //LEETCODE: https://leetcode.com/problems/single-number-iii/
    //Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice.
    //Find the two elements that appear only once.
    //Input:  [1,2,1,3,2,5]
    //Output: [3,5]
    public class SingleNumber3
    {
        public static void Init()
        {
            var inputArray = new int[] {1, 2, 1, 3, 2, 5};
            var response = FindSingleNumbersUsingDictionary(inputArray);
            Console.WriteLine(string.Join(',', response));
        }

        private static int[] FindSingleNumbersUsingXor(int[] nums)
        {
            // find a position which is set in the first unique number but not the other one

            // Xor all the numbers. the resulting number will be Xor of num1(unique) and num2(unique)
            var xorOfUniqueNums = nums.Aggregate((x, y) => x ^ y);

            //Find Set Bit
            //AND Between xorResult and (2's Complement of xorResult)
            var setBit = xorOfUniqueNums & ((~ xorOfUniqueNums) + 1);

            // Create two groups of original number sequence.
            //First in which the mast bit is set and second where it is not set
            var numbersWithSetBit = nums.Where(x => (x & setBit) == 0);
            var numbersWithBitNotSet = nums.Where(x => (x & setBit) != 0);

            var uniqueNum1 = numbersWithSetBit.Aggregate((x, y) => x ^ y);
            var uniqueNum2 = numbersWithBitNotSet.Aggregate((x, y) => x ^ y);
            return new int[] {uniqueNum1, uniqueNum2};
        }

        private static int[] FindSingleNumbersInAnArrayUsingSorting(int[] nums)
        {
            Array.Sort(nums);
            var outputList = new List<int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (i + 1 < nums.Length && nums[i] == nums[i + 1])
                {
                    i++;
                    continue;
                }

                outputList.Add(nums[i]);
            }

            return outputList.ToArray();
        }

        private static int[] FindSingleNumbersUsingXorMasks(int[] nums)
        {
            // find a position which is set in the first unique number but not the other one
            // Xor all the numbers. the resulting number will be Xor of num1(unique) and num2(unique)
            var xorOfUniqueNums = nums.Aggregate((x, y) => x ^ y);

            // Create a mask of up to 32 bits i.e 1<<0, 1<<1, 1<<2, ... 1<<31
            var masks = Enumerable.Repeat(1, 31)
                .Zip(Enumerable.Range(0, 32), (first, second) => first << second);

            // Find a position for which the masks and xor of masks is non zero
            var validMask = masks.First(x => (x & xorOfUniqueNums) != 0);

            // Create two groups of original number sequence.
            //First in which the mast bit is set and second where it is not set
            var numbersWithSetBit = nums.Where(x => (x & validMask) == 0);
            var numbersWithBitNotSet = nums.Where(x => (x & validMask) != 0);

            var uniqueNum1 = numbersWithSetBit.Aggregate((x, y) => x ^ y);
            var uniqueNum2 = numbersWithBitNotSet.Aggregate((x, y) => x ^ y);
            return new int[] {uniqueNum1, uniqueNum2};
        }

        private static int[] FindSingleNumbersUsingDictionary(int[] nums)
        {
            var hashSet = new HashSet<int>();

            foreach (var num in nums)
            {
                if (!hashSet.Contains(num))
                {
                    hashSet.Add(num);
                }
                else
                {
                    hashSet.Remove(num);
                }
            }

            return hashSet.ToArray();
        }
    }
}