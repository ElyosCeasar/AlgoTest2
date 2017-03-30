using System.Security.Cryptography.X509Certificates;

namespace Disjoint_set
{
    /// <summary>
    /// نمایش لیست مجزا که از درخت استفاده شده و از رنک و تراکم مسیر برای بهبود زمان استفاده شده که 
    /// O(m@(n))
    /// است
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeForm<T>
    {
        /// <summary>
        /// دیتا می گیریم ودرختی با یک نود که شامل آن دیتا است با رنک 0 می سازیم
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static TreeNode<T> Make(T data )
        {
            TreeNode<T> tempNode = new TreeNode<T>();
            tempNode.Data = data;
            tempNode.Parent = tempNode;
            tempNode.Rank = 0;
            return tempNode;
        }
        /// <summary>
        /// در فایند هر سری اگر خودش پدر خودش نبود(یعنی ریشه نبود)به صورت بازگشتی پدرش را فایند پدرش قرار می دهیم که باعث می شود
        /// نود با حفظ رنک به ریشه متصل شود و در نهایت پدرش را (ریشه را) به عنوان نماینده بر می  گردانیم
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>

        public static TreeNode<T> Find(TreeNode<T> node)
        {
            if (!node.Parent.Equals(node))
            {
                node.Parent=Find(node.Parent);

            }
         return node.Parent;
        }
        /// <summary>
        /// ریشه ها را به وسیله ی لینک متحصل می کند
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>

        public static void Union(TreeNode<T> node1, TreeNode<T> node2)
        {
            Link(Find(node1), Find(node2));

        }
        /// <summary>
        /// اگر برابر بود رنک هر دو اولی را پدر دومی قرار می دهد و رنک را یه دانه افزایش می دهد
        /// اگر اولی یا دومی کوچک تر بود کوچکتر را فرزند بزرگ تر قرر می دهد بدون تغییر رنک
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
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