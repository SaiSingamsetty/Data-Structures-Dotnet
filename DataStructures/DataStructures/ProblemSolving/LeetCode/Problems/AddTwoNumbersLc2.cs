using DataStructures.ProblemSolving.LeetCode.Problems.Models;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    // Leetcode: https://leetcode.com/problems/add-two-numbers/
    // You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
    // You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    // Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
    // Output: 7 -> 0 -> 8
    // Explanation: 342 + 465 = 807.
 
    public class AddTwoNumbersLc2
    {   
        public static void Init()
        {
            var l1 = new ListNode(2);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(3);

            var l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);

            var res1 = Find(l1, l2);
        }

        private static ListNode Find(ListNode l1, ListNode l2)
        {
            var tempL1 = l1;
            var tempL2 = l2;
            var dummyHead = new ListNode(0);
            var outputNode = dummyHead;
            var carry = 0;

            while (tempL2 != null || tempL1 != null)
            {
                var val = (tempL1?.val ?? 0) + (tempL2?.val ?? 0) + carry;
                carry = val / 10;

                outputNode.next = new ListNode(val % 10);
                outputNode = outputNode.next;


                tempL1 = tempL1?.next;
                tempL2 = tempL2?.next;
            }

            if (carry > 0)
                outputNode.next = new ListNode(carry);

            return dummyHead.next;
        }
    }
}