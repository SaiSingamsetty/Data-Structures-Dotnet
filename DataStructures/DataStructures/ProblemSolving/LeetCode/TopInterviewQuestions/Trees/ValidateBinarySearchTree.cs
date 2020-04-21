using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;
using DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Trees.Models;

namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Trees
{
    public class ValidateBinarySearchTree
    {
        public static void Init()
        {
            var rootNode = new TreeNode<int>(2);
            rootNode.left = new TreeNode<int>(1);
            rootNode.right = new TreeNode<int>(3);
            rootNode.left.left = new TreeNode<int>(4);

            Console.WriteLine(ValidateBinarySearchTreeRecursively(rootNode));
        }

        private static bool ValidateBinarySearchTreeRecursively(TreeNode<int> root)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    if (root.val <= root.left.val)
                        return false;
                }

                if (root.right != null)
                {
                    if (root.val >= root.right.val)
                        return false;
                }

                var leftSubTree =  ValidateBinarySearchTreeRecursively(root.left);
                if (!leftSubTree)
                    return false;

                var rightSubTree = ValidateBinarySearchTreeRecursively(root.right);
                if (!rightSubTree)
                    return false;
            }

            return true;
        }



    }
}
