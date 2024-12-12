using System;
using System.Diagnostics;
using NUnit.Framework;

namespace StructBenchmarking
{
    public interface ITask
    {
        void Run();
    }

    public interface IBenchmark
    {
        double MeasureDurationInMs(ITask task, int repetitionCount);
    }

    public class Benchmark : IBenchmark
    {
        public double MeasureDurationInMs(ITask task, int repetitionCount)
        {
            // Прогревочный запуск
            task.Run();

            // Принудительная очистка сборщика мусора
            GC.Collect();
            GC.WaitForPendingFinalizers();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < repetitionCount; i++)
            {
                task.Run();
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds / (double)repetitionCount;
        }
    }

    public class StringTask_StringBuilder : ITask
    {
        public void Run()
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                sb.Append('a');
            }
            sb.ToString();
        }
    }

    public class StringTask_StringConstructor : ITask
    {
        public void Run()
        {
            new string('a', 10000);
        }
    }

    [TestFixture]
    public class RealBenchmarkUsageSample
    {
        [Test]
        public void StringConstructorFasterThanStringBuilder()
        {
            var benchmark = new Benchmark();
            var stringBuilderTask = new StringTask_StringBuilder();
            var stringConstructorTask = new StringTask_StringConstructor();

            // Подбираем количество повторений экспериментально для времени около секунды
            int repetitionCount = 1000; // Настройте это значение для своего компьютера


            double stringBuilderTime = benchmark.MeasureDurationInMs(stringBuilderTask, repetitionCount);
            double stringConstructorTime = benchmark.MeasureDurationInMs(stringConstructorTask, repetitionCount);

            Console.WriteLine($"StringBuilder time: {stringBuilderTime} ms");
            Console.WriteLine($"String constructor time: {stringConstructorTime} ms");

            Assert.Less(stringConstructorTime, stringBuilderTime);
        }
    }
}
