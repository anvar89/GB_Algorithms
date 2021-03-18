using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Task1;

namespace Task1.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_BSF_normalGraph()
        {
            var expected = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 

            Graph g = GetTestGraph();
            var bfs = g.GetArrayBFS();
            int[] actual = new int[bfs.Length];

            for (int i = 0; i < bfs.Length; i++)
            {
                actual[i] = bfs[i].Value;
            }

            Assert.IsTrue(actual.SequenceEqual(actual));
        }

        [TestMethod]
        public void Test_DFS_normalGraph()
        {
            var expected = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Graph g = GetTestGraph();
            var dfs = g.GetArrayDFS();
            int[] actual = new int[dfs.Length];

            for (int i = 0; i < dfs.Length; i++)
            {
                actual[i] = dfs[i].Value;
            }

            Assert.IsTrue(actual.SequenceEqual(actual));
        }

        [TestMethod]
        public void Test_BSF_normalGraph2()
        {
            var expected = new[] { 0, 1, 2, 3, 4 };

            Graph g = GetTestGraph2();
            var bfs = g.GetArrayBFS();
            int[] actual = new int[bfs.Length];

            for (int i = 0; i < bfs.Length; i++)
            {
                actual[i] = bfs[i].Value;
            }

            Assert.IsTrue(actual.SequenceEqual(actual));
        }

        [TestMethod]
        public void Test_DFS_normalGraph2()
        {
            var expected = new[] { 0, 3, 4, 2, 1 };

            Graph g = GetTestGraph2();
            var dfs = g.GetArrayDFS();
            int[] actual = new int[dfs.Length];

            for (int i = 0; i < dfs.Length; i++)
            {
                actual[i] = dfs[i].Value;
            }

            Assert.IsTrue(actual.SequenceEqual(actual));
        }
        static Graph GetTestGraph()
        {
            Graph g = new Graph();

            for (int i = 0; i < 10; i++)
            {
                g.AddNode(new Node() { Value = i });
            }

            g.AddEdge(g.Nodes[0], g.Nodes[2], 1);
            g.AddEdge(g.Nodes[0], g.Nodes[1], 1);
            g.AddEdge(g.Nodes[2], g.Nodes[3], 1);
            g.AddEdge(g.Nodes[1], g.Nodes[3], 1);
            g.AddEdge(g.Nodes[3], g.Nodes[5], 1);
            g.AddEdge(g.Nodes[3], g.Nodes[4], 1);
            g.AddEdge(g.Nodes[5], g.Nodes[6], 1);
            g.AddEdge(g.Nodes[4], g.Nodes[6], 1);
            g.AddEdge(g.Nodes[6], g.Nodes[8], 1);
            g.AddEdge(g.Nodes[6], g.Nodes[7], 1);
            g.AddEdge(g.Nodes[8], g.Nodes[9], 1);
            g.AddEdge(g.Nodes[7], g.Nodes[9], 1);

            return g;

        }

        static Graph GetTestGraph2()
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

            return g;

        }
    }
}
