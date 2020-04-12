namespace DataStructures.DataStructureSpecific.Trees.Models
{
    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            Data = value;
            LeftChild = null;
            RightChild = null;
        }

        public T Data { get; set; }

        public TreeNode<T> LeftChild { get; set; }

        public TreeNode<T> RightChild { get; set; }
    }
}