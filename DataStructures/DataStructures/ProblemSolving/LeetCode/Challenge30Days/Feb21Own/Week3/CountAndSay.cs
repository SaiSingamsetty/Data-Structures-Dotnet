using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.Feb21Own.Week3
{
    // https://leetcode.com/problems/count-and-say/
    
    public class CountAndSay
    {
        public static void Execute()
        {
            var ut1 = Count(4);
        }

        public static string Count(int n)
        {
            var list = new List<string> {"1"};
            for (var i = 1; i <= n; i++)
            {
                list.Add(Generate(list[i-1]));
            }

            return list[n];
        }

        private static string Generate(string str)  
        {
            var sb = new StringBuilder();
            var count = 1;
            var prevChar = str[0];

            for(var i = 1; i < str.Length; i++)
            {
                if (str[i] != prevChar)
                {
                    sb.Append(count).Append(prevChar);
                    prevChar = str[i];
                    count = 1;
                }
                else
                {
                    count++;
                }
                
            }

            sb.Append(count).Append(prevChar);
            return sb.ToString();
        }

    }
}