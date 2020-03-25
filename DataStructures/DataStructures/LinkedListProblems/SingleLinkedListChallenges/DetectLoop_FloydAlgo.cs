using DataStructures.LinkedListProblems.Models;

namespace DataStructures.LinkedListProblems.SingleLinkedListChallenges
{
    public static class DetectLoopFloydAlgo
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
            var slowPointer = head;
            var fastPointer = head;

            while (slowPointer != null && fastPointer?.Next != null)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next.Next;

                if (slowPointer == fastPointer)
                    return true;

            }
            return false;
        }
    }
}
