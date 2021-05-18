using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.HackerEarthAndRank.Models;

namespace DataStructures.ProblemSolving.HackerEarthAndRank.Trees
{
    public static class HeightOfBinaryTree
    {
        public static void Execute()
        {
            var head = new TreeNode(1);
            head.Left = new TreeNode(2);
            head.Right = new TreeNode(3);
            head.Left.Left = new TreeNode(4);
            head.Left.Right = new TreeNode(5);

            var res = Find(head);
        }

        private static int Find(TreeNode node)
        {
            var res = Recur(node);
            return res;
        }

        private static int Recur(TreeNode node)
        {
            if (node == null)
                return 0;

            var lDepth = Recur(node.Left);
            var rDepth = Recur(node.Right);
            return 1 + (lDepth > rDepth ? lDepth : rDepth);
        }

    }
}
