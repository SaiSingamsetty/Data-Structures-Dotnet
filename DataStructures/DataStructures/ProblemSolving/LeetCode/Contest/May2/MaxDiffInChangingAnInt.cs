using System;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May2
{
    //https://leetcode.com/problems/max-difference-you-can-get-from-changing-an-integer/
    // INCOMPLETE

    public class MaxDiffInChangingAnInt
    {
        public static void Init()
        {
            var res = FindDiff(1101057); //8700
            //var res = StringBreak("abc", "xya");
        }

        private static int FindDiff(int num)
        {
            var arr = num.ToString().ToCharArray().Select(x => (int)x - '0').ToArray();

            //first get max no
            var maxNum = num;
            var minNum = num;
            foreach (var eachNum in arr)
            {
                if (eachNum == 9)
                    continue;
                var target = eachNum;
                maxNum = int.Parse(num.ToString().Replace($"{target}", "9"));
                break;
            }
            //min
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)
                    continue;
                var target = arr[i];
                minNum = i == 0
                    ? int.Parse(num.ToString().Replace($"{target}", "1"))
                    : int.Parse(num.ToString().Replace($"{target}", "0"));
                break;
            }

            return maxNum - minNum;
        }
    }
}
