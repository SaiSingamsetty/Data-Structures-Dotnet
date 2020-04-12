using DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekTwo.Models;
using System;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.WeekTwo
{
    //Challenge11: https://leetcode.com/explore/featured/card/30-day-leetcoding-challenge/529/week-2/3293/
    //Given a binary tree, you need to compute the length of the diameter of the tree. The diameter of a binary tree is the length of the longest path between any two nodes in a tree.
    //This path may or may not pass through the root.
    //Note: The length of path between two nodes is represented by the number of edges between them.

    public class DiameterOfBinaryTree
    {
        public static void Init()
        {
            TreeNode rootNode = new TreeNode(1);
            rootNode.left = new TreeNode(2);
            rootNode.right  = new TreeNode(3);
            rootNode.left.left = new TreeNode(4);
            rootNode.left.right = new TreeNode(5);
            var response = GetDiameter(rootNode);
        }

        private static int GetDiameter(TreeNode root)
        {
            var response = Diameter(root);
            return response;
        }

        private static int DiameterOpt(TreeNode root, Height height)
        {
            /* lh --> Height of left subtree 
               rh --> Height of right subtree */
            Height lh = new Height(), rh = new Height();

            if (root == null)
            {
                height.h = 0;
                return 0; /* diameter is also 0 */
            }

            /* ldiameter  --> diameter of left subtree 
               rdiameter  --> Diameter of right subtree */
            /* Get the heights of left and right subtrees in lh and rh 
             And store the returned values in ldiameter and ldiameter */
            int ldiameter = DiameterOpt(root.left, lh);
            int rdiameter = DiameterOpt(root.right, rh);

            /* Height of current node is max of heights of left and 
             right subtrees plus 1*/
            height.h = Math.Max(lh.h, rh.h) + 1;

            return Math.Max(lh.h + rh.h + 1, Math.Max(ldiameter, rdiameter));
        }

        static int Diameter(TreeNode root)
        {
            Height height = new Height();
            return DiameterOpt(root, height);
        }

        static int Height(TreeNode node)
        {
            /* base case tree is empty */
            if (node == null)
                return 0;

            /* If tree is not empty then height = 1 + max of left 
               height and right heights */
            return (1 + Math.Max(Height(node.left), Height(node.right)));
        }
    }

    public class Height
    {
        public int h;
    }
}
