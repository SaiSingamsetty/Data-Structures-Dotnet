using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.StacksAndQueues
{
    public static class LargestRectangle
    {
        public static void Execute()
        {
            var res1 = Find(new[] {6, 2, 5, 4, 5, 1, 6}); //12
            var res2 = Find(new[] {3, 2, 3});
        }

        private static long Find(int[] hist)
        {
            var stack = new Stack<int>();
            var area = 0;
            hist = hist.Append(0).ToArray();

            for (int j = 0; j < hist.Length; j++)
            {
                if(stack.Count == 0 || hist[j] > hist[stack.Peek()])
                    stack.Push(j);
                else
                {
                    var top = stack.Pop();
                    area = Math.Max(area, hist[top] * (stack.Count == 0 ? j : (j - stack.Peek() - 1)));
                    j--;
                }
            }

            return area;
        }
    }
}
