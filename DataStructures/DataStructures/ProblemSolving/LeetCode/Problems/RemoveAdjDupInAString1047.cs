using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    public static class RemoveAdjDupInAString1047
    {
        public static void Execute()
        {
            var res1 = Find("abbaca");
        }

        private static string Find(string S)
        {
            var counter = 0;
            var sArray = new char[S.Length];

            for (var i = 0; i < sArray.Length; i++)
            {
                var currentValue = S[i];
                if (counter > 0 && currentValue == sArray[counter-1])
                {
                    //continue; // to make abbaaca -> abaca
                    counter--; // to make abbaaca -> ca
                }
                else
                {
                    sArray[counter] = currentValue;
                    counter += 1;
                }
            }

            return new string(sArray, 0, counter);
        }
    }
}
