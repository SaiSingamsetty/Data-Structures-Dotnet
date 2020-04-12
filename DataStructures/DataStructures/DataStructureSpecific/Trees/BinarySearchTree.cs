using DataStructures.DataStructureSpecific.Trees.Models;

namespace DataStructures.DataStructureSpecific.Trees
{
    public static class BinarySearchTree
    {
        public static void Init()
        {
            var rootNode = new TreeNode<int>(50);
            rootNode.AddNodeToBinarySearchTree(21);
            rootNode.AddNodeToBinarySearchTree(76);
            rootNode.AddNodeToBinarySearchTree(4);
            rootNode.AddNodeToBinarySearchTree(32);
            rootNode.AddNodeToBinarySearchTree(100);
            rootNode.AddNodeToBinarySearchTree(64);
            rootNode.AddNodeToBinarySearchTree(52);

            //Search
            var responseFor52 = rootNode.SearchForNode(52);
            var responseFor23 = rootNode.SearchForNode(23);
            var responseFor0 = rootNode.SearchForNode(0);

        }
    }
}
