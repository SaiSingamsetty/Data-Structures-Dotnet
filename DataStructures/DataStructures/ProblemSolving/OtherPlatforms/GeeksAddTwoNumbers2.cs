using System;
using DataStructures.ProblemSolving.OtherPlatforms.Models;

namespace DataStructures.ProblemSolving.OtherPlatforms
{
    // Geeks4Geeks : https://www.geeksforgeeks.org/sum-of-two-linked-lists/
    // Follow up on Leetcode 2
    // Given two numbers represented by two linked lists, write a function that returns the sum list.
    // The sum list is linked list representation of the addition of two input numbers.
    // It is not allowed to modify the lists. Also, not allowed to use explicit extra space (Hint: Use Recursion).
    // Input:
    // First List: 5->6->3  // represents number 563
    // Second List: 8->4->2 //  represents number 842
    // Output
    // Resultant list: 1->4->0->5  // represents number 1405

    public class GeeksAddTwoNumbers2
    {
        private static int _carry;
        private static ListNode _outputList;

        public static void Init()
        {
            var l1 = new ListNode(5);
            l1.next = new ListNode(6);
            l1.next.next = new ListNode(3);

            var l2 = new ListNode(8);
            l2.next = new ListNode(4);
            l2.next.next = new ListNode(2);

            var l3 = new ListNode(8);
            l3.next = new ListNode(4);

            var l4 = new ListNode(9);
            l4.next = new ListNode(7);
            l4.next.next = new ListNode(4);
            l4.next.next.next = new ListNode(6);

            var res1 = Exec(l1, l2); // 1 -> 4 -> 0 -> 5
            var res2 = Exec(l1, l3); // 6 -> 4 -> 7
            var res3 = Exec(l3, l1); // 6 -> 4 -> 7
            var res4 = Exec(l4, l3); // 9 -> 8 -> 3 -> 0
        }

        private static ListNode Exec(ListNode l1, ListNode l2)
        {
            // Re-initializing global variables
            _carry = 0;
            _outputList = null;

            // if any of the lists are empty 
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            // Check lengths of l1 and l2
            var l1Length = GetSizeOfTheList(l1);
            var l2Length = GetSizeOfTheList(l2);

            if (l2Length == l1Length)
            {
                AddListsOfSameSize(l1, l2);
            }
            else
            {
                var diff = Math.Abs(l2Length - l1Length);

                // First list should always be larger than second list.
                if (l1Length < l2Length)
                {
                    var l2Temp = l2;
                    while (diff > 0)
                    {
                        l2Temp = l2Temp.next;
                        diff--;
                    }

                    AddListsOfSameSize(l1, l2Temp);
                    PropagateCarry(l2, l2Temp);
                }
                else
                {
                    var l1Temp = l1;
                    while (diff > 0)
                    {
                        l1Temp = l1Temp.next;
                        diff--;
                    }

                    AddListsOfSameSize(l1Temp, l2);
                    PropagateCarry(l1, l1Temp);
                }
            }

            if (_carry > 0)
                PushToResultList(_carry);

            return _outputList;
        }

        private static void AddListsOfSameSize(ListNode node1, ListNode node2)
        {
            // Since this function assumes linked lists are of  
            // same size, check any of the two head pointers 
            if (node1 == null || node2 == null)
                return;

            // Recursively add remaining nodes and get the carry 
            AddListsOfSameSize(node1.next, node2.next);

            // add digits of current nodes and propagated carry 
            var sum = node1.val + node2.val + _carry;
            _carry = sum / 10;
            sum %= 10;

            PushToResultList(sum);
        }

        private static void PushToResultList(int newValue)
        {
            var newNode = new ListNode(newValue)
            {
                next = _outputList
            };
            _outputList = newNode;
        }

        private static int GetSizeOfTheList(ListNode ln)
        {
            var count = 0;
            while (ln != null)
            {
                count++;
                ln = ln.next;
            }

            return count;
        }

        private static void PropagateCarry(ListNode l1, ListNode currNode)
        {
            if (l1 != currNode)
            {
                PropagateCarry(l1.next, currNode);
                var sum = _carry + l1.val;
                _carry = sum / 10;
                sum %= 10;

                PushToResultList(sum);
            }
        }
    }
}