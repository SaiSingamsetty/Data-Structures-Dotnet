using System;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May2
{
    //https://leetcode.com/problems/check-if-a-string-can-break-another-string/
    //REFACTOR

    public class StringBreak
    {
        public static void Init()
        {
            var res = FindIfStringBreaks("abc", "xya");
        }

        private static bool FindIfStringBreaks(string s1, string s2)
        {
            var arr1 = s1.ToCharArray();
            var arr2 = s2.ToCharArray();
            Array.Sort(arr1);
            Array.Sort(arr2);
            var counter = 0;
            var equalCounter = 0;

            for (var i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] > arr2[i])
                    counter++;
                else if (arr1[i] == arr2[i])
                    equalCounter++;
            }

            if (counter == arr1.Length || counter + equalCounter == arr1.Length)
                return true;


            if (counter > 0)
                return false;

            return true;
        }
    }
}