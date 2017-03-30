using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Disjoint_set
{
    /// <summary>
    /// در این پیاده سازی ما باید از مت د استاتیک  LinkedLIstForm<>.Make()
    /// برای ساخت نود استفاده می کنیم این متد یک پارت تولید می کند که شامل یک هدر و یک نود است که هدر به نود اشاره کرده
    /// .
    /// در فایند ما یک نود می دهیم و نماینده را می گیریم
    /// .
    /// در ایزیونین بولین می ده که آیا این دو دارای یک نمایند هستند یانه
    /// .
    /// در یونیون هم دو پارت به هم متصل می شوند(اگر متصل باشند کاری نمی کند) و همیشه پارت کوچک به بزرگ وصل می شود
    /// .
    /// O(m+nLOGn)
    /// </summary>

        
       
    public class LinkedLIstForm<T>//متد های این کلاس همه استاتیک اند
    {


        /// <summary>
        /// you can inter a data and get a set with a header and the node that has that data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DisjointSetLInkedLIstFormNode<T> Make(T data)
        {
            DisjointSetLInkedLIstFormNode<T> node = new DisjointSetLInkedLIstFormNode<T>();
            ListHeaderLinkedList<T> header=new ListHeaderLinkedList<T>();
            node.Data = data;
            node.Next = null;
            node.HeaderLinkedList = header;
            header.Head = node;
            header.Tail = node;
            header.nodes.AddFirst(node);
            return node;
        }
        /// <summary>
        /// it gets us repreesener node of that part
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static DisjointSetLInkedLIstFormNode<T> Find( DisjointSetLInkedLIstFormNode<T> node)
        {
           return node.HeaderLinkedList.Head;
        }
        /// <summary>
        /// it checks that  repreesener node is equal
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>

        public static bool IsUnion(DisjointSetLInkedLIstFormNode<T> node1, DisjointSetLInkedLIstFormNode<T> node2)
        {
            return Find(node1).Equals(Find(node2));
        }

        public static void Union(DisjointSetLInkedLIstFormNode<T> node1, DisjointSetLInkedLIstFormNode<T> node2)
        {
            //we suppose to it is true then we change it if neccessery
            DisjointSetLInkedLIstFormNode<T> nodeWithSmallList = node2;
            DisjointSetLInkedLIstFormNode<T> nodeWithBigList=node1;
            if (IsUnion(node1, node2))
                return;
            else
            {
                if (node1.HeaderLinkedList.nodes.Count < node2.HeaderLinkedList.nodes.Count)//if other list is smaller
                {
                    nodeWithBigList = node2;
                    nodeWithSmallList = node1;
                }
                Join2Part(nodeWithSmallList, nodeWithBigList);
            }
        }

        private static void Join2Part(DisjointSetLInkedLIstFormNode<T> node1, DisjointSetLInkedLIstFormNode<T> node2)
        {
            ListHeaderLinkedList<T> node1Header = node1.HeaderLinkedList;
            ListHeaderLinkedList<T> node2Header = node2.HeaderLinkedList;
            for (int i = 0; i < node1Header.nodes.Count; i++)
            {
                DisjointSetLInkedLIstFormNode<T> temp = node1Header.nodes.First();
                node1Header.nodes.RemoveFirst();
                node2Header.Tail.Next = temp;
                node2Header.Tail = temp;
                temp.Next = null;
                temp.HeaderLinkedList = node2Header;

                
            }
        }

    }

    public class ListHeaderLinkedList<T>
    {
        public DisjointSetLInkedLIstFormNode<T> Head { get; set; }
        public DisjointSetLInkedLIstFormNode<T> Tail { get; set; }

           public LinkedList<DisjointSetLInkedLIstFormNode<T>> nodes { get; set; }

        public ListHeaderLinkedList()
        {
            nodes=new LinkedList<DisjointSetLInkedLIstFormNode<T>>();
        }

    }

    public class DisjointSetLInkedLIstFormNode<T>
    {
        public DisjointSetLInkedLIstFormNode<T> Next { get; set; }
        public T Data { get; set; }

        public ListHeaderLinkedList<T> HeaderLinkedList { get; set; }
        

    }

}
