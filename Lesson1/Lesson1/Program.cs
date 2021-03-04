using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace Lesson1
{
    //class Program
    //{
    //    public static PointClass<double>[,] pointsClassD;
    //    public static PointStruct<double>[,] pointsStructD;
    //    public static PointClass<float>[,] pointsClassF;
    //    public static PointStruct<float>[,] pointsStructF;

    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Задача: Напишите тесты производительности для расчёта дистанции между точками с помощью BenchmarkDotNet. " +
    //            "Рекомендуем сгенерировать заранее массив данных, чтобы расчёт шёл с различными значениями, но сам код генерации должен ," +
    //            "происходить вне участка кода, время которого будет тестироваться.");
    //        // Генерирование массивов для теста
    //        int count = 1000;
    //        pointsClassD = new PointClass<double>[count, 2];
    //        pointsStructD = new PointStruct<double>[count, 2];
    //        pointsClassF = new PointClass<float>[count, 2];
    //        pointsStructF = new PointStruct<float>[count, 2];

    //        Random rnd = new Random();

    //        for (int i = 0; i < count; i++)
    //        {
    //            pointsClassD[i, 0].X = pointsStructD[i, 0].X = rnd.NextDouble() * 1000;
    //            pointsClassD[i, 0].Y = pointsStructD[i, 0].Y = rnd.NextDouble() * 1000;

    //            pointsClassF[i, 0].X = pointsStructF[i, 0].X = (float)pointsClassD[i, 0].X;
    //            pointsClassF[i, 0].Y = pointsStructF[i, 0].Y = (float)pointsClassD[i, 0].Y;
    //        }

    //        //foreach (var item in arrayFloat)
    //        //{
    //        //    Console.Write($"{item} ");
    //        //}
    //        //Console.WriteLine();
    //        //foreach (var item in arrayDouble)
    //        //{
    //        //    Console.Write($"{item} ");
    //        //}

    //        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    //        Console.ReadKey();
    //    }
    //}
    //public class PointClass<T>
    //{
    //    public T X;
    //    public T Y;
    //}

    //public struct PointStruct<T>
    //{
    //    public T X;
    //    public T Y;
    //}
    //public class BenchmarkClass
    //{

    //    #region Тестируемые методы


    //    public static float PointDistanceF(PointStruct<float> pointOne, PointStruct<float> pointTwo)
    //    {
    //        float x = pointOne.X - pointTwo.X;
    //        float y = pointOne.Y - pointTwo.Y;

    //        return MathF.Sqrt((x * x) + (y * y));
    //    }

    //    public static double PointDistanceD(PointStruct<double> pointOne, PointStruct<double> pointTwo)
    //    {
    //        double x = pointOne.X - pointTwo.X;
    //        double y = pointOne.Y - pointTwo.Y;

    //        return Math.Sqrt((x * x) + (y * y));
    //    }

    //    public static float PointDistanceF(PointClass<float> pointOne, PointClass<float> pointTwo)
    //    {
    //        float x = pointOne.X - pointTwo.X;
    //        float y = pointOne.Y - pointTwo.Y;

    //        return MathF.Sqrt((x * x) + (y * y));
    //    }

    //    public static double PointDistanceD(PointClass<double> pointOne, PointClass<double> pointTwo)
    //    {
    //        double x = pointOne.X - pointTwo.X;
    //        double y = pointOne.Y - pointTwo.Y;

    //        return Math.Sqrt((x * x) + (y * y));
    //    }
    //    #endregion

    //    [Benchmark]
    //    public void TestCalculateDistanceClassF()
    //    {
    //        for (int i = 0; i < 10000; i++)
    //        {
    //            //PointDistanceF(Program.pointsClassF[i, 0], Program.pointsClassF[i, 1]);
    //            int o = i + i;
    //        }
    //    }

    //}


    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkClass>();
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class PointClass<T>
    {
        public T X;
        public T Y;

        public PointClass(T x, T y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public struct PointStruct<T>
    {
        public T X;
        public T Y;

        public PointStruct(T x, T y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    [MemoryDiagnoser]
    public class BenchmarkClass
    {
        public PointClass<double> PointD1 { get; set; }
        public PointClass<double> PointD2 { get; set; }

        public PointClass<float> PointF1 { get; set; }
        public PointClass<float> PointF2 { get; set; }

        public PointStruct<double> PointStructD1 { get; set; }
        public PointStruct<double> PointStructD2 { get; set; }

        public PointStruct<float> PointStructF1 { get; set; }
        public PointStruct<float> PointStructF2 { get; set; }

        public static IEnumerable<double> 
        public static float PointDistanceF(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;

            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceD(PointStruct<double> pointOne, PointStruct<double> pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;

            return Math.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceF(PointClass<float> pointOne, PointClass<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;

            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceD(PointClass<double> pointOne, PointClass<double> pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;

            return Math.Sqrt((x * x) + (y * y));
        }

        





        [Benchmark]
        public void TestPointClassDouble()
        {
            PointDistanceD(new PointClass<double>(0.123, 999.999), new PointClass<double>(15.2, 1.44));
        }

        [Benchmark]
        public void TestPointClassFloat()
        {
            PointDistanceF(new PointClass<float>(0.123f, 999.999f), new PointClass<float>(15.2f, 1.44f));
        }
    }

}
