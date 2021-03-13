using System;

namespace Lesson4_Task2
{
    public class BinaryTree : ITree
    {
        private TreeNode root;

        public bool UseBTreePrinter { get; set; }

        public void AddItem(int value)
        {
            if (root == null)
            {
                root = new TreeNode() { Value = value };
            }
            else
                AddItemAfterNode(value, root);
        }

        private void AddItemAfterNode(int value, TreeNode node)
        {
            if (value < node.Value) //левая нода
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new TreeNode() { Value = value };
                    return;
                }

                AddItemAfterNode(value, node.LeftChild);
            }

            if (value > node.Value) //правая нода
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new TreeNode() { Value = value };
                    return;
                }

                AddItemAfterNode(value, node.RightChild);
            }

        }

        public TreeNode GetNodeByValue(int value) => (root == null) ? null : GetTreeNodeAfterNode(value, root);

        private TreeNode GetTreeNodeAfterNode(int value, TreeNode node)
        {
            if (value == node.Value) return node;

            if (value < node.Value && node.LeftChild != null)
                return GetTreeNodeAfterNode(value, node.LeftChild);

            if (value < node.Value && node.RightChild != null)
                return GetTreeNodeAfterNode(value, node.RightChild);

            return null;
        }

        public TreeNode GetRoot() => root;

        public void PrintTree()
        {
            //Console.Clear();

            if (UseBTreePrinter)
                BTreePrinter.Print(root);
            else
                printAltTree(root, "");

            Console.WriteLine();
        }

        private void printAltTree(TreeNode node, string auxString)
        {
            if (node == null) return;
            Console.WriteLine(node.Value);

            if (node.LeftChild != null || node.RightChild != null)
            {
                if (node.LeftChild != null && node.RightChild != null)  // У нода есть оба потомка
                {
                    Console.Write(auxString + "├[L]");

                    printAltTree(node.LeftChild, auxString + "│   ");
                    Console.Write(auxString + "└[R]");
                    printAltTree(node.RightChild, auxString + "    ");
                }

                if (node.LeftChild != null && node.RightChild == null)  // есть только левый потомок
                {
                    Console.Write(auxString + "└[L]");
                    printAltTree(node.LeftChild, auxString + "    ");
                }

                if (node.LeftChild == null && node.RightChild != null)  // есть только правый потомок
                {
                    Console.Write(auxString + "└[R]");
                    printAltTree(node.RightChild, auxString + "    ");
                }
            }
        }

        public void RemoveItem(int value)
        {
            root = RemoveItem(root, value);
        }
        private TreeNode GetParent(TreeNode node, int value)
        {
            if (root.Value == value || node == null) return null;

            if (node.Value > value)
            {
                if (node.LeftChild == null) return null;

                if (node.LeftChild.Value == value)
                    return node;
                else
                    return GetParent(node.LeftChild, value);
            }

            if (node.Value < value)
            {
                if (node.RightChild == null) return null;

                if (node.RightChild.Value == value)
                    return node;
                else
                    return GetParent(node.RightChild, value);
            }

            return null;
        }

        private TreeNode RemoveItem(TreeNode node, int value)
        {
            if (node == null) return null;

            if (node.Value > value)
                node.LeftChild = RemoveItem(node.LeftChild, value);
            else if (node.Value < value)
                node.RightChild = RemoveItem(node.RightChild, value);
            else if (node.LeftChild != null && node.RightChild != null)
            {
                node.Value = GetMinNode(node.RightChild).Value;
                node.RightChild = RemoveItem(node.RightChild, node.Value);
            }
            else if (node.LeftChild != null)
                node = node.LeftChild;
            else if (node.RightChild != null)
                node = node.RightChild;
            else
                node = null;
            return node;

        }

        private TreeNode GetMinNode(TreeNode node)
        {
            if (node.LeftChild == null) return node;

            return GetMinNode(node.LeftChild);
        }
    }

}
