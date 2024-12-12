using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using NUnit.Framework;

namespace StructBenchmarking
{
    public class StringBuilderTask : ITask
    {
        public int Length;
        public StringBuilderTask(int count)
        {
            Length = count;
        }

        public void Run()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < Length; i++)
                builder.Append('a');
        }
    }

    public class StringTask : ITask
    {
        public int Length;
        public StringTask(int count)
        {
            Length = count;
        }

        public void Run()
        {
            var str = new string('a', Length);
        }
    }

    public class Benchmark : IBenchmark
    {
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public double MeasureDurationInMs(ITask task, int repetitionCount)
        {
            task.Run();
            var stopWatch = new Stopwatch();
            stopWatch.Restart();
            for (int i = 0; i < repetitionCount; i++)
                task.Run();
            stopWatch.Stop();
            var time = stopWatch.Elapsed.TotalMilliseconds;
            return time / repetitionCount;
        }
    }

    [TestFixture]
    public class RealBenchmarkUsageSample
    {
        [Test]
        public void StringConstructorFasterThanStringBuilder()
        {
            var stringBuilderTask = new StringBuilderTask(100000);
            var stringTest = new StringTask(100000);
            var benchmark = new Benchmark();

            var firstTest = benchmark.MeasureDurationInMs(stringTest, 10000);
            var secondTest = benchmark.MeasureDurationInMs(stringBuilderTask, 10000);
            Assert.Less(firstTest, secondTest);
        }
    }
}