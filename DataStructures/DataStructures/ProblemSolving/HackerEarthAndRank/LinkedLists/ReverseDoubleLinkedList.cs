using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.HackerEarthAndRank.Models;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.LinkedLists
{
    public static class ReverseDoubleLinkedList
    {
        public static void Execute()
        {
            var head = new DoubleListNode(1);
            var secondNode = new DoubleListNode(2);
            var thirdNode = new DoubleListNode(3);
            var fourthNode = new DoubleListNode(4);

            head.Next = secondNode;

            secondNode.Next = thirdNode;
            secondNode.Prev = head;

            thirdNode.Next = fourthNode;
            thirdNode.Prev = secondNode;

            fourthNode.Prev = thirdNode;

            var res1 = Reverse(head);
        }

        private static DoubleListNode Reverse(DoubleListNode head)
        {
            var currentNode = head;
            DoubleListNode temp = null;

            while (currentNode != null)
            {
                temp = currentNode.Prev;
                currentNode.Prev = currentNode.Next;
                currentNode.Next = temp;

                currentNode = currentNode.Prev;
            }

            if (temp != null)
                head = temp.Prev;

            return head;
        }
    }
}
