using DataStructures.LinkedListProblems.Models;

namespace DataStructures.LinkedListProblems.SingleLinkedListChallenges
{
    public static class SearchingListRecursive
    {
        public static void Init()
        {
            var mylist = new LinkedList
            {
                Head = new Node(2)
            };
            mylist.Head.Next = new Node(3);

            var res = SearchLinkedList_Recursive(3, mylist.Head);
        }

        private static bool SearchLinkedList_Recursive(int searchValue, Node head)
        {
            var current = head;
            return SearchHelperIterative(current, searchValue);
        }

        private static bool SearchHelperIterative(Node node, int searchValue) //Iterate helper Search func
        {
            if (node == null)
                return false;

            if (node.Data == searchValue)
                return true;

            return SearchHelperIterative(node.Next, searchValue);
        }
    }
}