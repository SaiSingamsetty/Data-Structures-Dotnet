using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekTwo.Models;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekTwo
{
    public class MiddleNode
    {
        public static void Init()
        {
            var headNode = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };

            var response = GetMiddleNode(headNode);
            Console.WriteLine(response.val);
        }

        //Find length and pick the correct node - time and memory consuming
        private static ListNode GetMiddleNode(ListNode head)
        {
            // 1,2,3,4 => 3 (index : 2)
            // 1,2,3 => 2 (index : 1)
            // 1,2,3,4,5 => 3 (index : 2)
            var length = 0;
            var temp = head;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }

            var pointer = length / 2;
            temp = head;
            while (pointer > 0)
            {
                temp = temp.next;
                pointer--;
            }

            return temp;
        }


        //When traversing the list with a pointer slow, make another pointer fast that traverses twice as fast. When fast reaches the end of the list, slow must be in the middle.
        private static ListNode GetMiddleNodeUsingSlowAndFastPointers(ListNode head)
        {
            var slow = head;
            var fast = head;

            while (fast?.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }
    }
}
