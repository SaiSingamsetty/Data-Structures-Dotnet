using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May16
{
    public class RearrangeWords
    {
        public static void Init()
        {
            var res1 = ExecuteUsingApproach3("Leetcode is fun");
            var res2 = ExecuteUsingApproach3("Keep calm and code on");
            var res3 = ExecuteUsingApproach3("You and i");
        }

        //TIME LIMIT EXCEEDED
        private static string ExecuteUsingApproach1(string text)
        {
            var stringInputArray = text.Split(' ');

            var lookUp = new Dictionary<int, int>();
            for (var i = 0; i < stringInputArray.Length; i++)
            {
                lookUp.Add(i, stringInputArray[i].Length);
            }

            var orderByLength = lookUp.OrderBy(x => x.Value);

            var outputString = string.Empty;

            for (var i = 0; i < orderByLength.Count(); i++)
            {
                var newIndex = orderByLength.ToList()[i].Key;
                if (i == 0)
                    outputString += char.ToUpper(stringInputArray[newIndex][0]) +
                                    stringInputArray[newIndex].Substring(1) + " ";
                else
                {
                    outputString += stringInputArray[newIndex].ToLower() + " ";
                }
            }

            return outputString.TrimEnd();
        }

        //TIME LIMIT EXCEEDED
        private static string ExecuteUsingApproach2(string text)
        {
            var stack = new Stack<string>();
            var stringInputArray = text.Split(' ').ToList();
            var tempStack = new Stack<string>();

            for (var i = 0; i < stringInputArray.Count; i++)
            {
                while (stack.Count != 0 && stack.Peek().Count() > stringInputArray[i].Length)
                {
                    tempStack.Push(stack.Pop().ToLower());
                }

                stack.Push(stringInputArray[i].ToLower());

                while (tempStack.Count != 0)
                    stack.Push(tempStack.Pop());
            }

            var temp = string.Empty;
            while (stack.Count() != 0)
            {
                if (stack.Count() == 1)
                {
                    var pop = stack.Pop();
                    temp = char.ToUpper(pop[0]) + pop.Substring(1) + " " + temp;
                }
                else
                {
                    temp = stack.Pop() + " " + temp;
                }
            }

            return temp.Trim();
        }

        //DISCUSSIONS - ERROR
        private static string ExecuteUsingApproach3(string text)
        {
            var s = text.ToLower().Split(" ");
            Array.Sort(s, (a, b) => a.Length - b.Length);
            var ans = string.Join(" ", s);
            return char.ToUpper(ans[0]) + ans.Substring(1);
        }
    }
}