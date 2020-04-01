using DataStructures.LinkedListProblems.Models;

namespace DataStructures.LinkedListProblems.SingleLinkedListChallenges
{
    public static class FetchNthNodeValueIterate
    {
        public static void Init()
        {
            var mylist = new LinkedList
            {
                Head = new Node(2)
            };
            mylist.Head.Next = new Node(3);

            var res = GetNthNodeData_Iterate(2, mylist.Head);
        }

        private static int GetNthNodeData_Iterate(int index, Node head)
        {
            var currentNode = head;
            var counter = 0;

            if (index < 0)
                return -1;

            while (currentNode != null && counter != index)
            {
                currentNode = currentNode.Next;
                counter++;
            }

            if (currentNode != null)
                return currentNode.Data;

            return -1;
        }
    }
}