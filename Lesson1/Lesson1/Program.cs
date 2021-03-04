using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace Lesson1
{

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
        static int testCount = 2;

        //[ParamsSource(nameof(PointsClassDouble))]
        //public PointClass<double> PointD1 { get; set; }

        //[ParamsSource(nameof(PointsClassDouble))]
        //public PointClass<double> PointD2 { get; set; }

        //[ParamsSource(nameof(PointsClassFloat))]
        //public PointClass<float> PointF1 { get; set; }

        //[ParamsSource(nameof(PointsClassFloat))]
        //public PointClass<float> PointF2 { get; set; }

        //[ParamsSource(nameof(PointStructDouble))]
        //public PointStruct<double> PointStructD1 { get; set; }

        //[ParamsSource(nameof(PointStructDouble))]
        //public PointStruct<double> PointStructD2 { get; set; }

        //[ParamsSource(nameof(PointStructFloat))]
        //public PointStruct<float> PointStructF1 { get; set; }

        //[ParamsSource(nameof(PointStructFloat))]
        //public PointStruct<float> PointStructF2 { get; set; }

        [Params(10)]
        public PointClass<double> PointD1 { get; set; }

        [Params(11)]
        public PointClass<double> PointD2 { get; set; }

        [Params(12)] 
        public PointClass<float> PointF1 { get; set; }

        [Params(13)]
        public PointClass<float> PointF2 { get; set; }

        [Params(14)]
        public PointStruct<double> PointStructD1 { get; set; }

        [Params(15)]
        public PointStruct<double> PointStructD2 { get; set; }

        [Params(165)]
        public PointStruct<float> PointStructF1 { get; set; }

        [Params(151)]
        public PointStruct<float> PointStructF2 { get; set; }

        public static IEnumerable<PointClass<double>> PointsClassDouble()
        {
            Random rnd = new Random();
            PointClass<double>[] result = new PointClass<double>[testCount];
            for (int i = 0; i < testCount; i++)
            {
                result[i] = new PointClass<double>(rnd.NextDouble() * 1000.0, rnd.NextDouble() * 1000.0);
            }
            return result;
        }

        public static IEnumerable<PointClass<float>> PointsClassFloat()
        {
            Random rnd = new Random();
            PointClass<float>[] result = new PointClass<float>[testCount];
            for (int i = 0; i < testCount; i++)
            {
                result[i] = new PointClass<float>((float)(rnd.NextDouble() * 1000.0), (float)(rnd.NextDouble() * 1000.0));
            }
            return result;
        }

        public static IEnumerable<PointStruct<double>> PointStructDouble()
        {
            Random rnd = new Random();
            PointStruct<double>[] result = new PointStruct<double>[testCount];
            for (int i = 0; i < testCount; i++)
            {
                result[i] = new PointStruct<double>(rnd.NextDouble() * 1000.0, rnd.NextDouble() * 1000.0);
            }
            return result;
        }

        public static IEnumerable<PointStruct<float>> PointStructFloat()
        {
            Random rnd = new Random();
            PointStruct<float>[] result = new PointStruct<float>[testCount];
            for (int i = 0; i < testCount; i++)
            {
                result[i] = new PointStruct<float>((float)(rnd.NextDouble() * 1000.0), (float)(rnd.NextDouble() * 1000.0));
            }
            return result;
        }



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

        public static int TestOfTests() => 2 * 2;





        [Benchmark]
        public void TestPointClassDouble()
        {
            PointDistanceD(PointD1, PointD2);
            //TestOfTests();

        }

        [Benchmark]
        public void TestPointClassFloat()
        {
            PointDistanceF(PointF1, PointF2);
        }

        [Benchmark]
        public void TestPointStructDouble()
        {
            PointDistanceD(PointStructD1, PointStructD2);
        }

        [Benchmark]
        public void TestPointStructFloat()
        {
            PointDistanceF(PointStructF1, PointStructF2);
        }

    }

}
