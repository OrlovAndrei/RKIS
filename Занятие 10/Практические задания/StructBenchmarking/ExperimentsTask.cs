using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StructBenchmarking
{
    public class Experiments
    {
        public static ChartData BuildChartDataForArrayCreation(
            IBenchmark benchmark, int repetitionsCount)
        {
            return BuildChartsDataForClasses(benchmark, repetitionsCount, false, "Create array");
        }

        public static ChartData BuildChartDataForMethodCall(
            IBenchmark benchmark, int repetitionsCount)
        {
            return BuildChartsDataForClasses(benchmark, repetitionsCount, true, "Call method with argument");
        }

        public static ChartData BuildChartsDataForClasses(IBenchmark benchmark, int repetitionsCount, bool isMethodCaller, string titleName)
        {
            var classesTimes = new List<ExperimentResult>();
            var structuresTimes = new List<ExperimentResult>();

            foreach (var size in Constants.FieldCounts)
            {
                var methods = new CompariableMethods(size, isMethodCaller);
                classesTimes.Add(new ExperimentResult(size, benchmark.MeasureDurationInMs(methods.Classes, repetitionsCount)));
                structuresTimes.Add(new ExperimentResult(size, benchmark.MeasureDurationInMs(methods.Structures, repetitionsCount)));
            }

            return new ChartData
            {
                Title = titleName,
                ClassPoints = classesTimes,
                StructPoints = structuresTimes,
            };
        }
    }

    public class CompariableMethods
    {
        public ITask Classes { get; set; }
        public ITask Structures { get; set; }

        public CompariableMethods(int size, bool isMethodCaller)
        {
            if (isMethodCaller)
            {
                Classes = new MethodCallWithClassArgumentTask(size);
                Structures = new MethodCallWithStructArgumentTask(size);
            }
            else
            {
                Classes = new ClassArrayCreationTask(size);
                Structures = new StructArrayCreationTask(size);
            }
        }
    }
}