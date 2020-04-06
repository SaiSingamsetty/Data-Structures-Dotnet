using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Strings
{
    public class ReverseInteger
    {
        public static void Init()
        {
            const int num = 1463847412;
            var response = ReverseInt(num);
            Console.WriteLine(response);
        }

        private static int ReverseInt(int x)
        {
            var sum = 0;
            while (x != 0)
            {
                var pop = x % 10;
                x /= 10;

                //validate int range
                if (sum > int.MaxValue / 10 || (sum == int.MaxValue / 10 && pop > 7)) return 0;
                if (sum < int.MinValue / 10 || (sum == int.MinValue / 10 && pop < -8)) return 0;

                sum = sum * 10 + pop;
            }

            return sum;
        }

    }
}
