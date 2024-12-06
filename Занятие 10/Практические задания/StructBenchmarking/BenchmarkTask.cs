using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace StructBenchmarking
{
    public class Benchmark : IBenchmark
    {
        public double MeasureDurationInMs(ITask task, int repetitionCount)
        {
            GC.Collect();                   
            GC.WaitForPendingFinalizers();  
            task.Run();
            var time = new Stopwatch();
            time.Start();
            for (int i = 0; i < repetitionCount; i++)
            {
                task.Run();
            }
            time.Stop();
            return time.Elapsed.TotalMilliseconds / repetitionCount;
        }
    }

    [TestFixture]
    public class RealBenchmarkUsageSample
    {
        [Test]
        public void StringConstructorFasterThanStringBuilder()
        {
            var benchmark = new Benchmark();

            Assert.Less(benchmark.MeasureDurationInMs(new StrCreateConstructor(), 10000), benchmark.MeasureDurationInMs(new StrCreateStrigBuilder(), 10000));
        }
    }

    public class StrCreateStrigBuilder : ITask
    {
        public void Run()
        {
            var strBuilder = new StringBuilder();
            for (int size = 0; size < 10000; size++)
            {
                strBuilder.Append("a");
            }
            var str = strBuilder.ToString();
        }
    }

    public class StrCreateConstructor : ITask
    {
        public void Run()
        {
            var str = new string('a', 10000);
        }
    }
}
