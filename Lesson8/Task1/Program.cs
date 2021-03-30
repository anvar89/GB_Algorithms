using System;
using System.Collections.Generic;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача1. Реализовать Bucketsort, проверить корректность работы.");

            Random rnd = new Random();
            int[] arr = new int[5];

            Console.WriteLine("Генерирование случайного массива:");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1000);
                Console.Write(arr[i].ToString().PadLeft(4) + " ");
            }

            BucketSort(arr);

            Console.WriteLine();
            Console.WriteLine("Sorted array:");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i].ToString().PadLeft(4) + " ");

            }
        }

        public static void BucketSort(int[] array)
        {
            if (array.Length < 2) return;
            if (array.Length < 8)
                Array.Sort(array);
            else
            {

                int nBucket = array.Length / 8; // количество блоков, на которые будет разделяться массив
                int min = array[0];
                int max = array[0];

                for (int i = 0; i < array.Length; i++)
                {
                    min = Min(min, array[i]);
                    max = Max(max, array[i]);
                }
                // определение длины итервалов
                int interval = (max - min) / nBucket;

                List<int>[] bucket = new List<int>[nBucket];
                for (int i = 0; i < bucket.Length; i++)
                {
                    bucket[i] = new List<int>();
                }

                //Распределение массива по bucket-ам
                foreach (int item in array)
                {
                    int n = (item / interval) >= bucket.Length ? bucket.Length - 1 : item / interval;
                    bucket[n].Add(item);
                }

                // Сортировка элементов внутри bucket-ов
                for (int i = 0; i < bucket.Length; i++)
                {
                    bucket[i].Sort();
                }

                // Слияние
                int ind = 0;
                for (int i = 0; i < nBucket; i++)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        array[ind++] = bucket[i][j];
                    }
                }
            }
        }

        static int Max(int num1, int num2) => num1 > num2 ? num1 : num2;
        static int Min(int num1, int num2) => num1 < num2 ? num1 : num2;

    }
}

