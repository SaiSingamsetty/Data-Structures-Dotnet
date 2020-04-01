using DataStructures.LinkedListProblems.Models;

namespace DataStructures.LinkedListProblems.SingleLinkedListChallenges
{
    public static class FetchNthNodeValueRecursive
    {
        public static void Init()
        {
            var mylist = new LinkedList
            {
                Head = new Node(2)
            };
            mylist.Head.Next = new Node(3);

            var res = GetNthNodeData_Recursive(2, mylist.Head);
        }

        private static int GetNthNodeData_Recursive(int index, Node head)
        {
            var res = GetNthNode_Helper(head, index);
            return res;
        }

        private static int GetNthNode_Helper(Node node, int index)
        {
            if (node == null)
                return -1;

            if (index == 0)
                return node.Data;

            return GetNthNode_Helper(node.Next, index - 1);
        }
    }
}