using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekThree
{
    public class StockSpan
    {
        public static void Init()
        {
            var obj = new StockSpanner();
            var s1 = obj.Next(100);
            var s2 = obj.Next(80);
            var s3 = obj.Next(60);
            var s4 = obj.Next(70);
            var s5 = obj.Next(60);
            var s6 = obj.Next(75);
            var s7 = obj.Next(80);
        }
    }

    public class StockSpanner
    {
        private readonly Stack<int> _stack;
        private readonly List<int> _span;
        private readonly List<int> _pricesList;
        private int _counter;

        public StockSpanner()
        {
            _stack = new Stack<int>();
            _span = new List<int>();
            _pricesList = new List<int>();
            _counter = 0;
        }

        public int Next(int price)
        {
            // _stack - keep track of day index
            // _span - span array for each day stock
            // _pricesList - keep track of prices till now for the stock

            while (_stack.Count != 0 && _pricesList[_stack.Peek()] <= price)
                _stack.Pop();

            if (_stack.Count == 0)
                _span.Add(_counter + 1);
            else
            {
                // It means all the elements in the stack are greater than the current price
                // So difference between the current day index and top of the stack (day index)
                _span.Add(_counter - _stack.Peek());
            }

            _stack.Push(_counter);
            _pricesList.Add(price);
            _counter++;
            return _span[_span.Count - 1];
        }
    }
}
