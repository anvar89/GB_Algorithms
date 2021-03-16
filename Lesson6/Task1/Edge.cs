using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
/// <summary>
/// Ребро, Связь между вершинами
/// </summary>
    class Edge
    {
        public int Weight { get; set; } //вес связи
        public Node Node { get; set; } // узел, на который связь ссылается

        public Edge()
        {
            Node = new Node();
            Weight = 0;
        }
    }
}
