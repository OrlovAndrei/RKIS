using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace StructBenchmarking
{
    public class Benchmark : IBenchmark
    {
        public void WarmUpRun(ITask task)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            task.Run();
            Thread.Sleep(1000);
            stopwatch.Stop();
        }

        public double MeasureDurationInMs(ITask task, int repetitionCount)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Stopwatch stopwatch = new Stopwatch();
            WarmUpRun(task);
            stopwatch.Start();

            for (var i = 0; i < repetitionCount; i++)
            {
                task.Run();
            }

            return (double)stopwatch.ElapsedMilliseconds / repetitionCount;
        }
    }

    [TestFixture]

    public class StringBuilderTest : ITask
    {
        public void Run()
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < 10000; i++)
            {
                stringBuilder.Append('a');
            }

            stringBuilder.ToString();
        }
    }

    public class StringTest : ITask
    {
        public void Run()
        {
            new string('a', 10000);
        }
    }

    public class RealBenchmarkUsageSample
    {
        [Test]
        public void StringConstructorFasterThanStringBuilder()
        {
            var stringBuilderTest = new StringBuilderTest();
            var stringTest = new StringTest();

            var benchMark = new Benchmark();
            var result1 = benchMark.MeasureDurationInMs(stringBuilderTest, 10000);
            var result2 = benchMark.MeasureDurationInMs(stringTest, 10000);
            Assert.Less(result2, result1);
        }
    }
}