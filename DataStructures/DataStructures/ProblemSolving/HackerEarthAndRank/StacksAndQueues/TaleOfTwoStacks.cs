using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.StacksAndQueues
{
    public static class TaleOfTwoStacks
    {
        public static void Execute()
        {
            Execute(new string[]
            {
                "10",
                "1 42",
                "2",
                "1 14",
                "3",
                "1 28",
                "3",
                "1 60",
                "1 78",
                "2",
                "2"
            });
        }

        private static readonly Stack<int> NewStack = new Stack<int>();
        private static readonly Stack<int> OldStack = new Stack<int>();
        
        private static void Execute(string[] args)
        {
            var tasks = Convert.ToInt32(Console.ReadLine());

            while (tasks >= 0)
            {
                var cmdValues = Console.ReadLine()?.Split(' ');
                if (cmdValues == null)
                    break;
                
                if (cmdValues[0] == "1")
                {
                    //Enqueue
                    Enqueue(Convert.ToInt32(cmdValues[1]));
                }
                else if(cmdValues[0] == "2")
                {
                     //Dequeue
                     Dequeue();
                }
                else if (cmdValues[0] == "3")
                {
                    //Print first element on queue
                    Console.WriteLine(GetFrontValue());
                }

                tasks--;
            }

        }

        private static void Enqueue(int value)
        {
            NewStack.Push(value);
        }

        private static int GetFrontValue()
        {
            PopulateOldStack();
            return OldStack.Peek();
        }

        private static void Dequeue()
        {
            PopulateOldStack();
            OldStack.Pop();
        }

        private static void PopulateOldStack()
        {
            if (OldStack.Count == 0)
            {
                while (NewStack.Count != 0)
                {
                    OldStack.Push(NewStack.Pop());
                }
            }
        }
    }
}
