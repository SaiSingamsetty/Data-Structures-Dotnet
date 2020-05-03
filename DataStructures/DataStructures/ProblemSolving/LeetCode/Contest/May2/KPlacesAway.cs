using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May2
{
    //https://leetcode.com/problems/check-if-all-1s-are-at-least-length-k-places-away/
    //Refactor

    public class KPlacesAway
    {
        public static void Init()
        {
            var arr = new int[] { 1, 0, 0 };
            var res = FindIfKPlacesAway(arr, 1);
        }

        public static bool FindIfKPlacesAway(int[] nums, int k)
        {
            //find 1's positions
            var listOfIndices = new List<int>();
            var prevOne = -1;
            listOfIndices.Add(int.MaxValue);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    if (prevOne == -1)
                    {
                        prevOne = i + 1;
                    }
                    else
                    {                      
                        listOfIndices.Add(i + 1 - prevOne);
                        prevOne = i + 1;
                    }
                }
            }

            return listOfIndices.Min() > k;
        }
    }
}
