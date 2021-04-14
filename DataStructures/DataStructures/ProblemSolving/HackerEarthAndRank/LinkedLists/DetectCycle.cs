using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.HackerEarthAndRank.Models;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.LinkedLists
{
    public static class DetectCycle
    {
        public static void Execute()
        {
            var head1 = new ListNode(1);
            var secondNode = new ListNode(2);
            var thirdNode = new ListNode(3);
            var fourthNode = new ListNode(4);
            var fifthNode = new ListNode(5);

            head1.Next = secondNode;
            secondNode.Next = thirdNode;
            thirdNode.Next = fourthNode;
            fourthNode.Next = fifthNode;
            //fifthNode.Next = thirdNode;

            var res = Detect(head1);
        }
        /*
         * Approach 1: Using extra flag in ListNode
         *      While traversing set that flag.
         *      If there is a cycle pointer should come across that flag which is set
         *
         * Approach 2: Using HashSet (Solved below)
         *
         */
        private static bool Detect(ListNode head)
        {
            HashSet<ListNode> set = new HashSet<ListNode>();
            
            while (head != null)
            {
                if (set.Contains(head))
                    return true;

                set.Add(head);
                head = head.Next;
            }

            return false;
        }
    }
}
