using System;
using System.Collections.Generic;

namespace Lesson4_Task2
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
                //bTree.AddItem(i);
            }

            while (true)
            {
                bTree.PrintTree();

                Console.WriteLine();
                Console.WriteLine("<F1> - добавить новый случайный элемент");
                Console.WriteLine("<F2> - добавить элемент с пользовательским значением");
                Console.WriteLine("<F3> - изменить вид отображения дерева");
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
                    case ConsoleKey.F3:
                        bTree.UseBTreePrinter ^= true; ;
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

}
