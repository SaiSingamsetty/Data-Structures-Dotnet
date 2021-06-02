using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.OtherPlatforms
{
    public static class LongestPalindromicSubString
    {
        public static void Execute()
        {
            var res0 = Find2("agedegs"); // gedeg
            var res1 = Find2("forgeeksskeegfor"); //geeksskeeg
        }

        private static string Find2(string str)
        {
            var n = str.Length;
            var table = new bool[n, n];

            var maxLength = 1;
            var start = 0;

            //Diagonal elements - always a palindrome - base cases
            for (var i = 0; i < n; ++i)
                table[i, i] = true;

            //For sub strings of size 2 - base cases
            for (var i = 0; i < n - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    table[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            //For sub strings of size 3 to n-1, i represents the length between the start and end
            /*
             * n = 7
             *
             * i = 2 : (0, 2) (1, 3) (2, 4) (3, 5) (4, 6)
             * i = 3 : (0, 3) (1, 4) (2, 5) (3, 6)
             * i = 4 : (0, 4) (1, 5) (2, 6)
             * i = 5 : (0, 5) (1, 6)
             * i = 6 : (0, 6)
             */
            for (var i = 2; i < n; i++)
            {
                // j value starts from 0 to  (n - i - 1) as shown above
                for (var j = 0; j < n - i; j++)
                {
                    //table(start, end) = str(start) == str(end) and table[start + 1, end - 1] should be palindrome
                    table[j, j + i] = str[j] == str[j + i] && table[j + 1, j + i - 1];
                    if (table[j, j + i] && i > maxLength)
                    {
                        // if i value is greater than maxLength, save maxLength and start of the palindrome
                        maxLength = i + 1;
                        start = j;
                    }
                }
            }


            return str.Substring(start, maxLength);
        }

        private static string Find(string str)
        {
            var n = str.Length;

            // Table[i, j] will be false if substring str[i..j] is not palindrome. Else table[i, j] will be true
            var table = new bool[n, n];


            var maxLength = 1;

            // All substrings of length 1 are palindromes
            for (var i = 0; i < n; ++i)
                table[i, i] = true;

            // Check for sub-string of length 2.
            var start = 0;
            for (var i = 0; i < n - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    table[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            // Check for lengths greater than 2.
            // k is length of substring
            for (var k = 3; k <= n; ++k)
            {
                // Fix the starting index
                for (var i = 0; i < n - k + 1; ++i)
                {
                    // Get the ending index of substring from
                    // starting index i and length k
                    var j = i + k - 1;

                    // Checking for sub-string from ith index
                    // to jth index iff str.charAt(i+1) to
                    // str.charAt(j-1) is a palindrome
                    if (table[i + 1, j - 1] && str[i] == str[j])
                    {
                        table[i, j] = true;
                        if (k > maxLength)
                        {
                            start = i;
                            maxLength = k;
                        }
                    }
                }
            }

            return str.Substring(start, maxLength);
        }
    }
}
