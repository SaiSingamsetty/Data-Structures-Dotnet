using System;
using DataStructures.DataStructureSpecific.LinkedListProblems.Models;

namespace DataStructures.DataStructureSpecific.LinkedListProblems
{
    public class LinkedList
    {
        public Node Head;

        public void PrintLinkedList()
        {
            var currentNode = Head;
            if (currentNode == null)
                Console.Write("List is empty\n\n");

            while (currentNode != null)
            {
                Console.Write("Node " + currentNode.Data + "\n");
                currentNode = currentNode.Next;
            }
        }

        public void Push(int newData)
        {
            var newNode = new Node(newData)
            {
                Next = Head
            };

            Head = newNode;
        }

        public static void InsertAfter(int newData, Node prevNode)
        {
            var newNode = new Node(newData)
            {
                Next = prevNode.Next
            };

            prevNode.Next = newNode;
        }

        public void Append(int newData)
        {
            var currentNode = Head;
            while (currentNode.Next != null) currentNode = currentNode.Next;

            currentNode.Next = new Node(newData);
        }

        public void DeleteNode(int key)
        {
            var currentNode = Head;
            Node prevNode = null;

            //If the key is in Head
            if (currentNode != null && currentNode.Data == key)
            {
                Head = currentNode.Next;
                return;
            }

            //If the key is somewhere in the linked list
            while (currentNode != null && currentNode.Data != key)
            {
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }

            //Finally if the key is not in linked list
            if (currentNode == null)
                return;

            //Link prev node and next node
            prevNode.Next = currentNode.Next;
        }

        public void DeleteNodeAtPosition(int position)
        {
            var currentNode = Head;
            var counter = position;
            Node prevNode = null;

            if (position == 0)
            {
                Head = currentNode.Next;
                return;
            }

            while (currentNode != null && counter > 0)
            {
                prevNode = currentNode;
                currentNode = currentNode.Next;
                counter--;
            }

            if (currentNode == null)
                return;

            prevNode.Next = currentNode.Next;
        }

        public void DeleteLinkedList()
        {
            //Deletes the entire list
            Head = null;
        }

        public int GetLengthOfList()
        {
            var length = GetLength(Head);
            return length;
        }

        private int GetLength(Node node) //Iterate helper Length func
        {
            if (node != null)
                return 1 + GetLength(node.Next);
            return 0;
        }

        private int LengthOfList_Iterative()
        {
            var currentNode = Head;
            var counter = 0;

            while (currentNode != null)
            {
                currentNode = currentNode.Next;
                counter++;
            }

            return counter;
        }
    }
}