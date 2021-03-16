using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Graph
    {
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
        }

        public void AddNode(Node node)
        {
            this.Nodes.Add(node);
        }

        public void AddEdge(Node startNode, Node endNode, int weight)
        {
            if (Nodes.Contains(startNode) && Nodes.Contains(endNode))
            {
                startNode.Edges.Add(new Edge() { Node = endNode, Weight = weight });
            }
        }

        public Node[] GetArrayBFS()
        {
            var bufer = new Queue<int>();
            var returnArray = new List<Node>();
            int[] nodeStatus = new int[Nodes.Count]; // Метки для пройденных вершин
            int index = 0; // Текущий номер вершины графа

            nodeStatus[index] = 1;
            bufer.Enqueue(index);
            returnArray.Add(Nodes[index]);

            while (bufer.Count != 0)
            {
                index = bufer.Dequeue();

                for (int i = 0; i < Nodes.Count; i++)
                {
                    if (IsExistPath(Nodes[index], Nodes[i]) && nodeStatus[i] == 0)
                    {
                        nodeStatus[i] = 1;
                        bufer.Enqueue(i);

                        returnArray.Add(Nodes[i]);
                    }
                }

                nodeStatus[index] = 2;
            }

            return returnArray.ToArray();
        }

        private bool IsExistPath(Node startNode, Node endNode)
        {
            foreach (var edge in startNode.Edges)
            {
                if (edge.Node == endNode) return true;
            }
            return false;
        }
    }

}
