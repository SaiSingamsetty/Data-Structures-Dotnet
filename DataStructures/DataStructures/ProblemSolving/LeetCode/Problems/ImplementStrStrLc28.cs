using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    public class ImplementStrStrLc28
    {
        public static void Init()
        {
            Console.WriteLine(ImplStr("mississippi", "issip"));
        }

        private static int ImplStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;

            if (needle.Length > haystack.Length)
                return -1;

            var counter = 0;
            var index = -1;
            for (int i = 0, j = 0; i < haystack.Length && j < needle.Length; i++)
            {
                if (haystack[i] != needle[j])
                {
                    if (counter != 0)
                    {
                        counter = 0;
                        j = 0;
                        i = i - 2;
                        index = -1;
                    }
                    continue;
                }

                index = index == -1 ? i : index;
                counter++;
                j++;
            }

            if (counter == needle.Length)
                return index;

            if (counter == 0)
                return index;

            return counter;
        }
    }
}
