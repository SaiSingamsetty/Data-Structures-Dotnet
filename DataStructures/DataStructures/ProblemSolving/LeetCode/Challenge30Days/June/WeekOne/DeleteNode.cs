using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekOne.Models;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekOne
{
    // Challenge 2: https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3348/
    // Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.
    // Given linked list -- head = [4,5,1,9], which looks like following:
    // Input: head = [4,5,1,9], node = 5
    // Output: [4,1,9]
    // Explanation: You are given the second node with value 5, the linked list should become 4 -> 1 -> 9 after calling your function.

    public class DeleteNode
    {
        public static void Init()
        {
            var list = new ListNode(4);
            list.next = new ListNode(5);
            list.next.next = new ListNode(1);
            list.next.next.next = new ListNode(9);

            Delete(list.next); // The node passed is '5' and that has to be deleted from list.
                               // No head or prev nodes info will be sent
        }

        private static void Delete(ListNode node)
        {
            var nextNode = node.next;

            // Copy the next node value to the current node
            node.val = node.next.val;

            // Copy the next node's next sequence to current node's next
            node.next = node.next.next;

            // Nullify the next node now, Just detaching from list
            nextNode.next = null;

        }
    }
}
