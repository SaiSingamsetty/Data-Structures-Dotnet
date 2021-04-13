using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.HackerEarthAndRank.Models;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.LinkedLists
{
    public static class InsertToSortedDoubleLinkedList
    {
        public static void Execute()
        {
            var head = new DoubleListNode(1);
            var secondNode = new DoubleListNode(2);
            var thirdNode = new DoubleListNode(4);
            var fourthNode = new DoubleListNode(10);

            head.Next = secondNode;

            secondNode.Next = thirdNode;
            secondNode.Prev = head;

            thirdNode.Next = fourthNode;
            thirdNode.Prev = secondNode;

            fourthNode.Prev = thirdNode;

            var res1 = Insert(head, 11);

        }

        private static DoubleListNode Insert(DoubleListNode head, int data)
        {
            var newNode = new DoubleListNode { Data = data };
            var pointer = head;

            if (head.Data >= data)
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
                return head;
            }

            while (head.Next != null && head.Next.Data < data)
            {
                head = head.Next;
            }

            newNode.Next = head.Next;
            newNode.Prev = head;
            head.Next = newNode;

            if (head.Next != null && newNode.Next != null)
                newNode.Next.Prev = newNode;

            return pointer;
        }
    }
}
