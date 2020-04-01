using System;

namespace DataStructures.ProblemSolving.Problems
{
    //LEETCODE : https://leetcode.com/problems/roman-to-integer/
    /*
       Input: "III"
       Output: 3
    */

    public class RomanToInteger
    {
        public static void Init()
        {
            const string inputString = "VIII"; //"MCMXCIV" ROMAN STRING
            var intOutput = ConvertRomanStringToInteger(inputString);
            Console.WriteLine("Integer: " + intOutput);
        }

        private static int ConvertRomanStringToInteger(string s)
        {
            var sum = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var currentChar = (Roman) Enum.Parse(typeof(Roman), s[i].ToString());
                var nextChar = (i + 1 < s.Length) ? (Roman) Enum.Parse(typeof(Roman), s[i + 1].ToString()) : Roman.O;

                // If current char is same or greater than next character, then sum it
                if (currentChar >= nextChar)
                {
                    sum += (int) currentChar;
                    continue;
                }

                // If current char is smaller than next char, We have to take the diff
                // IV will be (V - I) and increment pointer to skip 'V' in 'IV'
                sum += ((int) nextChar - (int) currentChar);
                i++;
            }

            return sum;
        }

        private enum Roman
        {
            O = 0, // Place holder
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000
        }
    }
}