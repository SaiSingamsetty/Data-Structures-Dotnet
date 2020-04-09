using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekTwo
{
    //LEETCODE: Challenge9
    //https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/529/week-2/3291/
    //Given two strings S and T, return if they are equal when both are typed into empty text editors. # means a backspace character.
    //Input: S = "ab#c", T = "ad#c"
    // Output: true
    // Explanation: Both S and T become "ac".

    //Input: S = "a##c", T = "#a#c"
    // Output: true
    // Explanation: Both S and T become "c".

    //Input: S = "a#c", T = "b"
    // Output: false
    // Explanation: S becomes "c" while T becomes "b".

    public class BackSpaceStringCompare
    {
        public static void Init()
        {
            const string s = "bbbextm";
            const string t = "bbb#extm";
            var response = AreSameStringsLessSpace(s, t);
            Console.WriteLine(response);
        }

        //Using Stacks
        private static bool AreSameStrings(string S, string T)
        {
            var sStack = new Stack<char>();
            foreach (var eachChar in S)
            {
                if (eachChar != '#')
                {
                    sStack.Push(eachChar);
                }
                else if (sStack.Count != 0)
                {
                    sStack.Pop();
                }
            }

            var tStack = new Stack<char>();
            foreach (var eachChar in T)
            {
                if (eachChar != '#')
                {
                    tStack.Push(eachChar);
                }
                else if (tStack.Count != 0)
                {
                    tStack.Pop();
                }
            }

            while (sStack.Count != 0)
            {
                var curChar = sStack.Pop();
                if (tStack.Count == 0 || tStack.Pop() != curChar)
                {
                    return false;
                }
            }

            return sStack.Count == 0 && tStack.Count == 0;
        }

        //Less Space and faster
        private static bool AreSameStringsLessSpace(string S, string T)
        {
            var sPointer = S.Length - 1;
            var sSkips = 0;
            var tPointer = T.Length - 1;
            var tSkips = 0;

            while (sPointer >= 0 || tPointer >= 0)
            {
                while (sPointer >= 0)
                {
                    if (S[sPointer] == '#')
                    {
                        sSkips++;
                        sPointer--;
                    }
                    else if (sSkips > 0)
                    {
                        sSkips--;
                        sPointer--;
                    }
                    else
                    {
                        break;
                    }
                }

                while (tPointer >= 0)
                {
                    if (T[tPointer] == '#')
                    {
                        tSkips++;
                        tPointer--;
                    }
                    else if (tSkips > 0)
                    {
                        tSkips--;
                        tPointer--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (sPointer >= 0 && tPointer >= 0 && S[sPointer] != T[tPointer])
                    return false;

                if (sPointer >= 0 != tPointer >= 0)
                    return false;

                sPointer--;
                tPointer--;
            }

            return true;
        }

        //References: https://www.programcreek.com/2012/04/leetcode-backspace-string-compare-java/
    }
}