using System;
using DataStructures.DataStructureSpecific.Trees.Models;

namespace DataStructures.DataStructureSpecific.Trees
{
    //https://www.freecodecamp.org/news/all-you-need-to-know-about-tree-data-structures-bceacb85490c/

    public static class BinaryTree
    {
        public static void Init()
        {
            var rootNode = new TreeNode<string>("a");
            rootNode.AddLeftChild("b");
            rootNode.AddRightChild("c");

            var bNode = rootNode.LeftChild;
            bNode.AddRightChild("d");

            var cNode = rootNode.RightChild;
            cNode.AddRightChild("f");
            cNode.AddLeftChild("e");

            //Tree Traversals
            //DFS
            Console.WriteLine("Pre Order Traversal.");
            rootNode.PreOrderTraversal();

            Console.WriteLine("In order traversal.");
            rootNode.InOrderTraversal();

            Console.WriteLine("Post order traversal.");
            rootNode.PostOrderTraversal();

            //BFS
            Console.WriteLine("Breadth First Search Traversal.");
            rootNode.BreadthFirstSearchTraversal();

        }
    }
}
