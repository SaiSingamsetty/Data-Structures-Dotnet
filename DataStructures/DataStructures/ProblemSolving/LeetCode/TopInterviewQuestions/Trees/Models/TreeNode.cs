namespace DataStructures.ProblemSolving.LeetCode.TopInterviewQuestions.Trees.Models
{
    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            val = value;
        }

        public T val { get; set; }

        public TreeNode<T> left { get; set; }

        public TreeNode<T> right { get; set; }
    }
}