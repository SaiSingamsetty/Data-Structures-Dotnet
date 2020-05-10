using System.Collections.Generic;

namespace DataStructures.ProblemSolving.OtherPlatforms
{
    // https://www.youtube.com/watch?v=W_lzMUGgeYg&feature=youtu.be
    // https://insidecode.teachable.com/blog/208014/sort-stack
    // Sort a stack using another stack only, the smallest number should be on top

    public class InsideCodesSortStack
    {
        public static void Init()
        {
            var stack = new Stack<int>();
            stack.Push(7);
            stack.Push(1);
            stack.Push(9);
            stack.Push(8);
            stack.Push(2);
            stack.Push(3);
            stack.Push(5);

            Sort(stack);
        }

        private static void Sort(Stack<int> stack)
        {
            var tempStack = new Stack<int>();

            while (stack.Count != 0)
            {
                var temp = stack.Pop();

                if (tempStack.Count == 0 || temp > tempStack.Peek())
                    tempStack.Push(temp);
                else
                {
                    while (tempStack.Count != 0 && tempStack.Peek() > temp)
                    {
                        stack.Push(tempStack.Pop());
                    }

                    tempStack.Push(temp);
                }
            }

            while (tempStack.Count != 0)
            {
                stack.Push(tempStack.Pop());
            }
        }

        //little more optimized code is available at the top link pasted
    }
}