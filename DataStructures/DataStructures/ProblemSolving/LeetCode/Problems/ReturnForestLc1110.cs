using System.Collections.Generic;
using System.Linq;
using DataStructures.ProblemSolving.LeetCode.Problems.Models;

namespace DataStructures.ProblemSolving.LeetCode.Problems
{
    // LC1110: https://leetcode.com/problems/delete-nodes-and-return-forest
    // Given the root of a binary tree, each node in the tree has a distinct value.
    // After deleting all nodes with a value in to_delete, we are left with a forest (a disjoint union of trees).
    // Return the roots of the trees in the remaining forest.  You may return the result in any order.
    // Input: root = [1,2,3,4,5,6,7], to_delete = [3,5]
    // Output: [[1,2,null,4],[6],[7]]

    public class ReturnForestLc1110
    {
        public static void Init()
        {
            var tree = new TreeNode(1);
            tree.left = new TreeNode(2);
            tree.left.left = new TreeNode(4);
            tree.left.right = new TreeNode(5);
            tree.right = new TreeNode(3);
            tree.right.left = new TreeNode(6);
            tree.right.right = new TreeNode(7);

            var res = ReturnForest(tree, new[] {3, 5});
        }

        #region Approach 1 Recursion (Multiple Visits to a node)

        private static IList<TreeNode> ReturnForestUsingRecursion(TreeNode root, int[] to_delete)
        {
            var listOfTrees = new List<TreeNode>();

            var finalNode = RecursionHelper(root, to_delete, listOfTrees);
            if (finalNode != null)
                listOfTrees.Add(root);
            return listOfTrees;
        }

        private static TreeNode RecursionHelper(TreeNode node, int[] toDelete, IList<TreeNode> forest)
        {
            if (node.left != null)
                node.left = RecursionHelper(node.left, toDelete, forest);

            if (node.right != null)
                node.right = RecursionHelper(node.right, toDelete, forest);

            if (toDelete.Contains(node.val))
            {
                var counter = 0; //to see if both the sub trees of a node are nulls, If both are nulls and the node
                // value is in array, we can just make this node as null

                if (node.left != null)
                {
                    forest.Add(node.left);
                    counter++;
                    node.left = null;
                }

                if (node.right != null)
                {
                    forest.Add(node.right);
                    counter++;
                    node.right = null;
                }

                if (counter == 2) return null;

                return null;
            }

            return node;
        }

        #endregion

        #region Approach 2

        private static HashSet<int> _lookUp;
        private static List<TreeNode> _listOfTrees;

        private static List<TreeNode> ReturnForest(TreeNode root, int[] to_delete)
        {
            _lookUp = new HashSet<int>();
            _listOfTrees = new List<TreeNode>();

            foreach (var i in to_delete) _lookUp.Add(i);

            Helper(root, true);
            return _listOfTrees;
        }

        private static TreeNode Helper(TreeNode node, bool isRoot)
        {
            if (node == null) return null;
            var deleted = _lookUp.Contains(node.val);
            if (isRoot && !deleted) _listOfTrees.Add(node);
            node.left = Helper(node.left, deleted);
            node.right = Helper(node.right, deleted);
            return deleted ? null : node;
        }

        #endregion
    }
}