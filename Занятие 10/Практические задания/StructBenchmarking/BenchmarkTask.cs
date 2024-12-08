using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace StructBenchmarking
{
    // Интерфейс для замеров времени выполнения задач
    public interface IPerformanceBenchmark
    {
        double CalculateExecutionTimeInMs(ITask task, int executionCount);
    }

    // Интерфейс для задачи
    public interface ITask
    {
        void Execute();
    }

    // Класс PerformanceBenchmark, реализующий IPerformanceBenchmark
    public class PerformanceBenchmark : IPerformanceBenchmark
    {
        public double CalculateExecutionTimeInMs(ITask task, int executionCount)
        {
            // Принудительная сборка мусора перед измерением
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Прогревочный вызов для JIT-компиляции
            task.Execute();

            // Замер времени выполнения
            var timer = Stopwatch.StartNew();
            for (int i = 0; i < executionCount; i++)
            {
                task.Execute();
            }
            timer.Stop();

            // Возвращаем среднее время выполнения в миллисекундах
            return timer.Elapsed.TotalMilliseconds / executionCount;
        }
    }

    // Реализация задачи через StringBuilder
    public class StringBuilderExecution : ITask
    {
        public void Execute()
        {
            var stringBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                stringBuilder.Append('a');
            }
            var output = stringBuilder.ToString();
        }
    }

    // Реализация задачи через конструктор строки
    public class StringConstructorExecution : ITask
    {
        public void Execute()
        {
            var output = new string('a', 10000);
        }
    }

    // Класс с тестами
    [TestFixture]
    public class BenchmarkTests
    {
        [Test]
        public void StringConstructorIsFasterThanStringBuilder()
        {
            var performanceBenchmark = new PerformanceBenchmark();

            var stringBuilderTask = new StringBuilderExecution();
            var stringConstructorTask = new StringConstructorExecution();

            int executionCount = 1000; // Количество повторений для измерения

            // Измеряем время выполнения каждой задачи
            double stringBuilderTime = performanceBenchmark.CalculateExecutionTimeInMs(stringBuilderTask, executionCount);
            double stringConstructorTime = performanceBenchmark.CalculateExecutionTimeInMs(stringConstructorTask, executionCount);

            Console.WriteLine($"StringBuilder time: {stringBuilderTime} ms");
            Console.WriteLine($"String constructor time: {stringConstructorTime} ms");

            // Проверяем, что конструктор строки работает быстрее
            Assert.Less(stringConstructorTime, stringBuilderTime);
        }
    }
}
