using System.Security.Cryptography.X509Certificates;

namespace Disjoint_set
{
    public class TreeForm<T>
    {
        public static TreeNode<T> Make(T data )
        {
            TreeNode<T> tempNode = new TreeNode<T>();
            tempNode.Data = data;
            tempNode.Parent = tempNode;
            tempNode.Rank = 0;
            return tempNode;
        }

        public static TreeNode<T> Find(TreeNode<T> node)
        {
            if (!node.Parent.Equals(node))
            {
                node.Parent=Find(node.Parent);

            }
         return node.Parent;
        }

        public static void Union(TreeNode<T> node1, TreeNode<T> node2)
        {
            Link(Find(node1), Find(node2));

        }
        private static void Link(TreeNode<T> node1, TreeNode<T> node2)
        {
            if (node1.Rank > node2.Rank)
            {
                node2.Parent = node1;

            }
            else if (node1.Rank < node2.Rank)
            {
                node1.Parent = node2;
            }
            else//equals in rank
            {
                node2.Parent = node1;
                node1.Rank++;
            }
        }
    }

    public class TreeNode<T>
    {
        public T Data { set; get; }
        public int Rank { set; get; }
        public TreeNode<T> Parent { set; get; }
    }
}