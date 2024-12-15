using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace StructBenchmarking;
public class Benchmark : IBenchmark
{
    public double MeasureDurationInMs(ITask task, int repetitionCount)
    {
        if (task == null) throw new ArgumentNullException(nameof(task));
        if (repetitionCount <= 0) throw new ArgumentOutOfRangeException(nameof(repetitionCount), "Количество повторений должно быть больше нуля.");

        task.Run();

        GC.Collect();
        GC.WaitForPendingFinalizers();

        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < repetitionCount; i++)
        {
            task.Run();
        }
        stopwatch.Stop();

        return stopwatch.Elapsed.TotalMilliseconds / repetitionCount;
    }
}

public interface ITask
{
    void Run();
}

[TestFixture]
public class RealBenchmarkUsageSample
{
    private class StringTask : ITask
    {
        public void Run()
        {
            var str = new string('a', 1000);
        }
    }

    private class StringBuilderTask : ITask
    {
        public void Run()
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.Append('a');
            }
        }
    }

    [Test]
    public void StringConstructorFasterThanStringBuilder()
    {
        var benchmark = new Benchmark();
        var stringTask = new StringTask();
        var stringBuilderTask = new StringBuilderTask();

        var stringDuration = benchmark.MeasureDurationInMs(stringTask, 1000);
        var stringBuilderDuration = benchmark.MeasureDurationInMs(stringBuilderTask, 1000);

        Assert.Less(stringDuration, stringBuilderDuration);
    }
}