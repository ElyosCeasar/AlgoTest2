using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Disjoint_set;
using Graph;

namespace MST
{
    /// <summary>
    /// الگوریتمی حریصانه برای یافتن درخت پوشای کمینه یا مسیری به همه ی نود ها با کمترین وزن
    /// </summary>
    public class Kruskal<T>
    {
        /// <summary>
        /// ابتدا یال های گراف را بر اساس صعودی مرتب می کنیم (برای نزولی می توان در تری فورم کامپیر تو را تغیر داد یا متد زیر را به وسیله ی معکوس کردن نزولی کرد
        /// سپس لیستی از نود ها درخت می سازیم و هر سری یک پارت به وسیله ی میک دیسجوین ست درست می کنیم و در آن می ریزیم می دانیم نود نامبر ها همان ایندکس های تمپ ورتکست نیز هستند
        /// (علاوه بر اینکه ایندکس های ورتکست های خود گراف نیز هستند)
        ///  در آخر می آیم می بینیم اگه دونود که سر و ته ادج هستند در یک ست از دیسجوینت ست نیستند برشان می داریم
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static List<Edge<T>> KruskalUseTreeDisjointSt(Graph.G_LinkedListForm<T> graph )
        {
            List<Edge<T>> tempEdges = graph.Edges;
            List<Edge<T>> resultEdges = new List<Edge<T>>();
            List < TreeNode < Vertex <T>>> tempVertices=new List<TreeNode<Vertex<T>>>();
           tempEdges.Sort();
            foreach (var graphVertex in graph.Vertices)
            {
                TreeNode<Vertex<T>> a = TreeForm<Vertex<T>>.Make(graphVertex);
                tempVertices.Add(a);
            }

            for (int i = 0; i < tempEdges.Count; i++)
            {
        
                if (!TreeForm<Vertex<T>>.Find(tempVertices[tempEdges[i].FirstVertex.NodeNumber]).Equals(TreeForm<Vertex<T>>.Find(tempVertices[tempEdges[i].SecondVertex.NodeNumber])))
                {
                    resultEdges.Add(tempEdges[i]);
                    TreeForm<Vertex<T>>.Union(tempVertices[tempEdges[i].FirstVertex.NodeNumber], tempVertices[tempEdges[i].SecondVertex.NodeNumber]);
                }
            }
         


            return resultEdges;

        }
        /// <summary>
        /// به وسیله ی صدا زدن کروسکال بالا آن را پرنت می کند
        /// </summary>
        /// <param name="graph"></param>
        public static void print(Graph.G_LinkedListForm<T> graph)
        {
            foreach (var VARIABLE in Kruskal<T>.KruskalUseTreeDisjointSt(graph))
            {
                Console.WriteLine(VARIABLE.FirstVertex.Data + "------" + VARIABLE.SecondVertex.Data);
            }
        }
        
    }
}
