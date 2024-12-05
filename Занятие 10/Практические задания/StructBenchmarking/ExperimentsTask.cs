using System.Collections.Generic;

namespace StructBenchmarking
{
    public class Experiments
    {
        public static ChartData BuildChartDataForArrayCreation(
            IBenchmark benchmark, int repetitionCount)
        {
            var classResults = new List<ExperimentResult>();
            var structResults = new List<ExperimentResult>();

            for (var size = 16; size <= 512; size *= 2)
            {
                classResults.Add(new ExperimentResult
                    (size, benchmark.MeasureDurationInMs
                        (new ClassArrayCreationTask(size), repetitionCount)));
                structResults.Add(new ExperimentResult
                    (size, benchmark.MeasureDurationInMs
                        (new StructArrayCreationTask(size), repetitionCount)));
            }

            return new ChartData
            {
                Title = "Create array",
                ClassPoints = classResults,
                StructPoints = structResults,
            };
        }

        public static ChartData BuildChartDataForMethodCall(
            IBenchmark benchmark, int repetitionCount)
        {
            var classResults = new List<ExperimentResult>();
            var structResults = new List<ExperimentResult>();

            for (var size = 16; size <= 512; size *= 2)
            {
                classResults.Add(new ExperimentResult
                    (size, benchmark.MeasureDurationInMs
                        (new MethodCallWithClassArgumentTask(size), repetitionCount)));
                structResults.Add(new ExperimentResult
                    (size, benchmark.MeasureDurationInMs
                        (new MethodCallWithStructArgumentTask(size), repetitionCount)));
            }

            return new ChartData
            {
                Title = "Call method with argument",
                ClassPoints = classResults,
                StructPoints = structResults,
            };
        }
    }
}
