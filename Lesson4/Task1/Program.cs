using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1. Заполните массив и HashSet случайными строками, не менее 10 000 строк. Строки можно сгенерировать. Потом выполните замер производительности " +
                "проверки наличия строки в массиве и HashSet. Выложите код и результат замеров.");

            BenchmarkRunner.Run<BenchmarkTest>();
            Console.ReadKey();
            /*
             * Результат выполнения на моём ПК
            |      Method | value |         Mean |      Error |     StdDev |
            |------------ |------ |-------------:|-----------:|-----------:|
            | TestHashset | qazxc |     28.59 ns |   0.260 ns |   0.217 ns |
            |   TestArray | qazxc | 37,885.18 ns | 482.097 ns | 450.954 ns |
            */
        }
    }

    public class BenchmarkTest
    {
        HashSet<string> set;
        string[] array;

        [Params("qazxc")]
        public string value;


        public BenchmarkTest()
        {
            set = new HashSet<string>();
            array = new string[10000];


            for (int i = 0; i < 10000; i++)
            {
                array[i] = GetRandomString(10);
                set.Add(array[i]);
            }
        }

        public static string GetRandomString(int length)
        {
            Random rnd = new Random();

            string symbols = "qwertyuiopasdfghjklzxcvbnm1234567890";
            char[] charArray = new char[length];
            for (int i = 0; i < length; i++)
            {
                charArray[i] = symbols[rnd.Next(symbols.Length)];
            }

            return new string(charArray);
        }

        [Benchmark]
        public bool TestHashset() => set.Contains(value);


        [Benchmark]
        public bool TestArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value) return true;
            }
            return false;
        }

    }
}
