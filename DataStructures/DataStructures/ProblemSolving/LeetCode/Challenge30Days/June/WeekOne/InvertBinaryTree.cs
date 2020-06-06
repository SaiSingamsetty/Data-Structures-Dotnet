using DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekOne.Models;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.June.WeekOne
{
    // Challenge 1: https://leetcode.com/explore/featured/card/june-leetcoding-challenge/539/week-1-june-1st-june-7th/3347/
    // Invert a binary tree. (Left Node <-> Right Node)

    public class InvertBinaryTree
    {
        public static void Init()
        {
            var tree1 = new TreeNode(4);
            tree1.left = new TreeNode(2);
            tree1.left.left = new TreeNode(1);
            tree1.left.right = new TreeNode(3);
            tree1.right = new TreeNode(7);
            tree1.right.left = new TreeNode(6);
            tree1.right.right = new TreeNode(9);

            var res = Invert(tree1);
        }

        private static TreeNode Invert(TreeNode root)
        {
            if (root == null)
                return null;

            if (root.left == null && root.right == null)
                return root;

            var temp = root.left;

            root.left = root.right;
            root.right = temp;

            Invert(root.left);
            Invert(root.right);

            return root;
        }
    }
}