using DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekThree.Models;
using System;
using System.Linq;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekThree
{
    // Challenge20: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/530/week-3/3305/
    // Return the root node of a binary search tree that matches the given pre-order traversal.
    // Input: [8,5,1,7,10,12]
    // Output: [8,5,10,1,7,null,12] BreadthFirstSearch Output

    public class ConstructBstFromPreOrderTraversal
    {
        public static void Init()
        {
            var arr = new int[] { 8, 5, 1, 7, 10, 12 };
            var tree = Construct(arr);

            Console.WriteLine(tree.val);
        }

        private static TreeNode Construct(int[] preOrder)
        {
            var tree = new TreeNode(preOrder[0]);
            foreach (var i in preOrder.Skip(1))
            {
                AddNodeToBinarySearchTree(tree, i);
            }

            return tree;
        }

        private static void AddNodeToBinarySearchTree(TreeNode node, int value)
        {
            var nodeValue = node.val;
            if (value <= nodeValue)
            {
                if (node.left != null)
                {
                    AddNodeToBinarySearchTree(node.left, value);
                }
                else
                {
                    node.left = new TreeNode(value);
                }
            }
            else
            {
                if (node.right != null)
                {
                    AddNodeToBinarySearchTree(node.right, value);
                }
                else
                {
                    node.right = new TreeNode(value);
                }
            }

        }

    }
}
