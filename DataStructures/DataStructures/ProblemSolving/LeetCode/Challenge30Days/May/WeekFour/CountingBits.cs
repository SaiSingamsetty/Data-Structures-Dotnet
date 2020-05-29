using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFour
{
    // Challenge 28: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3343/

    // Given a non negative integer number num. For every numbers i in the range 0 ≤ i ≤ num calculate the number of 1's in their binary representation and return them as an array.
    // Example 1:
    // Input: 2
    // Output: [0,1,1]
    // Example 2:
    // Input: 5
    // Output: [0,1,1,2,1,2]

    //Follow up:
    // 
    // It is very easy to come up with a solution with run time O(n*sizeof(integer)). But can you do it in linear time O(n) /possibly in a single pass?
    // Space complexity should be O(n).
    // Can you do it like a boss? Do it without using any builtin function like __builtin_popcount in c++ or in any other language.

    public class CountingBits
    {
        public static void Init()
        {
            var res1 = CountUsingApproach1(5);
        }

        #region Approach 1: Brute Force - O(N * size of N)

        private static int[] CountUsingApproach1(int num)
        {
            var arr = new int[num + 1];

            for (var i = 0; i <= num; i++)
            {
                var tempBinaryFormat = (Convert.ToString(i, 2));
                arr[i] = tempBinaryFormat.Count(y => y == '1');
            }

            return arr;
        }

        #endregion


        #region Approach 2: Using bit shift logic : O(N)

        // Ref: https://www.youtube.com/watch?v=awxaRgUB4Kw

        private static int[] CountUsingApproach2(int num)
        {
            var arr = new int[num + 1];

            for (var i = 1; i <= num; i++)
            {
                arr[i] = arr[i / 2] + i % 2;
            }

            return arr;
        }

        #endregion


    }
}
