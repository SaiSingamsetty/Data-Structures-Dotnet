using System;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekFive.Models;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekFive
{
    // Challenge30: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/532/week-5/3315/
    // Given a binary tree where each path going from the root to any leaf form a valid sequence, check if a given string is a valid sequence in such binary tree. 
    // We get the given string from the concatenation of an array of integers arr and the concatenation of all values of the nodes along a path results in a sequence in the given binary tree.
    // Input: root = [0,1,0,0,1,0,null,null,1,0,0], arr = [0,1,0,1]
    // Output: true
    // Explanation: 
    // The path 0 -> 1 -> 0 -> 1 is a valid sequence 

    public class ValidSeqFromRootToLeaf
    {
        public static void Init()
        {
            var tree = new TreeNode(0)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(0)
                    {
                        right = new TreeNode(1)
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
            Console.WriteLine(IsValidSeq(tree, new[] {0, 1, 1}));
        }

        //Ref: https://gist.github.com/chetanbommu/6b1c57710f76074441339bf42fc46772

        private static bool IsValidSeq(TreeNode root, int[] arr)
        {
            if (root == null || arr.Length == 0)
                return false;

            return RecursionHelper(root, arr, 0);
        }

        private static bool RecursionHelper(TreeNode node, int[] arr, int pos)
        {
            if (node.val == arr[pos])
            {
                //Check if this is the last element in array && leaf node 
                if (pos == arr.Length - 1 && node.left == null && node.right == null)
                    return true;

                if (pos < arr.Length - 1)
                {
                    //If not the last element, continue checking in left sub tree & right sub tree
                    //any one of them has to be true
                    var left = node.left != null && RecursionHelper(node.left, arr, pos + 1);
                    var right = node.right != null && RecursionHelper(node.right, arr, pos + 1);
                    return left || right;
                }
            }

            return false;
        }
    }
}