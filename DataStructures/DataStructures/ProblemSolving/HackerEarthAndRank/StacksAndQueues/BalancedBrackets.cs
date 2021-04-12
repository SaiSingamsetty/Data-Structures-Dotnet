using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.StacksAndQueues
{
    public static class BalancedBrackets
    {
        public static void Execute()
        {
            var res1 = IsBalancedApproach2("{[()]}"); //Yes
            var res2 = IsBalancedApproach2("{[(])}"); //No
            var res3 = IsBalancedApproach2("{{[[(())]]}}"); //Yes
        }

        private static string IsBalanced(string s)
        {
            var stack = new Stack<char>();

            if (s.Length % 2 == 1)
                return "NO";

            foreach (var eachChar in s)
            {
                if (eachChar == '(' || eachChar == '{' || eachChar == '[')
                {
                    stack.Push(eachChar);
                }
                else
                {
                    if (stack.Count == 0)
                        return "NO";

                    if (!IsRightPair(stack.Pop(), eachChar))
                    {
                        return "NO";
                    }
                }
            }

            return stack.Count == 0 ? "YES" : "NO";
        }

        private static bool IsRightPair(char peek, char onHold)
        {
            return (peek == '{' && onHold == '}') || (peek == '[' && onHold == ']') ||
                       (peek == '(' && onHold == ')');
        }

        private static string IsBalancedApproach2(string s)
        {
            var stack = new Stack<char>();

            foreach (var eachChar in s)
            {
                switch (eachChar)
                {
                    case '(':
                        stack.Push(')');
                        break;

                    case '{':
                        stack.Push('}');
                        break;

                    case '[':
                        stack.Push(']');
                        break;

                    default:
                        if (stack.Count == 0 || stack.Pop() != eachChar)
                        {
                            return "NO";
                        }
                        break;
                }
            }

            return stack.Count == 0 ? "YES" : "NO";
        }
    }
}
