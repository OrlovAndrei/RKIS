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

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Stopwatch stopwatch = new Stopwatch();
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
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                sb.Append('a');
            }
            sb.ToString(); // Очень важно! Без этого результата не будет корректного
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
            IBenchmark benchmark = new Benchmark();
            ITask stringBuilderTask = new StringTask_StringBuilder();
            ITask stringConstructorTask = new StringTask_StringConstructor();

            // НАСТРОЙТЕ ЭТО ЗНАЧЕНИЕ! Найдите оптимальное для вашего компьютера.
            int repetitionCount = 1000; // Примерное значение, скорее всего понадобится корректировка

            double stringBuilderTime = benchmark.MeasureDurationInMs(stringBuilderTask, repetitionCount);
            double stringConstructorTime = benchmark.MeasureDurationInMs(stringConstructorTask, repetitionCount);

            Console.WriteLine($"StringBuilder time: {stringBuilderTime} ms");
            Console.WriteLine($"String constructor time: {stringConstructorTime} ms");

            Assert.Less(stringConstructorTime, stringBuilderTime, $"String constructor should be faster");
        }
    }
}
