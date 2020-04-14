using System;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekTwo
{
    // Challenge14: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/529/week-2/3299/
    // You are given a string s containing lowercase English letters, and a matrix shift, where shift[i] = [direction, amount]:
    // 
    // direction can be 0 (for left shift) or 1 (for right shift). 
    // amount is the amount by which string s is to be shifted.
    // A left shift by 1 means remove the first character of s and append it to the end.
    // Similarly, a right shift by 1 means remove the last character of s and add it to the beginning.
    // Return the final string after all operations.

    // Input: s = "abcdefg", shift = [[1,1],[1,1],[0,2],[1,3]]
    // Output: "efgabcd"
    // Explanation:  
    // [1,1] means shift to right by 1. "abcdefg" -> "gabcdef"
    // [1,1] means shift to right by 1. "gabcdef" -> "fgabcde"
    // [0,2] means shift to left by 2. "fgabcde" -> "abcdefg"
    // [1,3] means shift to right by 3. "abcdefg" -> "efgabcd"

    public class StringShifts
    {
        public static void Init()
        {
            var str = "abcde";
            var response = Shift(str, new[] { new[] { 1, 7 } });
            Console.WriteLine(response);
        }

        private static string Shift(string s, int[][] shift)
        {
            var totalShift = shift.Sum(i => (i[0] == 0 ? -1 * i[1] : i[1])) % s.Length;
            if (totalShift == 0)
                return s;

            if (totalShift > 0)
            {
                //Right shift by finalShiftValue times
                s = s.Substring(s.Length - totalShift)
                    + s.Substring(0, s.Length - totalShift);
                return s;
            }

            if (totalShift < 0)
            {
                //Left shift by finalShiftValue times
                totalShift *= -1;
                s = s.Substring(totalShift) + s.Substring(0, totalShift);
                return s;
            }

            return s;
        }
    }
}
