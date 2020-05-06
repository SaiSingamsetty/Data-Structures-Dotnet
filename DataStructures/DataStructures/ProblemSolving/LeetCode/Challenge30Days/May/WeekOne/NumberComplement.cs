using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne
{
    public class NumberComplement
    {
        public static void Init()
        {
            Console.WriteLine(FindComplement(5));
        }

        private static int FindComplement(int num)
        {
            int result = 0;
            int i = 0;
            while (num > 0)
            {
                if ((num & 1) == 0)
                    result += 1 << i;

                i += 1;
                num >>= 1;
            }
            return result;

        }
    }
}
