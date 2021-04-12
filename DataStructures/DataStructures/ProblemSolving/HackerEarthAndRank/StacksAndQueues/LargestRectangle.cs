using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.StacksAndQueues
{
    public static class LargestRectangle
    {
        public static void Execute()
        {
            var res1 = Find(new[] {6, 2, 5, 4, 5, 1, 6}); //12
        }

        private static long Find(int[] hist)
        {
            var s = new Stack<int>();

            var maxArea = 0; // Initialize max area
            int tp; // To store top of stack
            int areaWithTop; // To store area with top 
            // bar as the smallest bar
            
            var i = 0;
            while (i < hist.Length)
            {
                // If this bar is higher than the 
                // bar on top stack, push it to stack 
                if (s.Count == 0 || hist[s.Peek()] <= hist[i])
                {
                    s.Push(i++);
                }

                // If this bar is lower than top of stack,
                // then calculate area of rectangle with 
                // stack top as the smallest (or minimum  
                // height) bar. 'i' is 'right index' for 
                // the top and element before top in stack
                // is 'left index' 
                else
                {
                    tp = s.Peek(); // store the top index
                    s.Pop(); // pop the top

                    // Calculate the area with hist[tp]
                    // stack as smallest bar 
                    areaWithTop = hist[tp] *
                                    (s.Count == 0 ? i : i - s.Peek() - 1);

                    // update max area, if needed 
                    if (maxArea < areaWithTop)
                    {
                        maxArea = areaWithTop;
                    }
                }
            }

            // Now pop the remaining bars from 
            // stack and calculate area with every 
            // popped bar as the smallest bar 
            while (s.Count > 0)
            {
                tp = s.Peek();
                s.Pop();
                areaWithTop = hist[tp] *
                                (s.Count == 0 ? i : i - s.Peek() - 1);

                if (maxArea < areaWithTop)
                {
                    maxArea = areaWithTop;
                }
            }

            return maxArea;

        }
    }
}
