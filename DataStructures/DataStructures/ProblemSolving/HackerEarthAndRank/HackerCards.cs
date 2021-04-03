﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank
{
    public static class HackerCards
    {
        public static void Execute()
        {
            var res1 = Find(new[] {4, 6, 12, 8}, 14); //Output : 1,2,3,5
        }

        private static List<int> Find(int[] collection, int d)
        {
            var output = new List<int>();

            for (var i = 0; i <= collection.Length; i++)
            {
                int start;
                if (i == 0)
                {
                    start = 1;
                }
                else
                {
                    start = collection[i - 1] + 1;
                }

                var end = i != collection.Length ? collection[i] : int.MaxValue;

                if(d < start)
                    break;

                for (var j = start; j < end; j++)
                {
                    if (j <= d)
                    {
                        output.Add(j);
                        d -= j;
                    }
                    else
                    {
                        break;
                    }
                    
                }
            }
            
            return output;
        }
    }
}
