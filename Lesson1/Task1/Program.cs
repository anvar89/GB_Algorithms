using System;

namespace Task1
{
    public static class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Задача 1. Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.");

            string prime = "Простое";
            string notPrime = "Не простое";

            TestFunction<string, int>(2, prime, PrimeNumberCheck);
            TestFunction<string, int>(3, prime, PrimeNumberCheck);
            TestFunction<string, int>(101, prime, PrimeNumberCheck);
            TestFunction<string, int>(30, notPrime, PrimeNumberCheck);
            TestFunction<string, int>(-30, notPrime, PrimeNumberCheck);
            TestFunction<string, int>(1, notPrime, PrimeNumberCheck);
            TestFunction<string, int>(0, notPrime, PrimeNumberCheck);

            Console.ReadKey();
        }

        static string PrimeNumberCheck(int number)
        {
            int d = 0;
            int i = 2;

            while(i < number)
            {
                if (number % i == 0) d++;

                i++;
            }

            return d == 0? "Простое" : "Не простое";
        }

        // Метод для тестирования
        public static void TestFunction<T1, T2>(T2 input, T1 expectedResult, func<T1, T2> testedFunc)
        {
            T1 result = testedFunc(input);
            
            Console.WriteLine($"Подаём на вход: {input}. Ожидаемый результат: {expectedResult}");
            Console.WriteLine($"Результат вашей функции: {result}");
            Console.WriteLine(result.Equals(expectedResult) ? "Тест пройден" : "Тест не пройден");
            Console.WriteLine();
        }


        public delegate T1 func<T1, T2>(T2 arg);
    }
}
