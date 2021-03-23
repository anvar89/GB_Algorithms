using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Дописать реализацию Bucketsort до возможности сортировки больших массивов из файла (External sort)");
            CreateTestFile(15);
            ExternalSort("IntNumbers.txt");
        }

        static void CreateTestFile(int n)
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                sb.Append(rnd.Next(100).ToString() + "\n");
            }
            File.WriteAllText("IntNumbers.txt", sb.ToString());
        }

        static void ExternalSort(string path)
        {
            int n = 5; // Количество строк файла для одного блока
            int blockCount = 0; // Счётчик количества блоков
            bool endOfFile = false;

            while(!endOfFile)
            {
                StreamReader sr;
                try
                {
                    sr = new StreamReader(path, System.Text.Encoding.Default);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Неудалось выполнить сортировку: " + e.Message);
                    return;
                }


                // Переход к нужному блоку: пропускаем все блоки, обработанные ранее
                for (int i = 0; i < n * blockCount; i++)
                {
                    sr.ReadLine();
                }

                List<int> currentBlockList = new List<int>();
                // Чтение и парсинг нужного блока в массив
                for (int i = 0; i < n; i++)
                {
                    string s = sr.ReadLine();
                    if (s is null)
                    {
                        endOfFile = true;
                        break;
                    }

                    if (int.TryParse(s.Trim(), out int num))
                        currentBlockList.Add(num);
                    else
                    {
                        Console.WriteLine("Неудалось выполнить сортировку: в файле должны содержаться только числа");
                        return;
                    }
                }
                sr.Close();

                int[] currentBlock = currentBlockList.ToArray();
                Task1.Program.BucketSort(currentBlock);

                // Запись отсортированного блока во временный файл
                FileInfo fi = new FileInfo("tmp_block_" + blockCount++  +".txt");
                StreamWriter sw = fi.CreateText();
                foreach (int item in currentBlock)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }

            // Слияние блоков в новый массив
            FileInfo fiFinal = new FileInfo(path + "_sorted" + ".txt");
            StreamWriter swFinal = fiFinal.CreateText();

            StreamReader[] srFinal = new StreamReader[blockCount];
            string[] currentValueFile = new string[blockCount];

            for (int i = 0; i < srFinal.Length; i++)
            {
                srFinal[i] = new StreamReader("tmp_block_" + i + ".txt");

                string s = srFinal[i].ReadLine();

                if (s is null) continue;
                currentValueFile[i] = s;
            }

            while (true)
            {
                // проверка: прочтены ли все строки всех файлов
                int min = 0;
                bool endOfAllFiles = true;
                for (int i = 0; i < currentValueFile.Length; i++)
                {
                    if (currentValueFile[i] is null) continue;

                    endOfAllFiles = false;
                    min = int.Parse(currentValueFile[i]);
                    break;
                }

                if (endOfAllFiles) break; // выход из цикла

                // поиск минимального числа среди текущих
                int indexOfmin = 0;
                for (int i = 0; i < currentValueFile.Length; i++)
                {
                    if (currentValueFile[i] is null) continue;

                    int tmp = int.Parse(currentValueFile[i]);
                    if (tmp < min)
                    {

                        min = tmp;
                        indexOfmin = i;
                    }
                }

                swFinal.WriteLine(currentValueFile[indexOfmin]);
                currentValueFile[indexOfmin] = srFinal[indexOfmin].ReadLine();
            }

            swFinal.Close();
            for (int i = 0; i < blockCount; i++)
            {
                srFinal[i].Close();
                File.Delete("tmp_block_" + i + ".txt");
            }
        }
    }
}

