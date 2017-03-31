using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disjoint_set;
using Graph;

namespace Algorithem
{
    class Program
    {
        static void Main(string[] args)
        {
            //تست لینکدلیست مجموعه ی مجزا
            //            DisjointSetLInkedLIstFormNode<int> a1= LinkedLIstForm<int>.Make(1);
            //            DisjointSetLInkedLIstFormNode<int> a2=LinkedLIstForm< int>.Make(2);
            //            DisjointSetLInkedLIstFormNode<int> a3=LinkedLIstForm< int>.Make(3);
            //            DisjointSetLInkedLIstFormNode<int> a4=LinkedLIstForm< int>.Make(4);
            //            LinkedLIstForm<int>.Union(a1,a2);
            //            System.Console.Write(LinkedLIstForm<int>.Find(a2).Data);
            //            System.Console.Write(LinkedLIstForm<int>.IsUnion(a1,a2));
            //            System.Console.Write(LinkedLIstForm<int>.IsUnion(a1, a3));
            //            System.Console.ReadKey();
            //تست درخت مجموعه ی مجزا
//            TreeNode<int> b1 = TreeForm<int>.Make(1);
//            TreeNode<int> b2 = TreeForm<int>.Make(2);
//            TreeNode<int> b3 = TreeForm<int>.Make(3);
//            System.Console.Write(TreeForm<int>.Find(b1).Data);
//            System.Console.Write(TreeForm<int>.Find(b2).Data);
//            TreeForm<int>.Union(b1,b2);
//            System.Console.WriteLine();
//            System.Console.Write(TreeForm<int>.Find(b1).Data);
//            System.Console.Write(TreeForm<int>.Find(b2).Data);
//            TreeForm<int>.Union(b3, b2);
//            System.Console.WriteLine();
//            System.Console.Write(TreeForm<int>.Find(b1).Data);
//            System.Console.Write(TreeForm<int>.Find(b2).Data);
//            System.Console.Write(TreeForm<int>.Find(b3).Data);
//            System.Console.ReadKey();
//تست نمایش گراف
   Graph.G_LinkedListForm<int> graph=new G_LinkedListForm<int>(false);
            Vertex<int> c1=graph.AddNode(0);
            Vertex<int> c2 = graph.AddNode(1);
            Vertex<int> c3 = graph.AddNode(3);
            Vertex<int> c4= graph.AddNode(4);
            Vertex<int> c5 = graph.AddNode(5);
            Vertex<int> c6 = graph.AddNode(6);
            Vertex<int> c7 = graph.AddNode(7);
            Vertex<int> c8 = graph.AddNode(8);
            System.Console.WriteLine(graph.Neighbours(c3).Count);
            Edge<int> E1 = graph.AddEdge(c1, c2);
            Edge<int> E2 = graph.AddEdge(c1, c3);
            Edge<int> E3 = graph.AddEdge(c3, c4);
            Edge<int> E4 = graph.AddEdge(c3, c5);
            Edge<int> E5 = graph.AddEdge(c2, c6);
            Edge<int> E6 = graph.AddEdge(c4, c7);
            Edge<int> E7 = graph.AddEdge(c6, c1);
          //  Edge<int> E8 = graph.AddEdge(c1, c3);
            System.Console.WriteLine(graph.Neighbours(c1).Count);
            System.Console.WriteLine(graph.HowManyEdgesWeHave());
            System.Console.WriteLine(graph.HowManyVertexWeHave());
            System.Console.WriteLine(graph.isIsolated(c1));
            System.Console.WriteLine(graph.isIsolated(c1));
            System.Console.WriteLine("BFS -> " );
            var tempG = graph.BFS(c1);
            for (int i = 0; i < tempG.Count; i++)
            {
                System.Console.WriteLine(tempG[i]);
            }
 
            System.Console.WriteLine(graph.distance(c1,c6));
            
            System.Console.ReadKey();
        }

     
    }
}
