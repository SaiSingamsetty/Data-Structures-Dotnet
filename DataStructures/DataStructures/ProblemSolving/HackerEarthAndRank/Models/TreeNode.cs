using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Models
{
    public class TreeNode
    {
        private int Data;
        public TreeNode Left, Right;

        public TreeNode(int item)
        {
            Data = item;
            Left = Right = null;
        }
    }
}
