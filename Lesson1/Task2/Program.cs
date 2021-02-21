using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 2. Посчитайте сложность функции");
        }


        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //  O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++)// O(N)
                    {
                        int y = 0; 

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y; 
                    }
                }
            }
            
            return sum;
        }

        // Вывод о асимптотической сложности: Согласно методичке всеми константами можно пренебречь, поэтому асимптотичкая сложность равна: О(1 + N * N * (6 * N) + 1) = O(N^3) 
    }
}
