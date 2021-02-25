using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 2. Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и проверить работоспособность функции.");

            testBinSearch(32, 0);
            testBinSearch(256, 0);
            testBinSearch(1024, 0);
            testBinSearch(2048, 0);

            Console.WriteLine("В тестах выбран наиболее долгий вариант поиска - поиск граничных значений массива. Вывод: размер массива = 2^N, где N - максимальное число итераций, поэтому сложность метода O(log(N))");

            Console.ReadKey();
        }

        public static void testBinSearch(int arrayDimension, int numberForSearch)
        {
            Console.WriteLine($"Тест: поиск в массиве на {arrayDimension} элементов числа {numberForSearch}");
            int[] array = new int[arrayDimension];

            for (int i = 0; i < arrayDimension; i++)
            {
                array[i] = i;
            }
            
            BinarySearch(array, numberForSearch, out int counter);
            Console.WriteLine($"Поиск числа {numberForSearch} выполнен за {counter} итераций");
            Console.WriteLine();
        }


        // метод бинарного поиска с счётчиком итераций
        public static int BinarySearch(int[] inputArray, int searchValue, out int stepCounter)
        {
            stepCounter = 0;
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                stepCounter++;
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
