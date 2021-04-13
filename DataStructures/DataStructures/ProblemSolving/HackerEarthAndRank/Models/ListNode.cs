using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Models
{
    public class ListNode
    {
        public int Data { get; set; }

        public ListNode Next { get; set; }

        public ListNode(int data = 0)
        {
            Data = data;
        }
    }

    public class DoubleListNode
    {
        public int Data { get; set; }

        public DoubleListNode Next { get; set; }
        
        public DoubleListNode Prev { get; set; } 

        public DoubleListNode(int data = 0)
        {
            Data = data;
        }
    }
}
