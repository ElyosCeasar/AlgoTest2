using System.Runtime.Serialization.Formatters;

namespace Graph
{
    public class Edge<T>
    {
        public Vertex<T> FirstVertex { get; set; }
        public Vertex<T> SecondVertex { get; set; }
        public int Number { get; set; }
        public int Weight { get; set; }
        //اگه گراف های که بدون جهت اند و نخوایم از هر یال که بین دو راس هستن بیش از یک نسخه داشه باشیم
//        public override bool Equals(object obj)
//        {
//            if (!(obj is Edge<T>))
//                return false;
//            Edge<T> tempEdge = (Edge<T>) obj;
//            if(tempEdge.FirstVertex.Equals(this.FirstVertex))
//                if(tempEdge.SecondVertex.Equals(this.SecondVertex))
//                    if (tempEdge.Weight.Equals(this.Weight))
//                        return true;
//            if (tempEdge.SecondVertex.Equals(this.FirstVertex))
//                if (tempEdge.FirstVertex.Equals(this.SecondVertex))
//                    if (tempEdge.Weight.Equals(this.Weight))
//                        return true;
//
//
//            return true;
//        }
    }
}