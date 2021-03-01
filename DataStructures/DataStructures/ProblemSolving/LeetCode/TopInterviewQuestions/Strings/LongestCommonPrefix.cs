using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Strings
{
    public class LongestCommonPrefix
    {
        public static void Execute()
        {
            var res1 = Find(new[] {"flower", "flow", "flight"});
        }

        private static string Find(string[] strs)
        {
            if (strs.Length == 0)
                return "";

            var pre = strs[0];
            for (var i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(pre, StringComparison.Ordinal) != 0)
                {
                    pre = pre.Substring(0, pre.Length - 1);
                    if (string.IsNullOrWhiteSpace(pre))
                        return "";
                }
            }

            return pre;
        }
    }
}
