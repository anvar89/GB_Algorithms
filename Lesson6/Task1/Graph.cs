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
                    if (IsExistEdge(Nodes[index], Nodes[i]) && nodeStatus[i] == 0)
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

        public Node[] GetArrayDFS()
        {
            var stack = new Stack<Node>();
            var returnArray = new List<Node>();

            stack.Push(Nodes[0]);

            while (stack.Count > 0)
            {
                var element = stack.Pop();

                if (returnArray.Contains(element)) continue;

                returnArray.Add(element);

                foreach (var node in Nodes)
                {
                    if (!returnArray.Contains(node))
                        stack.Push(node);
                }
            }

            return returnArray.ToArray();
        }

        private bool IsExistEdge(Node startNode, Node endNode)
        {
            foreach (var edge in startNode.Edges)
            {
                if (edge.Node == endNode) return true;
            }
            return false;
        }
    }

}
