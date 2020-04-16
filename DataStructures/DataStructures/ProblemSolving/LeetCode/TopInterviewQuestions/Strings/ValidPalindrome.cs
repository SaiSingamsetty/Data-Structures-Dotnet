using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Strings
{
    //https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/883/
    //Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
    // 
    // Note: For the purpose of this problem, we define empty string as valid palindrome.

    public class ValidPalindrome
    {
        public static void Init()
        {
            const string s = "0P";
            Console.WriteLine(IsValidPalindrome(s));
        }

        private static bool IsValidPalindrome(string s)
        {
            s = s.ToLower();
            var l = 0;
            var h = s.Length - 1;

            while (l <= h)
            {
                var charL = s[l];
                var charH = s[h];

                // If there is another symbol  
                // in left of sentence 
                if (!((charL >= 'a' &&
                       charL <= 'z') || (charL >= '0' && charL <= '9')))
                    l++;

                // If there is another symbol   
                // in right of sentence 
                else if (!((charH >= 'a' &&
                            charH <= 'z') || (charH >= '0' && charH <= '9')))
                    h--;

                // If characters are equal 
                else if (charL == charH)
                {
                    l++;
                    h--;
                }

                // If characters are not equal then 
                // sentence is not palindrome 
                else
                    return false;
            }

            return true;
        }
    }
}
