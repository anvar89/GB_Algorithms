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
            Console.WriteLine("Напишите тесты производительности для расчёта дистанции между точками с помощью BenchmarkDotNet. Рекомендуем сгенерировать заранее массив данных, чтобы расчёт шёл с различными значениями, " +
                "но сам код генерации должен происходить вне участка кода, время которого будет тестироваться.");
            BenchmarkRunner.Run<BenchmarkPointClass>(); // Тест расчёта расстояния, где точки - классы
            BenchmarkRunner.Run<BenchmarkPointStruct>(); // Тест расчёта расстояния, где точки - структуры
            /*
             Результаты выполнения на моем ПК
            
            Для проверки пришлось использовать массив из 2 наборов точек, потому что выполнение benchmark занимает очень много времени

            |               Method |             PointD1 |             PointD2 |             PointF1 |             PointF2 |     Mean |     Error |    StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
            |--------------------- |-------------------- |-------------------- |-------------------- |-------------------- |---------:|----------:|----------:|------:|------:|------:|----------:|
            | TestPointClassDouble | (658,051 : 334,203) | (125,404 : 944,649) | (135,722 : 981,418) | (212,621 : 551,894) | 1.378 ns | 0.0458 ns | 0.0383 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (658,051 : 334,203) | (125,404 : 944,649) | (135,722 : 981,418) | (212,621 : 551,894) | 1.214 ns | 0.0621 ns | 0.0715 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (658,051 : 334,203) | (125,404 : 944,649) | (135,722 : 981,418) | (528,289 : 325,864) | 1.370 ns | 0.0616 ns | 0.1245 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (658,051 : 334,203) | (125,404 : 944,649) | (135,722 : 981,418) | (528,289 : 325,864) | 1.274 ns | 0.0635 ns | 0.0891 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (658,051 : 334,203) | (125,404 : 944,649) | (360,329 : 108,526) | (212,621 : 551,894) | 1.304 ns | 0.0630 ns | 0.1052 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (658,051 : 334,203) | (125,404 : 944,649) | (360,329 : 108,526) | (212,621 : 551,894) | 1.246 ns | 0.0631 ns | 0.0675 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (658,051 : 334,203) | (125,404 : 944,649) | (360,329 : 108,526) | (528,289 : 325,864) | 1.253 ns | 0.0626 ns | 0.0670 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (658,051 : 334,203) | (125,404 : 944,649) | (360,329 : 108,526) | (528,289 : 325,864) | 1.242 ns | 0.0640 ns | 0.0810 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (658,051 : 334,203) | (830,247 : 937,331) | (135,722 : 981,418) | (212,621 : 551,894) | 1.292 ns | 0.0485 ns | 0.0430 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (658,051 : 334,203) | (830,247 : 937,331) | (135,722 : 981,418) | (212,621 : 551,894) | 1.262 ns | 0.0608 ns | 0.0651 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (658,051 : 334,203) | (830,247 : 937,331) | (135,722 : 981,418) | (528,289 : 325,864) | 1.330 ns | 0.0649 ns | 0.1048 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (658,051 : 334,203) | (830,247 : 937,331) | (135,722 : 981,418) | (528,289 : 325,864) | 1.323 ns | 0.0618 ns | 0.0846 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (658,051 : 334,203) | (830,247 : 937,331) | (360,329 : 108,526) | (212,621 : 551,894) | 1.262 ns | 0.0637 ns | 0.1010 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (658,051 : 334,203) | (830,247 : 937,331) | (360,329 : 108,526) | (212,621 : 551,894) | 1.300 ns | 0.0641 ns | 0.0999 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (658,051 : 334,203) | (830,247 : 937,331) | (360,329 : 108,526) | (528,289 : 325,864) | 1.324 ns | 0.0641 ns | 0.0599 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (658,051 : 334,203) | (830,247 : 937,331) | (360,329 : 108,526) | (528,289 : 325,864) | 1.771 ns | 0.0728 ns | 0.0681 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (704,119 : 265,311) | (125,404 : 944,649) | (135,722 : 981,418) | (212,621 : 551,894) | 1.206 ns | 0.0625 ns | 0.0585 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (704,119 : 265,311) | (125,404 : 944,649) | (135,722 : 981,418) | (212,621 : 551,894) | 1.278 ns | 0.0626 ns | 0.1029 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (704,119 : 265,311) | (125,404 : 944,649) | (135,722 : 981,418) | (528,289 : 325,864) | 1.325 ns | 0.0605 ns | 0.0786 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (704,119 : 265,311) | (125,404 : 944,649) | (135,722 : 981,418) | (528,289 : 325,864) | 1.302 ns | 0.0648 ns | 0.0694 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (704,119 : 265,311) | (125,404 : 944,649) | (360,329 : 108,526) | (212,621 : 551,894) | 1.228 ns | 0.0626 ns | 0.0769 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (704,119 : 265,311) | (125,404 : 944,649) | (360,329 : 108,526) | (212,621 : 551,894) | 1.230 ns | 0.0587 ns | 0.0803 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (704,119 : 265,311) | (125,404 : 944,649) | (360,329 : 108,526) | (528,289 : 325,864) | 1.303 ns | 0.0642 ns | 0.1221 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (704,119 : 265,311) | (125,404 : 944,649) | (360,329 : 108,526) | (528,289 : 325,864) | 1.277 ns | 0.0635 ns | 0.0594 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (704,119 : 265,311) | (830,247 : 937,331) | (135,722 : 981,418) | (212,621 : 551,894) | 1.341 ns | 0.0637 ns | 0.0806 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (704,119 : 265,311) | (830,247 : 937,331) | (135,722 : 981,418) | (212,621 : 551,894) | 1.181 ns | 0.0574 ns | 0.0990 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (704,119 : 265,311) | (830,247 : 937,331) | (135,722 : 981,418) | (528,289 : 325,864) | 1.114 ns | 0.0505 ns | 0.0448 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (704,119 : 265,311) | (830,247 : 937,331) | (135,722 : 981,418) | (528,289 : 325,864) | 1.639 ns | 0.0597 ns | 0.0559 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (704,119 : 265,311) | (830,247 : 937,331) | (360,329 : 108,526) | (212,621 : 551,894) | 1.236 ns | 0.0512 ns | 0.0502 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (704,119 : 265,311) | (830,247 : 937,331) | (360,329 : 108,526) | (212,621 : 551,894) | 1.084 ns | 0.0795 ns | 0.2332 ns |     - |     - |     - |         - |
            | TestPointClassDouble | (704,119 : 265,311) | (830,247 : 937,331) | (360,329 : 108,526) | (528,289 : 325,864) | 1.034 ns | 0.0436 ns | 0.0408 ns |     - |     - |     - |         - |
            |  TestPointClassFloat | (704,119 : 265,311) | (830,247 : 937,331) | (360,329 : 108,526) | (528,289 : 325,864) | 1.037 ns | 0.0364 ns | 0.0323 ns |     - |     - |     - |         - |


            |                Method |       PointStructD1 |       PointStructD2 |       PointStructF1 |       PointStructF2 |      Mean |     Error |    StdDev |    Median |
            |---------------------- |-------------------- |-------------------- |-------------------- |-------------------- |----------:|----------:|----------:|----------:|
            | TestPointStructDouble | (697,164 : 996,985) | (843,064 : 191,649) | (253,158 : 282,995) | (144,861 : 802,957) | 1.0292 ns | 0.0490 ns | 0.0458 ns | 1.0288 ns |
            |  TestPointStructFloat | (697,164 : 996,985) | (843,064 : 191,649) | (253,158 : 282,995) | (144,861 : 802,957) | 0.0163 ns | 0.0191 ns | 0.0178 ns | 0.0102 ns |
            | TestPointStructDouble | (697,164 : 996,985) | (843,064 : 191,649) | (253,158 : 282,995) | (802,960 : 524,731) | 1.0346 ns | 0.0555 ns | 0.0594 ns | 1.0300 ns |
            |  TestPointStructFloat | (697,164 : 996,985) | (843,064 : 191,649) | (253,158 : 282,995) | (802,960 : 524,731) | 0.0233 ns | 0.0261 ns | 0.0218 ns | 0.0257 ns |
            | TestPointStructDouble | (697,164 : 996,985) | (843,064 : 191,649) | (761,703 : 879,912) | (144,861 : 802,957) | 1.0267 ns | 0.0477 ns | 0.0446 ns | 1.0263 ns |
            |  TestPointStructFloat | (697,164 : 996,985) | (843,064 : 191,649) | (761,703 : 879,912) | (144,861 : 802,957) | 0.0108 ns | 0.0156 ns | 0.0146 ns | 0.0000 ns |
            | TestPointStructDouble | (697,164 : 996,985) | (843,064 : 191,649) | (761,703 : 879,912) | (802,960 : 524,731) | 1.0573 ns | 0.0546 ns | 0.0511 ns | 1.0803 ns |
            |  TestPointStructFloat | (697,164 : 996,985) | (843,064 : 191,649) | (761,703 : 879,912) | (802,960 : 524,731) | 0.0151 ns | 0.0224 ns | 0.0199 ns | 0.0091 ns |
            | TestPointStructDouble | (697,164 : 996,985) | (873,919 : 876,012) | (253,158 : 282,995) | (144,861 : 802,957) | 1.0307 ns | 0.0544 ns | 0.0688 ns | 1.0231 ns |
            |  TestPointStructFloat | (697,164 : 996,985) | (873,919 : 876,012) | (253,158 : 282,995) | (144,861 : 802,957) | 0.0264 ns | 0.0217 ns | 0.0203 ns | 0.0227 ns |
            | TestPointStructDouble | (697,164 : 996,985) | (873,919 : 876,012) | (253,158 : 282,995) | (802,960 : 524,731) | 1.0356 ns | 0.0518 ns | 0.0459 ns | 1.0524 ns |
            |  TestPointStructFloat | (697,164 : 996,985) | (873,919 : 876,012) | (253,158 : 282,995) | (802,960 : 524,731) | 0.0149 ns | 0.0161 ns | 0.0143 ns | 0.0183 ns |
            | TestPointStructDouble | (697,164 : 996,985) | (873,919 : 876,012) | (761,703 : 879,912) | (144,861 : 802,957) | 1.0678 ns | 0.0588 ns | 0.1060 ns | 1.0545 ns |
            |  TestPointStructFloat | (697,164 : 996,985) | (873,919 : 876,012) | (761,703 : 879,912) | (144,861 : 802,957) | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns |
            | TestPointStructDouble | (697,164 : 996,985) | (873,919 : 876,012) | (761,703 : 879,912) | (802,960 : 524,731) | 1.0797 ns | 0.0351 ns | 0.0328 ns | 1.0755 ns |
            |  TestPointStructFloat | (697,164 : 996,985) | (873,919 : 876,012) | (761,703 : 879,912) | (802,960 : 524,731) | 0.0007 ns | 0.0030 ns | 0.0028 ns | 0.0000 ns |
            | TestPointStructDouble | (845,593 : 970,827) | (843,064 : 191,649) | (253,158 : 282,995) | (144,861 : 802,957) | 1.0426 ns | 0.0468 ns | 0.0438 ns | 1.0509 ns |
            |  TestPointStructFloat | (845,593 : 970,827) | (843,064 : 191,649) | (253,158 : 282,995) | (144,861 : 802,957) | 0.0004 ns | 0.0017 ns | 0.0015 ns | 0.0000 ns |
            | TestPointStructDouble | (845,593 : 970,827) | (843,064 : 191,649) | (253,158 : 282,995) | (802,960 : 524,731) | 1.0462 ns | 0.0382 ns | 0.0357 ns | 1.0570 ns |
            |  TestPointStructFloat | (845,593 : 970,827) | (843,064 : 191,649) | (253,158 : 282,995) | (802,960 : 524,731) | 0.0197 ns | 0.0292 ns | 0.0258 ns | 0.0084 ns |
            | TestPointStructDouble | (845,593 : 970,827) | (843,064 : 191,649) | (761,703 : 879,912) | (144,861 : 802,957) | 1.0755 ns | 0.0584 ns | 0.1110 ns | 1.0340 ns |
            |  TestPointStructFloat | (845,593 : 970,827) | (843,064 : 191,649) | (761,703 : 879,912) | (144,861 : 802,957) | 0.0356 ns | 0.0315 ns | 0.0295 ns | 0.0280 ns |
            | TestPointStructDouble | (845,593 : 970,827) | (843,064 : 191,649) | (761,703 : 879,912) | (802,960 : 524,731) | 1.0908 ns | 0.0560 ns | 0.0575 ns | 1.0836 ns |
            |  TestPointStructFloat | (845,593 : 970,827) | (843,064 : 191,649) | (761,703 : 879,912) | (802,960 : 524,731) | 0.0247 ns | 0.0261 ns | 0.0244 ns | 0.0217 ns |
            | TestPointStructDouble | (845,593 : 970,827) | (873,919 : 876,012) | (253,158 : 282,995) | (144,861 : 802,957) | 1.5478 ns | 0.0684 ns | 0.0815 ns | 1.5507 ns |
            |  TestPointStructFloat | (845,593 : 970,827) | (873,919 : 876,012) | (253,158 : 282,995) | (144,861 : 802,957) | 0.0405 ns | 0.0266 ns | 0.0399 ns | 0.0312 ns |
            | TestPointStructDouble | (845,593 : 970,827) | (873,919 : 876,012) | (253,158 : 282,995) | (802,960 : 524,731) | 1.0654 ns | 0.0573 ns | 0.0508 ns | 1.0628 ns |
            |  TestPointStructFloat | (845,593 : 970,827) | (873,919 : 876,012) | (253,158 : 282,995) | (802,960 : 524,731) | 0.0049 ns | 0.0139 ns | 0.0130 ns | 0.0000 ns |
            | TestPointStructDouble | (845,593 : 970,827) | (873,919 : 876,012) | (761,703 : 879,912) | (144,861 : 802,957) | 1.1093 ns | 0.0550 ns | 0.0515 ns | 1.1067 ns |
            |  TestPointStructFloat | (845,593 : 970,827) | (873,919 : 876,012) | (761,703 : 879,912) | (144,861 : 802,957) | 0.0181 ns | 0.0185 ns | 0.0173 ns | 0.0166 ns |
            | TestPointStructDouble | (845,593 : 970,827) | (873,919 : 876,012) | (761,703 : 879,912) | (802,960 : 524,731) | 1.0580 ns | 0.0579 ns | 0.0690 ns | 1.0724 ns |
            |  TestPointStructFloat | (845,593 : 970,827) | (873,919 : 876,012) | (761,703 : 879,912) | (802,960 : 524,731) | 0.0271 ns | 0.0225 ns | 0.0211 ns | 0.0216 ns |
                        */
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
            return $"({X:f3} : {Y:f3})";
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
            return $"({X:f3} : {Y:f3})";
        }
    }

    [MemoryDiagnoser]
    public class BenchmarkPointClass
    {
        static int testCount = 2;

        [ParamsSource(nameof(PointsClassDouble))]
        public PointClass<double> PointD1 { get; set; }

        [ParamsSource(nameof(PointsClassDouble))]
        public PointClass<double> PointD2 { get; set; }

        [ParamsSource(nameof(PointsClassFloat))]
        public PointClass<float> PointF1 { get; set; }

        [ParamsSource(nameof(PointsClassFloat))]
        public PointClass<float> PointF2 { get; set; }

        // Генерирования массивов точек
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
            PointDistanceD(PointD1, PointD2);
        }

        [Benchmark]
        public void TestPointClassFloat()
        {
            PointDistanceF(PointF1, PointF2);
        }
    }


    public class BenchmarkPointStruct
    {
        static int testCount = 2;

        [ParamsSource(nameof(PointStructDouble))]
        public PointStruct<double> PointStructD1 { get; set; }

        [ParamsSource(nameof(PointStructDouble))]
        public PointStruct<double> PointStructD2 { get; set; }

        [ParamsSource(nameof(PointStructFloat))]
        public PointStruct<float> PointStructF1 { get; set; }

        [ParamsSource(nameof(PointStructFloat))]
        public PointStruct<float> PointStructF2 { get; set; }

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
