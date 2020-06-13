using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekOne
{
    // Challenge 5: https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3351/
    // Given an array w of positive integers, where w[i] describes the weight of index i,
    // write a function pickIndex which randomly picks an index in proportion to its weight.
    // Note:
    // 1 <= w.length <= 10000
    // 1 <= w[i] <= 10^5
    // pickIndex will be called at most 10000 times.
    // Input: 
    // ["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
    // [[[1,3]],[],[],[],[],[]]
    // Output: [null,0,1,1,1,0]

    public class RandomPickWithWeight
    {
        public static void Init()
        {
            var sol1 = new Solution(new[] { 3, 14, 1, 7 });
            var check1 = sol1.PickIndex();
            var check2 = sol1.PickIndex();
        }
    }

    public class Solution
    {
        private readonly int[] _wCum;

        public Solution(int[] w)
        {
            _wCum = new int[w.Length];
            _wCum[0] = w[0];
            for (var i = 1; i < w.Length; i++)
            {
                _wCum[i] = _wCum[i - 1] + w[i];
            }
        }

        public int PickIndex()
        {
            var idx = (new Random()).Next(1, _wCum[_wCum.Length - 1] + 1);
            return Search(idx);
        }

        private int Search(int val)
        {
            var l = 0;
            var r = _wCum.Length - 1;

            while (l < r)
            {
                var mid = l + (r - l) / 2;
                if (_wCum[mid] < val)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }
            }

            return l;
        }
    }
}