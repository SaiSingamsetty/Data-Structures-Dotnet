using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days
{
    //Challenge2
    /*
     *  A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits,
     *  and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.
     */
    public class HappyNumber
    {
        public static void Init()
        {
            const int numToCheck = 19;
            var response = IsHappyNumber_UsingExtraMemory(numToCheck);
            Console.WriteLine("Response: " + response);
        }

        private static bool IsHappyNumber_UsingExtraMemory(int n)
        {
            var hash = new HashSet<int>();
            while (true)
            {
                var sum = SquareSumOfANumber(n);
                if (sum == 1) return true;

                if (hash.Contains(sum))
                    return false;
                hash.Add(sum);
                n = sum;
            }
        }

        //https://www.geeksforgeeks.org/happy-number/
        private static bool IsHappyNumber_NoExtraSpace(int n)
        {
            int slow;
            int fast;
            do
            {
                slow = SquareSumOfANumber(n);
                fast = SquareSumOfANumber(SquareSumOfANumber(n));
            } while (slow != fast);

            return slow == 1;
        }

        private static int SquareSumOfANumber(int num)
        {
            var temp = num;
            var sum = 0;
            while (temp > 0)
            {
                sum += Convert.ToInt32(Math.Pow(temp % 10, 2));
                temp /= 10;
            }

            return sum;
        }
    }
}