using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();

            for (int i = 0; i < 5; i++)
            {
                g.AddNode(new Node() { Value = i });
            }

            g.AddEdge(g.Nodes[0], g.Nodes[1], 1);
            g.AddEdge(g.Nodes[0], g.Nodes[2], 1);
            g.AddEdge(g.Nodes[0], g.Nodes[3], 1);
            g.AddEdge(g.Nodes[3], g.Nodes[4], 1);
            g.AddEdge(g.Nodes[2], g.Nodes[4], 1);
            g.AddEdge(g.Nodes[1], g.Nodes[4], 1);
            


            var bfs = g.GetArrayBFS();
            Console.Write("BFS: ");
            foreach (var node in bfs)
            {
                Console.Write(node + " ");
            }

            Console.WriteLine();

            var dfs = g.GetArrayDFS();
            Console.Write("DFS: ");
            foreach (var node in dfs)
            {
                Console.Write(node + " ");
            }
        }
    }
}

