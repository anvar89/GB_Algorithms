using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    /// <summary>
    /// Вершина графа
    /// </summary>
    public class Node
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; } //исходящие связи

        public Node()
        {
            Edges = new List<Edge>();
            Value = 0;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
