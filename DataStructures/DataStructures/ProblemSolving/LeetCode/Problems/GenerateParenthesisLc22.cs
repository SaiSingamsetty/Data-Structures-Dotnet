using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    public static class GenerateParenthesisLc22
    {
        /*
         * n = 2 : {}{}, {{}}
         * n = 3 :
           {}{}{}
           {}{{}}
           {{}}{}
           {{}{}}
           {{{}}}
         */
        public static void Execute()
        {
            var res1 = Generate(3);
        }

        private static List<string> _results = new List<string>();

        private static List<string> Generate(int n)
        {
            _results = new List<string>();
            RecursionHelper(n , n , "");
            return _results;
        }

        private static void RecursionHelper(int oc, int cc, string str)
        {
            if(oc == 0 && cc == 0)
                _results.Add(str);

            if(oc > cc)
                return;

            if(oc > 0)
                RecursionHelper(oc-1, cc, str + '(');

            if(cc > 0)
                RecursionHelper(oc, cc-1, str + ')');
        }
    }
}
