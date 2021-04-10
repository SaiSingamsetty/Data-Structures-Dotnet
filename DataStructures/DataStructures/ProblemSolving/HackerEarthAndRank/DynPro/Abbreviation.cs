using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.DynPro
{
    public static class Abbreviation
    {
        public static void Execute()
        {
            var res1 = Find("AbcDE", "ABDE"); //Yes
            var res2 = Find("AbcDE", "AFDE"); //No
            var res3 = Find("daBcd", "ABC"); //Yes
            var res4 = Find("AfPZN", "APZNC"); //Yes
        }

        private static string Find(string a, string b)
        {
            var response = AbbreviationFunction(a.ToCharArray(), b.ToCharArray(), a.Length, b.Length);
            return response ? "YES" : "NO";
        }

        private static bool AbbreviationFunction(char[] a, char[] b, int aPointer, int bPointer)
        {
            if (aPointer < bPointer)
            {
                return false;
            }

            if (aPointer <= 0 && bPointer > 0)
            {
                return false;
            }

            if (bPointer <= 0)
            {
                for (int i = 0; i < aPointer; i++)
                {
                    if (!IsLowerCase(a[aPointer - 1]))
                    {
                        return false;
                    }

                    aPointer--;
                }
            }

            if (aPointer == 0 && bPointer == 0)
            {
                return true;
            }

            if (a[aPointer - 1] == b[bPointer - 1])
            {
                return AbbreviationFunction(a, b, aPointer - 1, bPointer - 1);
            }

            if (a[aPointer - 1] - 32 == b[bPointer - 1])
            {
                return AbbreviationFunction(a, b, aPointer - 1, bPointer - 1);
            }

            if(IsLowerCase(a[aPointer - 1]))
            {
                return AbbreviationFunction(a, b, aPointer - 1, bPointer);
            }

            return false;
        }

        private static bool IsLowerCase(char c)
        {
            return (c > 'a' && c < 'z');
        }
    }
}
