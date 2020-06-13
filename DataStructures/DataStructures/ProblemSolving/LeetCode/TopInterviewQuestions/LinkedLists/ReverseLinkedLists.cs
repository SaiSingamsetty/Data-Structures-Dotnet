using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Models;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.LinkedLists
{
    public class ReverseLinkedLists
    {
        public static void Init()
        {
            var l2 = new ListNode(1);
            l2.next = new ListNode(2);
            l2.next.next = new ListNode(3);

            var res2 = Reverse(l2);
        }

        private static ListNode Reverse(ListNode head)
        {
            ListNode prevNode = null;
            var currentNode = head;

            while (currentNode != null)
            {
                var nextNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }

            return prevNode;
        }
    }
}
