using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.HackerEarthAndRank.Models;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.LinkedLists
{
    public static class InsertNodeAtSpecifiedLoc
    {
        public static void Execute()
        {
            var head1 = new ListNode(1);
            head1.Next = new ListNode(2);
            head1.Next.Next = new ListNode(3);
            head1.Next.Next.Next = new ListNode(5);
            head1.Next.Next.Next.Next = new ListNode(6);

            var res1 = InsertNodeAt(head1, 4, 7);
        }

        private static ListNode InsertNodeAt(ListNode head, int data, int position)
        {
            if (position < 1)
                return head;

            var newNode = new ListNode(data);

            //Keep original reference to the linked list in Pointer
            //Modify in head node, it will impact in pointer as it is reference type 
            var pointer = head;

            if (position == 1)
            {
                newNode.Next = head;
                pointer = newNode;
            }
            else
            {
                //Just breaking at position - 1 and attach next part to new node
                for (var i = 1; i < position - 1; i++)
                {
                    head = head.Next;
                }

                newNode.Next = head.Next;
                head.Next = newNode;
            }
            
            return pointer;
        }
    }
}
