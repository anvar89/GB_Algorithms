using Lesson4_Task2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Task2.Test
{
    [TestClass]
    public class BinaryTreeTest
    {
        #region константы для тестов
        static NodeInfo[] GetNodeInfo()
        {
            return new NodeInfo[]
                {
                new NodeInfo() {Depth = 0, Node = new TreeNode() { Value = 100 } },
                new NodeInfo() {Depth = 1, Node = new TreeNode() { Value = 50 } }, 
                new NodeInfo() {Depth = 1, Node = new TreeNode() { Value = 150 } },
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 25 } }, 
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 75 } }, 
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 125 } },
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 175 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 12 } }, 
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 37 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 62 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 87 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 112 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 137 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 162 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 187 } }
                };
        }
        static int[] values = new[] { 100, 50, 150, 25, 75, 125, 175, 12, 37, 62, 87, 112, 137, 162, 187 };
        #endregion

        [TestMethod]
        public void Test_AddItem_Line()
        {
            int valueCount = 10;
            var expected = new NodeInfo[valueCount];

            var testedTree = new BinaryTree();


            for (int i = 0; i < valueCount; i++)
            {
                expected[i] = new NodeInfo()
                {
                    Depth = i,
                    Node = new TreeNode() { Value = i }
                };

                testedTree.AddItem(i);
            }

            var actual = TreeHelper.GetTreeInLine(testedTree);

            Assert.IsTrue(NodeInfoArrayIsEquals(expected, actual));
        }

        [TestMethod]
        public void Test_AddItem_array()
        {
            var expected = GetNodeInfo();

            var testedTree = new BinaryTree();
            for (int i = 0; i < values.Length; i++)
            {
                testedTree.AddItem(values[i]);
            }
            var actual = TreeHelper.GetTreeInLine(testedTree);

            Assert.IsTrue(NodeInfoArrayIsEquals(expected, actual));
        }

        [TestMethod]
        [DataRow(1, new[] { 456, 987, 321, 741, 852, 963, 1, 123, 234, 456 })]
        [DataRow(123, new[] { 789, 654, 321, 456 })]
        public void Test_GetNodeByValue(int targetValue, int[] values)
        {
            bool isContainTargetValue = Array.Exists(values, x => x == targetValue);

            var expected = isContainTargetValue ? new TreeNode() { Value = targetValue } : null;

            var TestedTree = new BinaryTree();

            foreach (var item in values)
            {
                TestedTree.AddItem(item);
            }
            var actual = TestedTree.GetNodeByValue(targetValue);

            bool result = isContainTargetValue ? expected.Equals(actual) : expected == actual;

            Assert.IsTrue(result);
        }

        [TestMethod]
        //[DataRow(187, new[] { 100, 50, 150, 25, 75, 125, 175, 12, 37, 62, 87, 112, 137, 162, 187 })]
        //[DataRow(75, new[] { 100, 50, 150, 25, 75, 125, 175, 12, 37, 62, 87, 112, 137, 162, 187 })]
        //[DataRow(100, new[] { 100, 50, 150, 25, 75, 125, 175, 12, 37, 62, 87, 112, 137, 162, 187 })]
        //[DataRow(0, new[] { 100, 50, 150, 25, 75, 125, 175, 12, 37, 62, 87, 112, 137, 162, 187 })]
        public void Test_RemoveItem_fromTail()
        {
            int targetValue = 187;
            var expected = GetNodeInfo();
            var testedTree = new BinaryTree();

            foreach (var item in values)
            {
                testedTree.AddItem(item);
            }
            testedTree.RemoveItem(targetValue);
            expected = expected.Where(x => x.Node.Value != targetValue).ToArray();
            var actual = TreeHelper.GetTreeInLine(testedTree);

            Assert.IsTrue(NodeInfoArrayIsEquals(expected, actual));
        }

        [TestMethod]
        public void Test_RemoveItem_middleNode()
        {
            int targetValue = 150;
            var expected = new NodeInfo[]
                {
                new NodeInfo() {Depth = 0, Node = new TreeNode() { Value = 100 } },
                new NodeInfo() {Depth = 1, Node = new TreeNode() { Value = 50 } },
                new NodeInfo() {Depth = 1, Node = new TreeNode() { Value = 162 } }, // было 150
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 25 } },
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 75 } },
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 125 } },
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 175 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 12 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 37 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 62 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 87 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 112 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 137 } },
                //new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 162 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 187 } }
                };

            var testedTree = new BinaryTree();

            foreach (var item in values)
            {
                testedTree.AddItem(item);
            }
            testedTree.RemoveItem(targetValue);

            var actual = TreeHelper.GetTreeInLine(testedTree);

            Assert.IsTrue(NodeInfoArrayIsEquals(expected, actual));
        }

        [TestMethod]
        public void Test_RemoveItem_root()
        {
            int targetValue = 100;
            var expected = new NodeInfo[]
                {
                new NodeInfo() {Depth = 0, Node = new TreeNode() { Value = 112 } }, // было 100
                new NodeInfo() {Depth = 1, Node = new TreeNode() { Value = 50 } },
                new NodeInfo() {Depth = 1, Node = new TreeNode() { Value = 150 } }, 
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 25 } },
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 75 } },
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 125 } },
                new NodeInfo() {Depth = 2, Node = new TreeNode() { Value = 175 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 12 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 37 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 62 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 87 } },
                //new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 112 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 137 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 162 } },
                new NodeInfo() {Depth = 3, Node = new TreeNode() { Value = 187 } }
                };

            var testedTree = new BinaryTree();

            foreach (var item in values)
            {
                testedTree.AddItem(item);
            }
            testedTree.RemoveItem(targetValue);

            var actual = TreeHelper.GetTreeInLine(testedTree);

            Assert.IsTrue(NodeInfoArrayIsEquals(expected, actual), $"expected: {printNodeInfoArray(expected)} \n" +
                $"actual: {printNodeInfoArray(actual)} \n");
        }

        static bool NodeInfoArrayIsEquals(NodeInfo[] array1, NodeInfo[] array2)
        {
            if (array1.Length != array2.Length) return false;

            bool result = true;

            for (int i = 0; i < array1.Length; i++)
            {
                if (!array1[i].Node.Equals(array2[i].Node) || array1[i].Depth != array2[i].Depth)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        static string printNodeInfoArray(NodeInfo[] arr)
        {
            string message = "";

            foreach (var item in arr)
            {
                message += $"[D={item.Depth}, V={item.Node.Value}] ";
            }
            return message;
        }
    }
}
