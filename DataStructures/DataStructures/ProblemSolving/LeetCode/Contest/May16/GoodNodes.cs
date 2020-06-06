using System;
using DataStructures.ProblemSolving.LeetCode.Contest.May16.Models;

namespace DataStructures.ProblemSolving.LeetCode.Contest.May16
{
    // LEETCODE 1448: https://leetcode.com/problems/count-good-nodes-in-binary-tree/
    // Given a binary tree root, a node X in the tree is named good if in the path from root to X there are no nodes with a value greater than X.
    // Return the number of good nodes in the binary tree.
    // Input: root = [3,1,4,3,null,1,5]
    // Output: 4
    // Explanation: Nodes in blue are good.
    // Root Node(3) is always a good node.
    // Node 4 -> (3,4) is the maximum value in the path starting from the root.
    // Node 5 -> (3,4,5) is the maximum value in the path
    // Node 3 -> (3,1,3) is the maximum value in the path.
    // Input: root = [3,3,null,4,2]
    // Output: 3
    // Explanation: Node 2 -> (3, 3, 2) is not good, because "3" is higher than it.
    // Input: root = [1]
    // Output: 1
    // Explanation: Root is considered as good.

    public class GoodNodes
    {
        private static int Counter;

        public static void Init()
        {
            var root1 = new TreeNode(3);
            root1.left = new TreeNode(4);
            root1.left.left = new TreeNode(1);

            root1.left.left.left = new TreeNode(3);
            root1.left.left.right = new TreeNode(2);

            root1.right = new TreeNode(5);
            root1.right.left = new TreeNode(1);
            root1.right.right = new TreeNode(6);

            var res1 = FindNoOfGoodNodes(root1);
        }

        private static int FindNoOfGoodNodes(TreeNode root)
        {
            if (root == null)
                return 0;
            if (root.left == null && root.right == null)
                return 1;

            Counter = 0;
            RecursionHelper(root, root.val);
            return Counter;
        }


        private static void RecursionHelper(TreeNode node, int max)
        {
            if (node == null)
                return;

            var tempMax = Math.Max(node.val, max);
            if (tempMax == node.val)
                Counter++;

            if (node.left != null) RecursionHelper(node.left, tempMax);

            if (node.right != null) RecursionHelper(node.right, tempMax);
        }
    }
}