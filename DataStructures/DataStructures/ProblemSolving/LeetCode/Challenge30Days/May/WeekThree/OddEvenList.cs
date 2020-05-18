using DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekThree.Models;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekThree
{
    // Challenge16: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3331/
    // Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.
    // You should try to do it in place.The program should run in O(1) space complexity and O(nodes) time complexity.
    // Input: 1->2->3->4->5->NULL
    // Output: 1->3->5->2->4->NULL
    // Input: 2->1->3->5->6->4->7->NULL
    // Output: 2->3->6->7->1->5->4->NULL
    // The relative order inside both the even and odd groups should remain as it was in the input.
    // The first node is considered odd, the second node even and so on...


    public class OddEvenList
    {
        public static void Init()
        {
            var list1 = new ListNode(1);
            list1.next = new ListNode(2);
            list1.next.next = new ListNode(3);
            list1.next.next.next = new ListNode(4);
            list1.next.next.next.next = new ListNode(5);
            list1.next.next.next.next.next = new ListNode(6);
            list1.next.next.next.next.next.next = new ListNode(7);
            list1.next.next.next.next.next.next.next = new ListNode(8);

            var res1 = GetOddEvenList(list1);
        }

        // Ref: https://www.youtube.com/watch?v=UUw3H2khRa8
        // Time Complexity: O(N) 
        // Space Complexity: O(1) Constant space for any input size

        private static ListNode GetOddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var oddPointer = head;
            var evenPointer = head.next;
            var tempOdd = oddPointer;
            var tempEven = evenPointer;

            while (tempEven != null)
            {
                if (tempEven.next != null)
                    tempOdd.next = tempEven.next;
                else
                {
                    tempOdd.next = evenPointer;
                    return oddPointer;
                }

                tempOdd = tempOdd.next;
                tempEven.next = tempOdd.next;
                tempEven = tempEven.next;
            }

            tempOdd.next = evenPointer;
            return oddPointer;
        }
    }
}