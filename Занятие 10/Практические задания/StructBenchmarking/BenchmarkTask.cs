using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace StructBenchmarking;
public class Benchmark : IBenchmark
{
    public double MeasureDurationInMs(ITask task, int repetitionCount)
    {
        GC.Collect();                   // Эти две строчки нужны, чтобы уменьшить вероятность того,
        GC.WaitForPendingFinalizers();  // что Garbadge Collector вызовется в середине измерений
                                        // и как-то повлияет на них.
           
		throw new NotImplementedException();
	}
}

[TestFixture]
public class RealBenchmarkUsageSample
{
    [Test]
    public void StringConstructorFasterThanStringBuilder()
    {
        throw new NotImplementedException();
    }
}