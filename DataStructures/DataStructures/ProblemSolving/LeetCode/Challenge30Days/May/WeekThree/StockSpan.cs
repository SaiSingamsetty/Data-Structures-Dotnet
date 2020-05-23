using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekThree
{
    public class StockSpan
    {
        public static void Init()
        {

        }
    }

    //https://www.youtube.com/watch?v=JsYyLiGXHsc
    public class StockSpanner
    {
        private readonly int[][] _stack;
        private int _top;

        public StockSpanner()
        {
            _stack = new int[2][];
            _stack[0] = new int[10000];
            _stack[1] = new int[10000];
            _top = -1;
        }

        public int Next(int price)
        {
            var span = 1;
            while (_top >= 0 && _stack[0][_top] <= price)
            {
                span += _stack[1][_top];
                _top--;
            }

            _top++;
            _stack[0][_top] = price;
            _stack[1][_top] = span;
            return span;
        }
    }
}
