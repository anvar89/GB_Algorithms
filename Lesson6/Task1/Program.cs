using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();

            g.AddNode(new Node() { Value = 10 });
            g.AddNode(new Node() { Value = 11 });
            g.AddNode(new Node() { Value = 12 });
            g.AddNode(new Node() { Value = 13 });
            g.AddNode(new Node() { Value = 14 });
            g.AddNode(new Node() { Value = 15 });

            g.AddEdge(g.Nodes[0], g.Nodes[1], 1);
            g.AddEdge(g.Nodes[1], g.Nodes[2], 1);
            g.AddEdge(g.Nodes[2], g.Nodes[3], 1);
            g.AddEdge(g.Nodes[3], g.Nodes[4], 1);
            g.AddEdge(g.Nodes[4], g.Nodes[5], 1);
            g.AddEdge(g.Nodes[5], g.Nodes[0], 1);


            var bfs = g.GetArrayBFS();

            foreach (var node in bfs)
            {
                Console.Write(node + " -> ");
            }
        }
    }
}

