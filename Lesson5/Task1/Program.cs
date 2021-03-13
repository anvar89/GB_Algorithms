using System;
using System.Collections.Generic;
using Lesson4_Task2;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Реализуйте DFS и BFS для дерева с выводом каждого шага в консоль. ");

            var testTree1 = new BinaryTree() { UseBTreePrinter = true };
            var testTree2 = new BinaryTree() { UseBTreePrinter = true };
            var testTree3 = new BinaryTree() { UseBTreePrinter = true };

            int[] array1 = new[] { 879, 585, 486, 897, 785, 892, 102, 1, 652, 985, 2, 600, 925, 12 };
            int[] array2 = new[] { 9, 8, 7, 6, 3, 5, 2, 1, 4, 10, 16, 19, 12, 14, 13, 15 };
            int[] array3 = new[] { 1000, 950, 1050, 975, 925, 1075, 1025 };

            foreach (var e in array1)
            {
                testTree1.AddItem(e);
            }

            foreach (var e in array2)
            {
                testTree2.AddItem(e);
            }

            foreach (var e in array3)
            {
                testTree3.AddItem(e);
            }

            Console.WriteLine("Тест №1");
            testTree1.PrintTree();

            Console.Write("BFS: ");
            printArray(GetArrayBFS(testTree1.GetRoot()));

            Console.WriteLine();

            Console.Write("DFS: ");
            printArray(GetArrayDFS(testTree1.GetRoot()));
            Console.WriteLine();

            Console.WriteLine("Тест №2");
            testTree2.PrintTree();
            Console.Write("BFS: ");

            printArray(GetArrayBFS(testTree2.GetRoot()));

            Console.WriteLine();

            Console.Write("DFS: ");
            printArray(GetArrayDFS(testTree2.GetRoot()));
            Console.WriteLine();

            Console.WriteLine("Тест №3");
            testTree3.PrintTree();

            Console.Write("BFS: ");
            printArray(GetArrayBFS(testTree3.GetRoot()));

            Console.WriteLine();

            Console.Write("DFS: ");
            printArray(GetArrayDFS(testTree3.GetRoot()));
        }

        public static void printArray(TreeNode[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i].Value);
                if (i != arr.Length - 1) Console.Write("->");
            }
        } 

        public static TreeNode[] GetArrayBFS(TreeNode node)
        {
            var bufer = new Queue<TreeNode>();
            var returnArray = new List<TreeNode>();
            bufer.Enqueue(node);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                if (element.LeftChild != null)
                    bufer.Enqueue(element.LeftChild);

                if (element.RightChild != null)
                    bufer.Enqueue(element.RightChild);
            }

            return returnArray.ToArray();
        }

        public static TreeNode[] GetArrayDFS(TreeNode node)
        {
            var stack = new Stack<TreeNode>();
            var returnArray = new List<TreeNode>();

            stack.Push(node);

            while (stack.Count > 0)
            {
                var element = stack.Pop();
                returnArray.Add(element);
                if (element.RightChild != null) stack.Push(element.RightChild);
                if (element.LeftChild != null) stack.Push(element.LeftChild);

            }

            return returnArray.ToArray();
        }
    }
}
