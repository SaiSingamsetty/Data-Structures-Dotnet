using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.April21.WeekOne.Models;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April21.WeekOne
{
    public static class LinkedListPalindrome
    {
        public static void Execute()
        {
            var head = new ListNode(1)
            {
                Next = new ListNode(2)
                {
                    Next = new ListNode(2)
                    {
                        Next = new ListNode(1)
                    }
                }
            };

            Console.WriteLine(IsPalindrome(head));
        }

        private static bool IsPalindrome(ListNode head)
        {
            var temp = head;

            while (temp != null)
            {


                temp = temp.Next;
            }

            return true;
        }
    }
}
