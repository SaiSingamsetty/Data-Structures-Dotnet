using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May16
{
    // Leetcode 1447: https://leetcode.com/problems/simplified-fractions/
    // Given an integer n, return a list of all simplified fractions between 0 and 1 (exclusive) such that the denominator 
    // is less-than-or-equal-to n. The fractions can be in any order.
    // Input: n = 2
    // Output: ["1/2"]
    // Explanation: "1/2" is the only unique fraction with a denominator less-than-or-equal-to 2.
    // Input: n = 3
    // Output: ["1/2","1/3","2/3"]
    // Input: n = 4
    // Output: ["1/2","1/3","1/4","2/3","3/4"]
    // Explanation: "2/4" is not a simplified fraction because it can be simplified to "1/2".
    // Input: n = 1
    // Output: []


    public class SimplifiedFractions
    {
        public static void Init()
        {
            var res1 = FindSimplifiedFractions(5);
        }

        private static IList<string> FindSimplifiedFractions(int n)
        {
            var list = new List<string>();

            for (var i = 1; i <= n - 1; i++)
            {
                for (var j = 2; j <= n; j++)
                {
                    var gcd = FindGcd(i, j);
                    if (i / j == 1 || i / j > 1)
                        continue;

                    if (gcd == 1)
                    {
                        list.Add(i + "/" + j);
                    }
                    else
                    {
                        var item = i / gcd + "/" + j / gcd;
                        if (!list.Contains(item))
                            list.Add(item);
                    }
                }
            }

            return list;
        }

        private static int FindGcd(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }
    }
}