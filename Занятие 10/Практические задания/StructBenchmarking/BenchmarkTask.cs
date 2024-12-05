using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace StructBenchmarking
{
    // Интерфейс для измерения времени выполнения задач
    public interface IBenchmark
    {
        double MeasureDurationInMs(ITask task, int repetitionCount);
    }

    // Интерфейс задачи
    public interface ITask
    {
        void Run();
    }

    // Класс Benchmark, реализующий IBenchmark
    public class Benchmark : IBenchmark
    {
        public double MeasureDurationInMs(ITask task, int repetitionCount)
        {
            // Принудительный вызов сборщика мусора перед замером
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Прогревочный вызов для JIT-компиляции
            task.Run();

            // Замер времени выполнения
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < repetitionCount; i++)
            {
                task.Run();
            }
            stopwatch.Stop();

            // Возвращаем среднее время выполнения в миллисекундах
            return stopwatch.Elapsed.TotalMilliseconds / repetitionCount;
        }
    }

    // Реализация задачи через StringBuilder
    public class StringBuilderTask : ITask
    {
        public void Run()
        {
            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                builder.Append('a');
            }
            var result = builder.ToString();
        }
    }

    // Реализация задачи через конструктор строки
    public class StringConstructorTask : ITask
    {
        public void Run()
        {
            var result = new string('a', 10000);
        }
    }

    // Класс с тестами
    [TestFixture]
    public class RealBenchmarkUsageSample
    {
        [Test]
        public void StringConstructorFasterThanStringBuilder()
        {
            var benchmark = new Benchmark();

            var stringBuilderTask = new StringBuilderTask();
            var stringConstructorTask = new StringConstructorTask();

            int repetitionCount = 1000; // Количество повторений для измерения

            // Измеряем время выполнения каждой задачи
            double stringBuilderDuration = benchmark.MeasureDurationInMs(stringBuilderTask, repetitionCount);
            double stringConstructorDuration = benchmark.MeasureDurationInMs(stringConstructorTask, repetitionCount);

            Console.WriteLine($"StringBuilder duration: {stringBuilderDuration} ms");
            Console.WriteLine($"String constructor duration: {stringConstructorDuration} ms");

            // Проверяем, что конструктор строки работает быстрее
            Assert.Less(stringConstructorDuration, stringBuilderDuration);
        }
    }
}