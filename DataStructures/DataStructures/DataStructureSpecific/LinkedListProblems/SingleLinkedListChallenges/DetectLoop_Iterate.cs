using System.Collections.Generic;
using DataStructures.DataStructureSpecific.LinkedListProblems.Models;

namespace DataStructures.DataStructureSpecific.LinkedListProblems.SingleLinkedListChallenges
{
    public static class DetectLoopIterate
    {
        public static void Init()
        {
            var secondList = new LinkedList();
            //secondList.Push(4);
            //secondList.Push(20);
            secondList.Push(4);
            secondList.Push(20);
            secondList.Push(15);
            secondList.Push(10);
            secondList.Head.Next.Next.Next.Next = secondList.Head.Next;

            var res = DetectLoop(secondList.Head);
        }

        private static bool DetectLoop(Node head)
        {
            var h = head;
            var s = new HashSet<Node>();
            while (h != null)
            {
                if (s.Contains(h))
                    return true;

                s.Add(h);

                h = h.Next;
            }

            return false;
        }
    }
}