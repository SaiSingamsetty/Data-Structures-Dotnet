using DataStructures.DataStructureSpecific.LinkedListProblems.Models;

namespace DataStructures.DataStructureSpecific.LinkedListProblems.SingleLinkedListChallenges
{
    public static class LengthOfLoopFloydAlgo
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

            var res = FindLengthOfLoop(secondList.Head);
        }

        private static int FindLengthOfLoop(Node headNode)
        {
            var slowPointer = headNode;
            var fastPointer = headNode;

            while (slowPointer != null && fastPointer?.Next != null)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next.Next;
                var length = 1;

                if (slowPointer == fastPointer)
                {
                    var commonPointer = slowPointer;
                    var temp = commonPointer;
                    while (temp != null && temp.Next != commonPointer)
                    {
                        length++;
                        temp = temp.Next;
                    }

                    return length;
                }
            }

            return 0;
        }
    }
}