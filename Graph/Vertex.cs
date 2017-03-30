namespace Graph
{
    public class Vertex<T>
    {
        public T Data { get; set; }

        public int NodeNumber { get; set; }
        public bool IsSeen{ get; set; }

    }
}