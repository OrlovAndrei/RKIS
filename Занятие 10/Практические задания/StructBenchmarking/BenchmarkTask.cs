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
            var timer = new Stopwatch();
            timer.Start();
            task.Run();
            Thread.Sleep(1000);
            timer.Stop();
        }

        public double MeasureDurationInMs(ITask task, int repetitionCount)
        {
            GC.Collect();                   // Эти две строчки нужны, чтобы уменьшить вероятность того,
            GC.WaitForPendingFinalizers();  // что Garbadge Collector вызовется в середине измерений
                                            // и как-то повлияет на них.
            Stopwatch timer = new Stopwatch();
            WarmUpRun(task);
            timer.Start();

            for (var index = 0; index < repetitionCount; index++)
            {
                task.Run();
            }

            return (double)timer.ElapsedMilliseconds / repetitionCount;
        }
    }

    [TestFixture]

    public class StringBuilderTest : ITask
    {
        public void Run()
        {
            var sb = new StringBuilder();

            for (var index = 0; index < 10000; index++)
            {
                sb.Append('a');
            }

            sb.ToString();
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
            var sbTest = new StringBuilderTest();
            var strTest = new StringTest();

            var benchMark = new Benchmark();
            var duration1 = benchMark.MeasureDurationInMs(sbTest, 10000);
            var duration2 = benchMark.MeasureDurationInMs(strTest, 10000);
            Assert.Less(duration2, duration1);
        }
    }
}