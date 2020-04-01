using System;
using DataStructures.LinkedListProblems.Models;

namespace DataStructures.LinkedListProblems.CircularLinkedListChallenges
{
    public static class ListTraversal
    {
        public static void Init()
        {
            var myList = new LinkedList();
            var firstNode = new Node(1);
            var secondNode = new Node(2);
            var thirdNode = new Node(3);
            var fourthNode = new Node(4);
            myList.Head = firstNode;
            myList.Head.Next = secondNode;
            secondNode.Next = thirdNode;
            thirdNode.Next = fourthNode;
            fourthNode.Next = myList.Head;

            TraverseList(thirdNode);
        }

        private static void TraverseList(Node refNode)
        {
            var tempNode = refNode;

            Console.WriteLine($"Node {tempNode.Data}");

            while (tempNode.Next != refNode)
            {
                tempNode = tempNode.Next;
                Console.WriteLine($"Node {tempNode.Data}");
            }
        }
    }
}