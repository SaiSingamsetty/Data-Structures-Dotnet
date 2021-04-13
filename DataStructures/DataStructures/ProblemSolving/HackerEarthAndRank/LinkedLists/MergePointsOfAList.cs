using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.HackerEarthAndRank.Models;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.LinkedLists
{
    public static class MergePointsOfAList
    {
        public static void Execute()
        {
            var head1 = new ListNode(1);
            var secondNode = new ListNode(2);
            var thirdNode = new ListNode(3);
            //var fourthNode = new ListNode(4);
            //var fifthNode = new ListNode(5);

            head1.Next = secondNode;
            secondNode.Next = thirdNode;
            //thirdNode.Next = fourthNode;
            //fourthNode.Next = fifthNode;

            var head2 = new ListNode(6);
            head2.Next = thirdNode;

            var res1 = Find(head1, head2);
        }

        private static int Find(ListNode head1, ListNode head2)
        {
            var length1 = GetLength(head1);
            var length2 = GetLength(head2);

            while (length1 > length2)
            {
                head1 = head1.Next;
                length1--;
            }

            while (length2 > length1)
            {
                head2 = head2.Next;
                length2--;
            }

            while (head1 != null && head2 != null)
            {
                if (head1.Data == head2.Data)
                    return head1.Data;

                head1 = head1.Next;
                head2 = head2.Next;
            }

            return -1;
        }

        private static int GetLength(ListNode head)
        {
            var counter = 0;

            while (head != null)
            {
                counter++;
                head = head.Next;
            }

            return counter;
        }
    }
}
