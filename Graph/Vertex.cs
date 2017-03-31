using System;
using System.Diagnostics;

namespace Graph
{
    public class Vertex<T>
    {
        public T Data { get; set; }

        public int NodeNumber { get; set; }
        public bool IsSeen{ get; set; }

        public int Condition=Int32.MaxValue;

        public override string ToString()
        {
            return "NodeNumber : " + NodeNumber + " data = " + Data;
        }
    }
}