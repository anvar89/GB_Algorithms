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

            var bTree = new BinaryTree();

            while (true)
            {
                bTree.PrintTree();

                //Console.WriteLine();
                //Console.WriteLine("<F1> - добавить новый случайный элемент");
                //Console.WriteLine("<F2> - добавить элемент с пользовательским значением");
                //Console.WriteLine("<F3> - удалить элемент");
                //Console.WriteLine("<F10> - выход");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.F1:
                        Random rnd = new Random();
                        bTree.AddItem(rnd.Next(1000));
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
            Console.Clear();

            //printNode(root, 0, 0, Console.WindowWidth);
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

        private void printNode(TreeNode node, int vertCoordinate, int horCoordStart, int horCoordEnd)
        {
            if (node == null) return;

            // Вывод на экран нода
            string nodeText = $"({node.Value})";
            Console.SetCursorPosition(horCoordStart + (horCoordEnd - horCoordStart) / 2 - nodeText.Length / 2, vertCoordinate++);
            Console.Write(nodeText);

            // Отрисовка линий ┌─┴─┐ ┌─┘ └─┐
            if (node.LeftChild != null || node.RightChild != null)
            {
                if (node.LeftChild != null && node.RightChild != null)  // У нода есть оба потомка
                {
                    Console.SetCursorPosition(horCoordStart + (horCoordEnd - horCoordStart) / 4, vertCoordinate++);
                    String line = new string('─', horCoordStart + (horCoordEnd - horCoordStart) / 4 - 1);
                    Console.Write("┌" + line + "┴" + line + "┐");
                }

                if (node.LeftChild != null && node.RightChild == null)  // есть только левый потомок
                {
                    Console.SetCursorPosition(horCoordStart + (horCoordEnd - horCoordStart) / 4, vertCoordinate++);
                    String line = new string('─', (horCoordEnd - horCoordStart) / 4 - 1);
                    Console.Write("┌" + line + "┘");
                }

                if (node.LeftChild == null && node.RightChild != null)  // есть только правый потомок
                {
                    Console.SetCursorPosition(horCoordStart + (horCoordEnd - horCoordStart) / 2, vertCoordinate++);
                    String line = new string('─', (horCoordEnd - horCoordStart) / 4 - 1);
                    Console.Write("└" + line + "┐");
                }
            }

            printNode(node.LeftChild, vertCoordinate, horCoordStart, (horCoordEnd - horCoordStart) / 2);
            printNode(node.RightChild, vertCoordinate, horCoordStart + (horCoordEnd - horCoordStart) / 2, horCoordEnd);
        }

        public void RemoveItem(int value)
        {
            var nodeForRemove = this.GetNodeByValue(value);
            var parent = GetParentOfNode(root, value);

            if (nodeForRemove == null) return;

            if (nodeForRemove.RightChild == null)
            {
                // У удаляемого нода нет "правых" потомков

                if (nodeForRemove.LeftChild == null) return;

                if (parent != null)
                {
                    if (parent.LeftChild.Value == value)
                        parent.LeftChild = nodeForRemove.LeftChild;

                    if (parent.RightChild.Value == value)
                        parent.RightChild = nodeForRemove.LeftChild;
                }
            }
            else
            {
               // Есть "правые" потомки. Поиск подходящего нода для замены удаляемого нода
            }
        }

        private TreeNode GetParentOfNode(TreeNode node, int value)
        {
            if (node == null) return null;

            if (node.Value < value)
            {
                if (node.LeftChild.Value == value) return node;
                else return GetParentOfNode(node.LeftChild, value);
            }

            if (node.Value > value)
            {
                if (node.RightChild.Value == value) return node;
                else return GetParentOfNode(node.RightChild, value);
            }

            return null;
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
