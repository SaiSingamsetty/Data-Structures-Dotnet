using DataStructures.LinkedListProblems.Models;

namespace DataStructures.LinkedListProblems.SingleLinkedListChallenges
{
    public static class SearchingListIterate
    {
        public static void Init()
        {
            var mylist = new LinkedList
            {
                Head = new Node(2)
            };
            mylist.Head.Next = new Node(3);

            var res = SearchLinkedList_Iterate(mylist.Head, 3);

            mylist.PrintLinkedList();
        }

        private static bool SearchLinkedList_Iterate(Node head, int searchValue)
        {
            var current = head;
            while (current != null)
            {
                if (current.Data == searchValue)
                    return true;

                current = current.Next;
            }

            return false;
        }
    }
}