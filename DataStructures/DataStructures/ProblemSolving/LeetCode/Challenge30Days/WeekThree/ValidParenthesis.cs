using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekThree
{
    public class ValidParenthesis
    {
        public static void Init()
        {
            const string s = "((*)";
            Console.WriteLine(IsValidParenthesisApproach3(s));
        }

        private static bool IsValidParenthesis(string s)
        {
            var starCounter = 0;
            var sum = 0;

            foreach (var eachChar in s)
            {
                if (sum < 0)
                    return false;

                if (eachChar == '(')
                    sum++;
                else if (eachChar == ')')
                {
                    sum--;
                }
                else if (eachChar == '*')
                {
                    starCounter++;
                }

            }

            sum = sum > 0 ? sum - starCounter : sum;

            return sum == 0;
        }

        private static bool IsValidParenthesisUsingStack(string s)
        {
            var stack = new Stack<char>();
            var counter = 0;

            foreach (var eachChar in s)
            {
                if (eachChar == '(')
                    stack.Push(eachChar);
                else if (eachChar == '*')
                {
                    counter++;
                }
                else if (eachChar == ')')
                {
                    var pop = stack.Count != 0 ? stack.Pop() : ')';
                    if (pop == ')')
                    {
                        if (counter > 0)
                            counter--;
                        else
                        {
                            return false;
                        }
                    }

                }
            }

            var countOfOpen = stack.Count(x => x == '(');
            var res = countOfOpen <= 0 || countOfOpen <= counter;

            return res;
        }

        //Approach3
        private static bool IsValidParenthesisApproach3(string s)
        {
            var res = Validate(s, 0,0);
            return res;
        }

        //private static int Validate(string s, string actualString)
        //{
        //    var count = 0;

        //    for (var i = 0; i < s.Length; i++)
        //    {
        //        var c = s[i];
        //        if (c == '(')
        //        {
        //            count++;
        //        }
        //        else if (c == ')')
        //        {
        //            count--;
        //        }
        //        else if (c == '*')
        //        {
        //            var sol1 = count + Validate(" " + s.Substring(i + 1), s);
        //            var sol2 = count + Validate("(" + s.Substring(i + 1), s);
        //            var sol3 = count + Validate(")" + s.Substring(i + 1), s);

        //            return new[] { sol3, sol1, sol2 }.Any(x => x == 0) ? 0 : -1;
        //        }

        //        if (s == actualString && count < 0)
        //            return -1;
        //    }

        //    return count;
        //}

        private static bool Validate(string s, int start, int count)
        {
            if (count < 0)
                return false;

            for (var i = start; i < s.Length; i++)
            {
                var c = s[i];
                if (c == '(')
                {
                    count++;
                }
                else if (c == ')')
                {
                    count--;
                }
                else if (c == '*')
                {
                    //var sol1 = Validate(" " + s.Substring(i + 1), count);
                    //var sol2 = Validate("(" + s.Substring(i + 1), count);
                    //var sol3 = Validate(")" + s.Substring(i + 1), count);

                    //var sol1 = Validate(s.Substring(i + 1), count);
                    //var sol2 = Validate(s.Substring(i + 1), count + 1);
                    //var sol3 = Validate(s.Substring(i + 1), count - 1);

                    //Either a space 
                    var sol1 = Validate(s, i + 1, count);

                    //Either a '('
                    var sol2 = Validate(s, i + 1, count + 1);

                    //Either a ')'
                    var sol3 = Validate(s, i + 1, count - 1);

                    return sol1 || sol2 || sol3;
                }

                if (count < 0)
                    return false;

            }

            return count == 0;
        }
    }
}
