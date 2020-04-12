using DataStructures.DataStructureSpecific.Trees.Models;
using System;
using System.Collections.Generic;

namespace DataStructures.DataStructureSpecific.Trees
{
    public static class BinaryTreeOperations
    {
        public static void AddLeftChild<T>(this TreeNode<T> currentNode, T value)
        {
            if (currentNode.LeftChild == null)
            {
                currentNode.LeftChild = new TreeNode<T>(value);
            }
            else
            {
                // If current node already has left child
                var newNode = new TreeNode<T>(value)
                {
                    LeftChild = currentNode.LeftChild
                };

                currentNode.LeftChild = newNode;
            }
        }

        public static void AddRightChild<T>(this TreeNode<T> currentNode, T value)
        {
            if (currentNode.RightChild == null)
            {
                currentNode.RightChild = new TreeNode<T>(value);
            }
            else
            {
                // If current node already has left child
                var newNode = new TreeNode<T>(value)
                {
                    RightChild = currentNode.RightChild
                };

                currentNode.RightChild = newNode;
            }
        }

        public static void DeleteNode<T>(this TreeNode<T> currentNode, T value)
        {
            //TODO:WIP

        }

        #region Depth First Search Traversal

        public static void PreOrderTraversal<T>(this TreeNode<T> currentNode)
        {
            Console.WriteLine("Data: " + currentNode.Data);

            currentNode.LeftChild?.PreOrderTraversal();

            currentNode.RightChild?.PreOrderTraversal();
        }

        public static void InOrderTraversal<T>(this TreeNode<T> currentNode)
        {
            currentNode.LeftChild?.InOrderTraversal();

            Console.WriteLine("Data: " + currentNode.Data);

            currentNode.RightChild?.InOrderTraversal();
        }

        public static void PostOrderTraversal<T>(this TreeNode<T> currentNode)
        {
            currentNode.LeftChild?.PostOrderTraversal();

            currentNode.RightChild?.PostOrderTraversal();

            Console.WriteLine("Data: " + currentNode.Data);
        }

        #endregion

        #region Breadth First Search Traversal

        public static void BreadthFirstSearchTraversal<T>(this TreeNode<T> currentNode)
        {
            var queue = new Queue<TreeNode<T>>();
            queue.Enqueue(currentNode);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine("Data: " + node.Data);

                if (node.LeftChild != null)
                    queue.Enqueue(node.LeftChild);

                if (node.RightChild != null)
                    queue.Enqueue(node.RightChild);
            }

        }

        #endregion
    }
}
