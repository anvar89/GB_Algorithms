using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 3. Реализуйте функцию вычисления числа Фибоначчи");
            Console.WriteLine("Тест функции с использованием рекурсии");
            Task1.Program.TestFunction<int, int>(0, 0, FibonaciNumberRecursive);
            Task1.Program.TestFunction<int, int>(5, 5, FibonaciNumberRecursive);
            Task1.Program.TestFunction<int, int>(10, 55, FibonaciNumberRecursive);

            Console.WriteLine("Тест функции с использованием цикла");
            Task1.Program.TestFunction<int, int>(0, 0, FibonaciNumberLoop);
            Task1.Program.TestFunction<int, int>(5, 5, FibonaciNumberLoop);
            Task1.Program.TestFunction<int, int>(10, 55, FibonaciNumberLoop);
        }

        static int FibonaciNumberRecursive(int number)
        {
            if (number <= 0) return 0;
            if (number == 1) return 1;

            return FibonaciNumberRecursive(number - 2) + FibonaciNumberRecursive(number - 1);
        }

        static int FibonaciNumberLoop(int number)
        {
            int result = 0;
            int nextNumber = 1;
            int tmp;

            for (int i = 0; i < number; i++)
            {
                tmp = result;
                result = nextNumber;
                nextNumber += tmp;
            }

            return result;
        }
    }
}
