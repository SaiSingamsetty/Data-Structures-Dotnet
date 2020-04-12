using System;
using System.Collections.Generic;
using DataStructures.DataStructureSpecific.Trees.Models;

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

        public static void AddChildInLevelOrder<T>(this TreeNode<T> currentNode, T value)
        {
            var queue = new Queue<TreeNode<T>>();
            queue.Enqueue(currentNode);

            while (queue.Count != 0)
            {
                var pointer = queue.Dequeue();

                if (pointer.LeftChild == null)
                {
                    pointer.LeftChild = new TreeNode<T>(value);
                    break;
                }
                else
                {
                    queue.Enqueue(pointer.LeftChild);
                }

                if (pointer.RightChild == null)
                {
                    pointer.RightChild = new TreeNode<T>(value);
                    break;
                }
                else
                {
                    queue.Enqueue(pointer.RightChild);
                }
            }
        }

        public static void DeleteNode<T>(this TreeNode<T> currentNode, T value)
        {
            // Find the key node to be deleted, right most bottom node to be replaced with key node
            var queue = new Queue<TreeNode<T>>();
            queue.Enqueue(currentNode);
            TreeNode<T> keyNode = null;

            //As queue is enqueue-ed in such a way that it will go till last node which will be right most bottom node
            TreeNode<T> bottomNode = null;

            while (queue.Count != 0)
            {
                bottomNode = queue.Dequeue();
                if (bottomNode.Data == (dynamic) value && keyNode == null)
                {
                    keyNode = bottomNode;
                }

                if (bottomNode.LeftChild != null)
                    queue.Enqueue(bottomNode.LeftChild);
                if (bottomNode.RightChild != null)
                    queue.Enqueue(bottomNode.RightChild);
            }

            if (keyNode == null)
                return;

            var data = bottomNode.Data;

            //Delete the right most bottom node
            queue.Clear();
            queue.Enqueue(currentNode);

            while (queue.Count != 0)
            {
                var pointer = queue.Dequeue();
                if (pointer == bottomNode)
                {
                    bottomNode = null;
                    break;
                }

                if (pointer.LeftChild != null)
                {
                    if (pointer.LeftChild == bottomNode)
                    {
                        pointer.LeftChild = null;
                        break;
                    }

                    queue.Enqueue(pointer.LeftChild);
                }

                if (pointer.RightChild != null)
                {
                    if (pointer.RightChild == bottomNode)
                    {
                        pointer.RightChild = null;
                        break;
                    }

                    queue.Enqueue(pointer.RightChild);
                }
            }

            //Replace data of key node with right most bottom 
            keyNode.Data = data;
        }

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
    }
}