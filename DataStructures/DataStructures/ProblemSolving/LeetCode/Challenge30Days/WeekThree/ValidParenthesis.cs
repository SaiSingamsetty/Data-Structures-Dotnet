using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekThree
{
    //Challenge16 : https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/530/week-3/3301/
    //Given a string containing only three types of characters: '(', ')' and '*', write a function to check whether this string is valid. We define the validity of a string by these rules:
    // 
    // Any left parenthesis '(' must have a corresponding right parenthesis ')'.
    // Any right parenthesis ')' must have a corresponding left parenthesis '('.
    // Left parenthesis '(' must go before the corresponding right parenthesis ')'.
    // '*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string.
    // An empty string is also valid.

    public class ValidParenthesis
    {
        public static void Init()
        {
            const string s = "(*)";
            Console.WriteLine(ValidateParenthesisUsingTwoStacks(s));
        }

        // Time complexity is less and space complexity is little high (Two stacks)

        #region Approach 2 : Using two stacks 

        //Reference https://www.youtube.com/watch?v=KuE_Cn3xhxI


        private static bool ValidateParenthesisUsingTwoStacks(string s)
        {
            var openStack = new Stack<int>();
            var starStack = new Stack<int>();

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    openStack.Push(i);
                else if (s[i] == '*')
                    starStack.Push(i);
                else if (s[i] == ')')
                {
                    if (openStack.Count != 0)
                        openStack.Pop();
                    else if (starStack.Count != 0)
                        starStack.Pop();
                    else
                    {
                        return false;
                    }
                }
            }

            //Balance remaining open brackets with stars available in the stack. if it is not possible, return False
            while (openStack.Count != 0)
            {
                if (starStack.Count == 0)
                    return false;
                if (openStack.Peek() < starStack.Peek())
                {
                    openStack.Pop();
                    starStack.Pop();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        //Time complexity is O(N) and space complexity is O(1)

        #region Approach  3 : Left and Right Balancing

        private static bool ValidateParenthesisUsingTwoLoops(string s)
        {
            var leftBalance = 0;
            foreach (var eachChar in s)
            {
                if ((eachChar == '(') || (eachChar == '*'))
                    leftBalance++;
                else
                    leftBalance--;

                if (leftBalance < 0) return false; // We know we have unbalanced parenthesis
            }

            // We can already check if parenthesis are valid
            if (leftBalance == 0) return true;

            var rightBalance = 0;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if ((s[i] == ')') || (s[i] == '*'))
                    rightBalance++;
                else
                    rightBalance--;

                if (rightBalance < 0) return false; // We know we have unbalanced parenthesis
            }

            // Here we know we have never been unbalanced parsing from left to right e.g. ')('
            // We've also already substituted '*' either by '(' or by ')'
            // So we only have 3 possible scenarios here:
            // 1. We had the same amount of '(' and ')'
            // 2. We had more '(' then ')' but enough '*' to substitute
            // 3. We had more ')' then '(' but enough '*' to substitute
            return true;
        }

        #endregion

        // Time consuming (Recursions)

        #region Approach 1 : Validating by assuming '*' in all 3 possible approaches '(', ')', ' ' and verifying if any one approach is balanced

        private static bool IsValidParenthesisUsingRecursions(string s)
        {
            var res = Validate(s, 0, 0);
            return res;
        }

        private static bool Validate(string s, int start, int count)
        {
            if (count < 0)
                return false;

            for (var i = start; i < s.Length; i++)
            {
                var c = s[i];
                if (c == '(')
                {
                    count++;
                }
                else if (c == ')')
                {
                    count--;
                }
                else if (c == '*')
                {
                    //Either a space 
                    var sol1 = Validate(s, i + 1, count);

                    //Either a '('
                    var sol2 = Validate(s, i + 1, count + 1);

                    //Either a ')'
                    var sol3 = Validate(s, i + 1, count - 1);

                    return sol1 || sol2 || sol3;
                }

                if (count < 0)
                    return false;
            }

            return count == 0;
        }

        #endregion
    }
}