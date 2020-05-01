using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekOne
{
    //Challenge4
    //Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
    /*
       Input: [0,1,0,3,12]
       Output: [1,3,12,0,0]
     */

    public class MoveZeroes
    {
        public static void Init()
        {
            var inputArray = new[] {1, 0, 0, 3, 0, 5, 0, 0, 6};
            var response = MoveZeroesInArray(inputArray);
            Console.WriteLine(string.Join(',', response));
        }

        private static int[] MoveZeroesInArray(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                var nextNonZeroValPos = i;
                if (nums[i] != 0)
                    continue;

                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == 0)
                        continue;

                    nextNonZeroValPos = j;
                    break;
                }

                nums[i] = nums[nextNonZeroValPos];
                nums[nextNonZeroValPos] = 0;
            }

            return nums;
        }
    }
}