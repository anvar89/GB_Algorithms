using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 2. Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска. Дерево должно быть сбалансированным (это требование не обязательно)." +
                " Также напишите метод вывода в консоль дерева, чтобы увидеть, насколько корректно работает ваша реализация. ");

            var bTree = new BinaryTree();

            bTree.AddItem(10);
            bTree.AddItem(11);
            bTree.AddItem(8);


            Console.ReadKey();

        }
    }

    public class BinaryTree : ITree
    {
        private TreeNode root;

        public int Depth { get; private set; }

        public void AddItem(int value)
        {
            if (root == null)
            {
                Depth = 1;
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
                    if (node.RightChild == null) Depth++;

                    return;
                }

                AddItemAfterNode(value, node.LeftChild);
            }

            if (value > node.Value) //правая нода
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new TreeNode() { Value = value };
                    if (node.LeftChild == null) Depth++;
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
            throw new NotImplementedException();
        }

        public void RemoveItem(int value)
        {
            throw new NotImplementedException();
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
    }

    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }


                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }
    }

    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }

}
