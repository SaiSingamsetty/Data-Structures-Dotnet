using System;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekFive.Models;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekFive
{
    // Challenge29: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/532/week-5/3314/
    // Given a non-empty binary tree, find the maximum path sum.
    // For this problem, a path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections.
    // The path must contain at least one node and does not need to go through the root.

    //Ref: https://gist.github.com/chetanbommu/02cfa1e686d2e7c1ba14fa9383aa3f0c

    public class MaxPathSum
    {
        //Max Sum of the tree
        private static int _maxSum;

        public static void Init()
        {
            var tree1 = new TreeNode(-2)
            {
                left = new TreeNode(3),
                right = new TreeNode(5)
                {
                    right = new TreeNode(4),
                    left = new TreeNode(2)
                }
            };

            var tree2 = new TreeNode(2);
            tree2.left = new TreeNode(-1);
            Console.WriteLine(FindMaxPathSum(tree2));
        }

        private static int FindMaxPathSum(TreeNode root)
        {
            _maxSum = int.MinValue;
            FindMaxPathSumHelper(root);
            return _maxSum;
        }

        private static int FindMaxPathSumHelper(TreeNode node)
        {
            if (node == null)
                return 0;

            //To just discard -ve values, take Max
            //[2, -1] -> Output should be 2 not 1
            var leftPathMaxSum = Math.Max(0, FindMaxPathSumHelper(node.left));
            var rightPathMaxSum = Math.Max(0, FindMaxPathSumHelper(node.right));

            _maxSum = Math.Max(_maxSum, leftPathMaxSum + rightPathMaxSum + node.val);

            //Max Sum of the Path (Branch in the tree)
            var maxPathSum = Math.Max(leftPathMaxSum, rightPathMaxSum) + node.val;
            return maxPathSum;
        }
    }
}