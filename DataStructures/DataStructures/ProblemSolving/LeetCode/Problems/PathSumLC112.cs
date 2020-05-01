using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ProblemSolving.LeetCode.Problems.Models;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    // https://leetcode.com/problems/path-sum/
    // Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.
    // Note: A leaf is a node with no children.

    public class PathSumLc112
    {
        public static void Init()
        {
            var tree = new TreeNode(2)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(4)
                    {
                        right = new TreeNode(6)
                    },
                    right = new TreeNode(1)
                    {
                        right = new TreeNode(0),
                        left = new TreeNode(0)
                    }
                },
                right = new TreeNode(0)
                {
                    left = new TreeNode(0)
                }
            };

            Console.WriteLine(PathSumExists(tree, 2 + 3 + 4 + 6));
        }

        private static bool PathSumExists(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            if (root.left == null && root.right == null)
                return root.val == sum;

            return RecursionHelper(root, sum);
        }

        private static bool RecursionHelper(TreeNode node, int remainingSum)
        {
            // Actual Check point
            // If the node is leaf node and its value is same as remaining sum, then it is positive case.
            if (node.val == remainingSum && node.left == null && node.right == null)
            {
                return true;
            }

            //Check in the left Sub Tree from this node if this hits the check point with (remaining sum subtracted the node val)
            var leftSubTree = node.left != null && RecursionHelper(node.left, remainingSum - node.val);
            //Check in the right Sub Tree from this node if this hits the check point with (remaining sum subtracted the node val)
            var rightSubTree = node.right != null && RecursionHelper(node.right, remainingSum - node.val);

            //Any one od left or right is enough to say we have a path till leaf node which has the same sum
            return leftSubTree || rightSubTree;
        }
    }
}
