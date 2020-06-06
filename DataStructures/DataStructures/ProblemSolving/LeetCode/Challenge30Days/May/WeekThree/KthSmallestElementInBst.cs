using System.Collections.Generic;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekThree.Models;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekThree
{
    // Challenge 20: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3335/
    // Given a binary search tree, write a function kthSmallest to find the kth smallest element in it. 
    // Note:
    // You may assume k is always valid, 1 ≤ k ≤ BST's total elements.
    // Input: root = [3,1,4,null,2], k = 1
    // Output: 1
    // Input: root = [5,3,6,2,4,null,null,1], k = 3
    // Output: 3

    // Follow up:
    // What if the BST is modified (insert/delete operations) often and you need to find the kth smallest frequently?
    // How would you optimize the kthSmallest routine?


    public class KthSmallestElementInBst
    {
        public static void Init()
        {
            var tree1 = new TreeNode(3);
            tree1.left = new TreeNode(1);
            tree1.left.right = new TreeNode(2);
            tree1.right = new TreeNode(4);
            var res1 = FindUsingApproach1(tree1, 2);

            var tree2 = new TreeNode(5);
            tree2.left = new TreeNode(3);
            tree2.left.left = new TreeNode(2);
            tree2.left.left.left = new TreeNode(1);
            tree2.left.right = new TreeNode(4);
            tree2.right = new TreeNode(6);
            var res2 = FindUsingApproach4(tree2, 5);
        }

        #region Approach 2: Find by using In-Order Implementation (NOT YET COMPLETED)

        private static int FindUsingApproach2(TreeNode root, int k)
        {
            if (root == null)
                return 0;

            var left = FindUsingApproach2(root.left, k);
            if (left > 0)
                return left;

            k--;
            if (k == 0)
                return root.val;

            var right = FindUsingApproach2(root.right, k);
            return right;
        }

        #endregion

        #region Approach 4: Using Stack of Tree Nodes

        // Time complexity : O(H + k), where H is a tree height.
        // This complexity is defined by the stack, which contains at least H + k elements,
        // since before starting to pop out one has to go down to a leaf.
        // This results in O(logN+k) for the balanced tree and O(N+k) for completely unbalanced tree with all the nodes in the left subtree.
        // Space complexity : O(H+k), the same as for time complexity,
        // O(N+k) in the worst case, and O(logN+k) in the average case.

        // Follow Up Challenge: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/536/week-3-may-15th-may-21st/3335/

        private static int FindUsingApproach4(TreeNode root, int k)
        {
            var stack = new Stack<TreeNode>();
            while (true)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (--k == 0) return root.val;
                root = root.right;
            }
        }

        #endregion

        #region Approach 1: Find In-Order Array and  return the Kth element TC: O(N), SC: O(N)

        private static List<int> _list;

        private static int FindUsingApproach1(TreeNode root, int k)
        {
            if (root.left == null && root.right == null && k == 1)
                return root.val;

            _list = new List<int>();
            RecursiveHelperForApproach1(root);
            return _list[k - 1];
        }

        private static void RecursiveHelperForApproach1(TreeNode node)
        {
            if (node.left != null) RecursiveHelperForApproach1(node.left);

            _list.Add(node.val);

            if (node.right != null) RecursiveHelperForApproach1(node.right);
        }

        #endregion

        #region Approach 3: Optimized Approach1 : Return if found while doing traversing

        private static int _number;
        private static int _count;

        private static int FindUsingApproach3(TreeNode root, int k)
        {
            if (root.left == null && root.right == null && k == 1)
                return root.val;

            _count = k;
            RecursiveHelperForApproach3(root);
            return _number;
        }

        private static void RecursiveHelperForApproach3(TreeNode node)
        {
            if (node.left != null) RecursiveHelperForApproach3(node.left);
            _count--;
            if (_count == 0)
            {
                _number = node.val;
                return;
            }

            if (node.right != null) RecursiveHelperForApproach3(node.right);
        }

        #endregion
    }
}