using System;

namespace Lesson1
{
    class Program
    {
        static int testCaseNumber;

        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1. Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.");

            TestPrimeNumberCheck(2, true);
            TestPrimeNumberCheck(3, true);
            TestPrimeNumberCheck(101, true);
            TestPrimeNumberCheck(10, false);
            TestPrimeNumberCheck(-20, false);
            TestPrimeNumberCheck(1, false);
            TestPrimeNumberCheck(0, false);
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

        static void TestPrimeNumberCheck(int testNumber, bool expectedResult)
        {
            string expectedOutput = expectedResult ? "Простое" : "Не простое";
            string output = PrimeNumberCheck(testNumber);

            Console.WriteLine($"TestCase #{++testCaseNumber}");
            Console.WriteLine($"Подаём на вход: {testNumber}. Ожидаемый результат: {expectedOutput}");
            Console.WriteLine($"Результат вашей функции: {output}");
            Console.WriteLine(expectedOutput == output? "Тест пройден" : "Тест не пройден");
            Console.WriteLine();
        }
    }
}
