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
