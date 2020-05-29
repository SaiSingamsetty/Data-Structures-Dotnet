using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.ProblemSolving.LeetCode.Challenge30Days.April.WeekThree.Models;

namespace DataStructures.ProblemSolving.LeetCode.Challenge30Days.May.WeekFour
{
    // Challenge24: https://leetcode.com/explore/featured/card/may-leetcoding-challenge/537/week-4-may-22nd-may-28th/3339/
    // Return the root node of a binary search tree that matches the given pre-order traversal.
    // Input: [8,5,1,7,10,12]
    // Output: [8,5,10,1,7,null,12] BreadthFirstSearch Output

    public class ConstructBstPreOrderTraversal
    {
        public static void Init()
        {
            var arr = new[] {10, 5, 1, 7, 40, 50};
            var tree = ConstructTree(arr);
            Console.WriteLine(tree.val);
        }


        #region Approach 3 Using Stack O(N)

        //Reference: GeeksForGeeks
        private static TreeNode ConstructTree(int[] pre)
        {
            var size = pre.Length;
            // The first element of pre[] is always root 
            var root = new TreeNode(pre[0]);
            var s = new Stack<TreeNode>();
            // Push root 
            s.Push(root);

            for (var i = 1; i < size; ++i)
            {
                TreeNode temp = null;
                /* Keep on popping while the next value is greater than 
                 stack's top value. */
                while (s.Count > 0 && pre[i] > s.Peek().val)
                {
                    temp = s.Pop();
                }

                // Make this greater value as the right child
                // and push it to the stack 
                if (temp != null)
                {
                    temp.right = new TreeNode(pre[i]);
                    s.Push(temp.right);
                }
                // If the next value is less than the stack's top
                // value, make this value as the left child of the 
                // stack's top node. Push the new node to stack 
                else
                {
                    temp = s.Peek();
                    temp.left = new TreeNode(pre[i]);
                    s.Push(temp.left);
                }
            }

            return root;
        }

        #endregion

        #region Approach 1 (Recursive - Time taking) O(N2)

        private static TreeNode ConstructBst(int[] preOrder)
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

        #endregion

        #region Approach 2 (Less Recursive O(3N))

        //Reference: https://www.youtube.com/watch?v=9sw8RRsBw6s

        private static TreeNode ConstructBst_O_N(int[] preOrder)
        {
            var length = preOrder.Length;
            if (length == 0)
                return null;
            var root = new TreeNode(preOrder[0]);
            if (length == 1)
                return root;
            ConstructBst_O_N_RecursionHelper(preOrder, length, 1, root, int.MinValue, int.MaxValue);
            return root;
        }

        private static int ConstructBst_O_N_RecursionHelper(int[] preOrder, int length, int position,
            TreeNode currentNode,
            int min, int max)
        {
            //Boundary Conditions
            if (position == length || preOrder[position] < min || preOrder[position] > max)
                return position;
            if (preOrder[position] < currentNode.val)
            {
                currentNode.left = new TreeNode(preOrder[position]);
                position++;
                position = ConstructBst_O_N_RecursionHelper(preOrder, length, position, currentNode.left, min,
                    currentNode.val - 1);
            }

            //Boundary Conditions
            if (position == length || preOrder[position] < min || preOrder[position] > max)
                return position;
            if (preOrder[position] > currentNode.val)
            {
                currentNode.right = new TreeNode(preOrder[position]);
                position++;
                position = ConstructBst_O_N_RecursionHelper(preOrder, length, position, currentNode.right,
                    currentNode.val + 1, max);
            }

            return position;
        }

        #endregion
    }
}