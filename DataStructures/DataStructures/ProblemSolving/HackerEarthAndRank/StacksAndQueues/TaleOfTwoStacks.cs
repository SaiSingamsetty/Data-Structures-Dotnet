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

        private static void Execute(string[] args)
        {
            var firstStack = new Stack<int>();
            var secondStack = new Stack<int>();

            var tasks = Convert.ToInt32(Console.ReadLine());
            while (tasks >= 0)
            {
                var cmdValues = Console.ReadLine()?.Split(' ').Select(int.Parse).ToList();
                if(cmdValues == null)
                    continue;

                if (cmdValues[0] == 1)
                {
                    //Enqueue
                    firstStack.Push(cmdValues[1]);
                }
                else if(cmdValues[0] == 2)
                {
                     //Dequeue
                     if (secondStack.Count == 0)
                     {
                         while (firstStack.Count > 0)
                         {
                            secondStack.Push(firstStack.Pop());
                         }
                     }

                     secondStack.Pop();
                }
                else if (cmdValues[0] == 3)
                {
                    //Print first element on queue
                    if (secondStack.Count == 0)
                    {
                        if (firstStack.Count == 0)
                        {
                            Console.WriteLine("Queue is empty");
                            continue;
                        }

                        while (firstStack.Count > 0)
                        {
                            secondStack.Push(firstStack.Pop());
                        }
                    }

                    Console.WriteLine(secondStack.Peek());
                }
                else
                {
                    //Continue
                    continue;
                }

                tasks--;
            }

        }
    }
}
