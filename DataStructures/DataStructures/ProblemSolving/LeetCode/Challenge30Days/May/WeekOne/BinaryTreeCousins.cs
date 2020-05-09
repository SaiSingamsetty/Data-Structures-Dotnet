using DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne.Models;
using System;
using System.Collections.Generic;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekOne
{
    // https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3322/
    // In a binary tree, the root node is at depth 0, and children of each depth k node are at depth k+1. 
    // Two nodes of a binary tree are cousins if they have the same depth, but have different parents. 
    // We are given the root of a binary tree with unique values, and the values x and y of two different nodes in the tree. 
    // Return true if and only if the nodes corresponding to the values x and y are cousins.

    public class BinaryTreeCousins
    {
        public static void Init()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };
            root.left.left = new TreeNode(4);
            root.right.right = new TreeNode(5);

            var res1 = AreCousins(root, 2, 3); //false as same parent (1)
            var res2 = AreCousins(root, 4, 5); //true as same depth and different parents
            Console.WriteLine(res1 + " " + res2);
        }

        #region Using Depth and Parent Lookup tables

        private static Dictionary<int, TreeNode> _parentLookUp;
        private static Dictionary<int, int> _depthLookUp;

        private static bool AreCousins(TreeNode root, int x, int y)
        {
            _parentLookUp = new Dictionary<int, TreeNode>();
            _depthLookUp = new Dictionary<int, int>();

            PopulateLookUps(root, null);

            /* X and Y needs to have same depth and should not have same parent */
            var areCousins = _depthLookUp[x] == _depthLookUp[y]
                             &&
                             _parentLookUp[x] != _parentLookUp[y];

            return areCousins;
        }

        private static void PopulateLookUps(TreeNode node, TreeNode parent)
        {
            if (node == null)
                return;

            /* Adding current node value and the parent reference to look up */
            _parentLookUp.Add(node.val, parent);
            if (parent == null)
            {
                /* Root node has no parent (= null), Starting depth as 0 */
                _depthLookUp.Add(node.val, 0);
            }
            else
            {
                /* For each node, Get the parent's depth from lookup and add 1 */
                _depthLookUp.Add(node.val, _depthLookUp[parent.val] + 1);
            }

            PopulateLookUps(node.left, node);
            PopulateLookUps(node.right, node);
        }

        #endregion


    }
}
