using DataStructures.DataStructureSpecific.Trees.Models;

namespace DataStructures.DataStructureSpecific.Trees
{
    public static class BinarySearchTreeOperations
    {
        public static void AddNodeToBinarySearchTree<T>(this TreeNode<T> currentNode, T value)
        {
            dynamic newValue = value;

            if (newValue <= currentNode.Data && currentNode.LeftChild != null)
            {
                currentNode.LeftChild.AddNodeToBinarySearchTree(value);
            }
            else if (newValue <= currentNode.Data)
            {
                currentNode.LeftChild = new TreeNode<T>(value);
            }
            else if (newValue > currentNode.Data && currentNode.RightChild != null)
            {
                currentNode.RightChild.AddNodeToBinarySearchTree(value);
            }
            else
            {
                currentNode.RightChild = new TreeNode<T>(value);
            }
        }

        public static bool SearchForNode<T>(this TreeNode<T> currentNode, T value)
        {
            if (currentNode.Data == (dynamic) value)
            {
                return true;
            }

            if ((dynamic) value <= currentNode.Data && currentNode.LeftChild != null)
                return currentNode.LeftChild.SearchForNode(value);

            if ((dynamic) value > currentNode.Data && currentNode.RightChild != null)
                return currentNode.RightChild.SearchForNode(value);

            return false;
        }
    }
}