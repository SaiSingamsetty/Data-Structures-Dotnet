using System;
using DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Trees.Models;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Trees
{
    public class ValidateBinarySearchTree
    {
        public static void Init()
        {
            var rootNode = new TreeNode<int>(2);
            rootNode.left = new TreeNode<int>(1);
            rootNode.right = new TreeNode<int>(3);
            //rootNode.left.left = new TreeNode<int>(4);

            Console.WriteLine(ValidateBinarySearchTreeInOrderRule(rootNode));
        }

        #region Approach 1: Inorder Traversal

        private static bool ValidateBinarySearchTreeInOrderRule(TreeNode<int> root)
        {
            if (root == null)
                return true;

            //In-order for BST is always increased order.
            var maxSoFar = int.MinValue;
            var endFlag = false;

            InOrderTraversal(root, ref maxSoFar, ref endFlag);

            if (maxSoFar == int.MinValue)
                return false;

            return true;
        }

        private static void InOrderTraversal(TreeNode<int> node, ref int maxSoFar, ref bool endFlag)
        {
            if (node.left != null)
                InOrderTraversal(node.left, ref maxSoFar, ref endFlag);

            if (endFlag)
                return;

            if (node.val > maxSoFar)
                maxSoFar = node.val;
            else
            {
                maxSoFar = int.MinValue;
                endFlag = true;
            }

            if (node.right != null)
                InOrderTraversal(node.right, ref maxSoFar, ref endFlag);
        }

        #endregion
    }
}