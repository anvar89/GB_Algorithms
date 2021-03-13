using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lesson4_Task2;
using System.Linq;

namespace Task1.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(new[] { 879, 585, 486, 897, 785, 892, 102, 1, 652, 985, 2, 600, 925, 12 }, new[] { 879, 585, 897, 486, 785, 892, 985, 102, 652, 925, 1, 600, 2, 12 })]
        [DataRow(new[] { 9, 8, 7, 6, 3, 5, 2, 1, 4, 10, 16, 19, 12, 14, 13, 15 }, new[] { 9, 8, 10, 7, 16, 6, 12, 19, 3, 14, 2, 5, 13, 15, 1, 4 })]
        [DataRow(new[] { 1000, 950, 1050, 975, 925, 1075, 1025 }, new[] { 1000, 950, 1050, 925, 975, 1025, 1075 })]
        public void Test_BFS(int[] values, int[] expected)
        {
            var testedTree = new BinaryTree();
            foreach (var item in values)
            {
                testedTree.AddItem(item);
            }

            var BFSarray = Program.GetArrayBFS(testedTree.GetRoot());
            int[] actual = new int[BFSarray.Length];

            for (int i = 0; i < actual.Length; i++)
            {
                actual[i] = BFSarray[i].Value;
            }

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        [DataRow(new[] { 879, 585, 486, 897, 785, 892, 102, 1, 652, 985, 2, 600, 925, 12 }, new[] { 879, 585, 486, 102, 1, 2, 12, 785, 652, 600, 897, 892, 985, 925 })]
        [DataRow(new[] { 9, 8, 7, 6, 3, 5, 2, 1, 4, 10, 16, 19, 12, 14, 13, 15 }, new[] { 9, 8, 7, 6, 3, 2, 1, 5, 4, 10, 16, 12, 14, 13, 15, 19 })]
        [DataRow(new[] { 1000, 950, 1050, 975, 925, 1075, 1025 }, new[] { 1000, 950, 925, 975, 1050, 1025, 1075 })]
        public void Test_DFS(int[] values, int[] expected)
        {
            var testedTree = new BinaryTree();
            foreach (var item in values)
            {
                testedTree.AddItem(item);
            }

            var DFSarray = Program.GetArrayDFS(testedTree.GetRoot());
            int[] actual = new int[DFSarray.Length];

            for (int i = 0; i < actual.Length; i++)
            {
                actual[i] = DFSarray[i].Value;
            }

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
