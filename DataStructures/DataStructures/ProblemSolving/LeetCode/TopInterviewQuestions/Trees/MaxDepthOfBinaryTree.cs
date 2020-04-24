using System;
using DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Trees.Models;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Trees
{
    // LEETCODE: https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/555/
    // Given a binary tree, find its maximum depth. 
    // The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node. 
    // Note: A leaf is a node with no children.
    // Given binary tree [3,9,20,null,null,15,7] [Breadth First Fill] 
    // Output - 3

    public class MaxDepthOfBinaryTree
    {
        public static void Init()
        {
            var rootNode = new TreeNode<int>(1);
            rootNode.left = new TreeNode<int>(2);
            rootNode.right = new TreeNode<int>(3);
            rootNode.right.right = new TreeNode<int>(4);
            rootNode.right.right.left = new TreeNode<int>(5);

            Console.WriteLine(FindMaxDepth(rootNode));
        }

        #region Approach 2 Optimized code of Approach 1

        private int GetMaxDepth(TreeNode<int> root)
        {
            if (root == null)
                return 0;


            return Math.Max(GetMaxDepth(root.left), GetMaxDepth(root.right)) + 1;
        }

        #endregion

        #region Approach 1

        private static int FindMaxDepth(TreeNode<int> root)
        {
            if (root == null)
                return 0;

            var maxDepth = 0;
            var res = GetMaxDepthRecursively(root, ref maxDepth);
            return res;
        }

        private static int GetMaxDepthRecursively(TreeNode<int> node, ref int maxDepth)
        {
            if (node == null)
                return 0;

            var leftDepth = GetMaxDepthRecursively(node.left, ref maxDepth);
            var rightDepth = GetMaxDepthRecursively(node.right, ref maxDepth);

            var depth = 1 + Math.Max(leftDepth, rightDepth);

            return depth;
        }

        #endregion
    }
}