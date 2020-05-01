using System;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekTwo.Models;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekTwo
{
    //Challenge11 https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/529/week-2/3293/
    //Given a binary tree, you need to compute the length of the diameter of the tree.
    //The diameter of a binary tree is the length of the longest path between any two nodes in a tree.
    //This path may or may not pass through the root.

    public class DiameterOfBinaryTree
    {
        public static void Init()
        {
            var rootNode = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };
            rootNode.left.left = new TreeNode(4);
            rootNode.left.right = new TreeNode(5);

            var response = FindDiameterOfBinaryTree(rootNode);
            Console.WriteLine(response);
        }

        #region Approach 1

        private static int FindDiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;

            var maxDiameter = 0; // We can also use global/static variable
            FindMaxDepth(root, ref maxDiameter);
            return maxDiameter;
        }

        private static int FindMaxDepth(TreeNode node, ref int maxDiameter)
        {
            if (node == null)
                return 0;

            var leftTreeDepth = FindMaxDepth(node.left, ref maxDiameter);
            var rightTreeDepth = FindMaxDepth(node.right, ref maxDiameter);

            maxDiameter = Math.Max(maxDiameter, leftTreeDepth + rightTreeDepth);

            return 1 + Math.Max(leftTreeDepth, rightTreeDepth);
        }

        #endregion
    }
}