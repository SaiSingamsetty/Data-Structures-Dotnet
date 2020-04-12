using DataStructures.DataStructureSpecific.LinkedListProblems.Models;

namespace DataStructures.DataStructureSpecific.LinkedListProblems.SingleLinkedListChallenges
{
    public static class SwapNodes
    {
        public static void Init()
        {
            var myList = new LinkedList();
            myList.Push(4);
            myList.Push(20);
            myList.Push(15);
            myList.Push(10);

            var result = Swap(1, 3, myList.Head);
        }

        private static Node Swap(int x, int y, Node headNode)
        {
            if (x == y)
                return headNode;

            Node prevX = null, currX = headNode;
            while (currX != null && currX.Data != x)
            {
                prevX = currX;
                currX = currX.Next;
            }

            Node prevY = null, currY = headNode;
            while (currY != null && currY.Data != y)
            {
                prevY = currY;
                currY = currY.Next;
            }

            // If either x or y is not present, nothing to do  
            if (currX == null || currY == null)
                return headNode;


            var temp = currY.Next;
            currY.Next = currX.Next;
            currX.Next = temp;

            if (prevX == null && prevY != null)
            {
                headNode = currY;
                prevY.Next = currX;
            }

            if (prevY == null && prevX != null)
            {
                headNode = currX;
                prevX.Next = currY;
            }

            if (prevX != null && prevY != null)
            {
                prevX.Next = currY;
                prevY.Next = currX;
            }

            return headNode;
        }
    }
}