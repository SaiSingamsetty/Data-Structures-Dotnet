using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Trees.Models;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Trees
{
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/625/
    // Validate given BST Tree node

    public class ValidateBinarySearchTree
    {
        public static void Init()
        {
            var rootNode = new TreeNode<int>(4);
            rootNode.left = new TreeNode<int>(2);
            //rootNode.left.left = new TreeNode<int>(1);
            rootNode.right = new TreeNode<int>(6);

            Console.WriteLine(ValidateBinarySearchTreeInOrderRule(rootNode));
        }

        #region Approach 1: Inorder Traversal Combined with Stacks (Not so clear)

        //Type1
        private static bool ValidateBinarySearchTreeInOrderRule(TreeNode<int> root)
        {
            var prev = new Stack<int>();
            return Inorder(root, prev);
        }

        private static bool Inorder(TreeNode<int> node, Stack<int> prev)
        {
            if (node == null) return true;
            if (!Inorder(node.left, prev)) return false;
            if (prev.Count() != 0 && prev.Pop() >= node.val) return false;
            prev.Push(node.val);
            return Inorder(node.right, prev);
        }

        //Type2
        private static bool IsValidBstUsingStack(TreeNode<int> root)
        {
            if (root == null) return true;
            var stack = new Stack<TreeNode<int>>();
            TreeNode<int> pre = null;
            while (root != null || stack.Count() != 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (pre != null && root.val <= pre.val) return false;
                pre = root;
                root = root.right;
            }

            return true;
        }

        #endregion

        #region Approach 2: Min and Max ***

        //Every node has min and max ranges to be a binary search tree.
        //Every left node has to be less than current node value
        //Every right node has to be greater than current node value

        private static bool IsBstMinMaxApproach(TreeNode<int> root)
        {
            if (root == null || (root.left == null && root.right == null))
                return true;

            return MinMaxHelper(root, long.MinValue, long.MaxValue);
        }

        private static bool MinMaxHelper(TreeNode<int> node, long min, long max)
        {
            if (node == null)
                return true;
            if (node.val <= min || node.val >= max)
                return false;
            var leftTree = MinMaxHelper(node.left, min, node.val);
            var rightTree = MinMaxHelper(node.right, node.val, max);
            return leftTree && rightTree;
        }

        #endregion
    }
}