using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача 2. Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска. Дерево должно быть сбалансированным (это требование не обязательно).
            //    Также напишите метод вывода в консоль дерева, чтобы увидеть, насколько корректно работает ваша реализация. 

            Random rnd = new Random();
            var bTree = new BinaryTree();

            for (int i = 0; i < 20; i++)
            {
                bTree.AddItem(rnd.Next(1000));
            }



            while (true)
            {
                bTree.PrintTree();

                Console.WriteLine();
                Console.WriteLine("<F1> - добавить новый случайный элемент");
                Console.WriteLine("<F2> - добавить элемент с пользовательским значением");
                Console.WriteLine("<F5> - удалить элемент");
                Console.WriteLine("<F10> - выход");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.F1:
                        bTree.AddItem(rnd.Next(1000));
                        break;

                    case ConsoleKey.F2:
                        while (true)
                        {
                            Console.Write("Введите число: ");
                            string s = Console.ReadLine();

                            if (int.TryParse(s, out int value))
                            {
                                bTree.AddItem(value);
                                break;
                            }
                            else
                                Console.WriteLine("Нужно ввести число!");
                        }
                        break;
                    case ConsoleKey.F5:
                        while (true)
                        {
                            Console.Write("Введите значение узла, который нужно удалить: ");
                            string s = Console.ReadLine();

                            if (int.TryParse(s, out int value))
                            {
                                bTree.RemoveItem(value);
                                break;
                            }
                            else
                                Console.WriteLine("Нужно ввести число!");
                        }
                        break;
                    case ConsoleKey.F10:
                        return;

                }
            }
        }
    }

    public class BinaryTree : ITree
    {
        private TreeNode root;

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
            Console.Clear();

            string line = string.Empty;
            printAltTree(root, line);

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

        /// <summary>
        /// Удаляет элемент с указанным значением
        /// </summary>
        /// <param name="value"></param>
        public void RemoveItem(int value)
        {
            //var nodeForRemove = GetNodeByValue(value);
            //var parent = GetParent(root, value);

            //if (nodeForRemove == null) return;

            //if (nodeForRemove.RightChild == null)
            //{
            //    // У удаляемого нода нет "правых" потомков

            //    if (nodeForRemove.LeftChild == null) return;

            //    if (nodeForRemove != root)
            //    {
            //        if (parent.LeftChild != null && parent.LeftChild.Value == value)
            //            parent.LeftChild = nodeForRemove.LeftChild;

            //        if (parent.RightChild != null && parent.RightChild.Value == value)
            //            parent.RightChild = nodeForRemove.LeftChild;
            //    }
            //    else
            //    {
            //        // Удаляемый нод является корневым (root)
            //        root = nodeForRemove.LeftChild;
            //    }
            //}
            //else
            //{
            //    // Есть "правые" потомки. Поиск подходящего нода для замены удаляемого нода
            //    if (nodeForRemove.LeftChild == null)
            //    {
            //        // У удаляемого нода есть только "правый" потомок

            //        if (nodeForRemove != root)
            //        {
            //            // Удаляемый нод является корневым (root)
            //            root = nodeForRemove.RightChild;
            //            return;
            //        }

            //        if (parent.LeftChild != null && parent.LeftChild.Value == value)
            //            parent.LeftChild = nodeForRemove.RightChild;

            //        if (parent.RightChild != null && parent.RightChild.Value == value)
            //            parent.RightChild = nodeForRemove.RightChild;
            //    }
            //    else
            //    {
            //        // У удаляемого нода есть и "левый" и "правый" потомок
            //        TreeNode minNode = GetMinNode(nodeForRemove.RightChild);
            //        TreeNode parentOfMinNode = GetParent(root, minNode.Value);
            //        if (parent != null)
            //        {
            //            if (parent.LeftChild != null && parent.LeftChild.Value == value)
            //                parent.LeftChild = minNode;

            //            if (parent.RightChild != null && parent.RightChild.Value == value)
            //                parent.RightChild = minNode;
            //        }
            //        parentOfMinNode.LeftChild = null;

            //        minNode.LeftChild = nodeForRemove.LeftChild;
            //        minNode.RightChild = nodeForRemove.RightChild;
            //    }
            //}

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
