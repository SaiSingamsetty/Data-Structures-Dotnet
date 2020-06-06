using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekTwo
{
    //LEETCODE Challenge10: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/529/week-2/3292/
    // Design a stack that supports push, pop, top, and retrieving the minimum element in constant time. 
    // push(x) -- Push element x onto stack.
    // pop() -- Removes the element on top of the stack.
    // top() -- Get the top element.
    // getMin() -- Retrieve the minimum element in the stack.


    public class MinStackProb
    {
        public static void Init()
        {
            SolveUsingMinValueStack();
            SolveUsingStackObject();
        }

        private static void SolveUsingMinValueStack()
        {
            // This MinStack is designed to use extra minimum value stack
            var ms = new Models.MinStack();
            ms.Pop();
            ms.Top();
            ms.GetMin();

            ms.Push(0);
            ms.Push(-1);
            ms.Push(-2);
            ms.Push(3);
            ms.GetMin();
            ms.Top();
        }

        private static void SolveUsingStackObject()
        {
            var ms = new MinStack();
            ms.Push(0);
            ms.Push(-1);
            ms.Pop();
            ms.Push(-2);
            ms.Push(3);
            ms.GetMin();
            ms.Top();
        }
    }

    #region HelperClasses

    public class MinStack
    {
        private StackObject _topStackObject;

        public void Push(int x)
        {
            if (_topStackObject == null)
            {
                _topStackObject = new StackObject(x);
            }
            else
            {
                var temp = new StackObject(x)
                {
                    Next = _topStackObject,
                    MinValue = Math.Min(x, _topStackObject.MinValue)
                };
                _topStackObject = temp;
            }
        }

        public void Pop()
        {
            if (_topStackObject == null) return;

            _topStackObject = _topStackObject.Next;
        }

        public int Top()
        {
            if (_topStackObject == null) return int.MaxValue;

            return _topStackObject.Value;
        }

        public int GetMin()
        {
            if (_topStackObject == null) return int.MaxValue;

            return _topStackObject.MinValue;
        }
    }

    public class StackObject
    {
        public int MinValue;

        public StackObject Next;
        public int Value;

        public StackObject(int value)
        {
            Value = value;
            MinValue = value;
            Next = null;
        }
    }

    #endregion
}