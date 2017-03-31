using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    /// <summary>
    /// پیاده سازی لیستی گراف
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class G_LinkedListForm<T>
    {
        /// <summary>
        /// هر نود مپ می شه به یک خونه از 
        /// adj
        /// هر خونه از
        /// adj
        /// اشاره می کنه به نود همسایه های اون نود
        /// </summary>
        public List<LinkedList<Vertex<T>>> Adj =new List<LinkedList<Vertex<T>>>();
        /// <summary>
        /// یک لیست از کل ادج ها
        /// </summary>
        public List<Edge<T>> Edges =new List<Edge<T>>();
        private bool hasDirection = false;//گراف جهتدار هست یانه

        public G_LinkedListForm(bool hasDirection)
        {
            this.hasDirection = hasDirection;
        }
        /// <summary>
        /// نود جدید می سازد مقدارش را که گرفتیم ست می کنیم
        /// شماره ی خونهی آخر ادج که قرار نود توش قرار بگیره رو بهش می دیم
        /// و برشمی گردونیم
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Vertex<T> AddNode(T data)
        {
            Vertex<T > newVertex=new Vertex<T>();
            newVertex.Data = data;
            newVertex.IsSeen = false;
            newVertex.NodeNumber = Adj.Count;
            Adj.Add(new LinkedList<Vertex<T>>() );
            return newVertex;
        }
        /// <summary>
        /// یک ادج می سازه
        /// همسایه ها رو بسته به جهت دار بودن یا نبودن آپدیت می کنه
        /// اگر اون یال وزن داشته باشه ست می کنه
        /// به لیست ادج ها اضافش می کنه
        /// برش می گردونه
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="weight"></param>
        /// <returns></returns>

        public Edge<T> AddEdge(Vertex<T> node1, Vertex<T> node2,int weight=0 )//we cant have two edge betwen two nodes if equals wieght
        {
            Edge<T> newEdge=new Edge<T>();
            newEdge.FirstVertex = node1;
            newEdge.SecondVertex = node2;
            newEdge.Weight = weight;
            newEdge.Number = Edges.Count;
            foreach (Edge<T> VARIABLE in Edges)//if this is exist
            {
                if (newEdge.Equals(VARIABLE))
                    return VARIABLE;
            }
            Edges.Add(newEdge);
            Adj[node1.NodeNumber].AddFirst(node2);
            if (!hasDirection)//اگه جهت دار نبود
            {
                Adj[node2.NodeNumber].AddFirst(node1);
            }
            return newEdge;
        }
        /// <summary>
        /// لیست همسایه ها رو می ده
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public LinkedList<Vertex<T>> Neighbours(Vertex<T> node)
        {
            return Adj[node.NodeNumber];
        }

        public int HowManyEdgesWeHave()
        {
            return Edges.Count;
        }

        public int HowManyVertexWeHave()
        {
            return Adj.Count;
        }
        /// <summary>
        /// می بینه نود ایزوله هست یانه
        /// چه جهت دار باشه چه بی جهت
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool isIsolated(Vertex<T> node)
        {
            bool result = true;
            if (hasDirection == true && result == true)//زمانی که جهت دار است باید چک شود نود انتهایی هیچ ادجی نباشد
            {
                for (int i = 0; i < Edges.Count; i++)
                {
                    if (Edges[i].SecondVertex.Equals(node))
                    {
                        if (!Edges[i].FirstVertex.Equals(node))
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            if (Adj[node.NodeNumber].Count == 0)
                return result;
            else
            {
                LinkedList<Vertex<T>> temp = Adj[node.NodeNumber];
                for (int i = 0; i < temp.Count; i++)
                {
                    if (!temp.ElementAt(i).Equals(node))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;


        }

        //it is an Bfs 
        /// <summary>
        /// یک صف از نود ها می گیریم نود اول رو می ندازیم وش تا موقعی که صف خال نشده هر سری یه نود بر می داریم
        /// چک می کنیم دیده نشده باشه
        /// به عنوان دیده شده علامت می زنیم
        /// می ریزیمش تو صف نتیجه
        /// بچه هاش رومی ریزیم تو صف نود ها و این کار رو تکرار می کنیم
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<Vertex<T>> BFS(Vertex<T> node )
        {
            Queue<Vertex<T>> nodesQueue=new Queue<Vertex<T>>();
            List<Vertex<T>> resultList = new List<Vertex<T>>();
           
           nodesQueue.Enqueue(node);
            while (nodesQueue.Count!=0)
            {
                node = nodesQueue.Dequeue();
                if (node.IsSeen==true)
                    continue;
                resultList.Add(node);
                node.IsSeen = true;
                for (int i = 0; i < Adj[node.NodeNumber].Count; i++)
                {
                    nodesQueue.Enqueue(Adj[node.NodeNumber].ElementAt(i));
                }
            }
            for (int i = 0; i < resultList.Count; i++)//recycling
            {
                resultList[i].IsSeen = false;
            }
            return resultList;
        }
/// <summary>
/// شبیه بی اف اس عمل می کنیم تنها فرق اینه از کاندیشن استفاده می کنیم اولی رو 0 می گذاریم بعد موقعه اضافه کردن فرزنداش به صف می آیم
/// اگر کاندیشنشون بی نهیت بود می آیم به فاصله تبدیل می کنیم 
/// </summary>
/// <param name="fromNode"></param>
/// <param name="toNode"></param>
/// <returns></returns>
        public int distance(Vertex<T> fromNode, Vertex<T> toNode)//گراف بی وزن
        {
            Queue<Vertex<T>> nodesQueue = new Queue<Vertex<T>>();
            List<Vertex<T>> seenList = new List<Vertex<T>>();
            int distenceResult = -1;
            fromNode.Condition = 0;
            nodesQueue.Enqueue(fromNode);
            while (nodesQueue.Count != 0)
            {
                fromNode = nodesQueue.Dequeue();
                if (fromNode.IsSeen == true)
                    continue;
                seenList.Add(fromNode);
                fromNode.IsSeen = true;
                for (int i = 0; i < Adj[fromNode.NodeNumber].Count; i++)
                {
                    if (Adj[fromNode.NodeNumber].ElementAt(i).Condition==Int32.MaxValue)
                    Adj[fromNode.NodeNumber].ElementAt(i).Condition = fromNode.Condition + 1;
                    nodesQueue.Enqueue(Adj[fromNode.NodeNumber].ElementAt(i));
                }
            }
            distenceResult = toNode.Condition;
            for (int i = 0; i < seenList.Count; i++)//دوباره مصرف کردنrecycling
            {
                seenList[i].IsSeen = false;
                seenList[i].Condition=Int32.MaxValue;
            }
            return distenceResult;
        }

    }
}
