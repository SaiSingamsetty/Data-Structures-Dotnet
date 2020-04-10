using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekTwo.Models
{
    public class MinStack
    {
        /** initialize your data structure here. */
        private readonly Stack<int> _stack;
        private readonly Stack<int> _minValueStack;

        public MinStack()
        {
            _stack = new Stack<int>();
            _minValueStack = new Stack<int>();
        }

        public void Push(int x)
        {
            if (_minValueStack.Count == 0 || x <= _minValueStack.Peek())
                _minValueStack.Push(x);
            _stack.Push(x);
        }

        public void Pop()
        {
            if(_stack.Count == 0 || _minValueStack.Count ==0)
                return;
            
            if (_stack.Peek().Equals(_minValueStack.Peek()))
            {
                _minValueStack.Pop();
            }
            _stack.Pop();
        }

        public int Top()
        {
            if (_stack.Count == 0)
                return int.MaxValue;

            return _stack.Peek();
        }

        public int GetMin()
        {
            if (_minValueStack.Count == 0)
                return int.MaxValue;

            return _minValueStack.Peek();
        }
    }
}
