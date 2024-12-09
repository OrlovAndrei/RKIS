using System.Collections.Generic;

namespace StructBenchmarking
{
    public class Experiments
    {
        public static ChartData BuildChartDataForArrayCreation(
            IBenchmark benchmark, int repetitionsCount)
        {
            var classCreationTimes = new List<ExperimentResult>();
            var structCreationTimes = new List<ExperimentResult>();

            for (var size = 16; size <= 512; size *= 2)
            {
                classCreationTimes.Add(new ExperimentResult
                    (size, benchmark.MeasureDurationInMs
                        (new ClassArrayCreationTask(size), repetitionsCount)));
                structCreationTimes.Add(new ExperimentResult
                    (size, benchmark.MeasureDurationInMs
                        (new StructArrayCreationTask(size), repetitionsCount)));
            }

            return new ChartData
            {
                Title = "Create array",
                ClassPoints = classCreationTimes,
                StructPoints = structCreationTimes,
            };
        }

        public static ChartData BuildChartDataForMethodCall(
            IBenchmark benchmark, int repetitionsCount)
        {
            var classMethodCallTimes = new List<ExperimentResult>();
            var structMethodCallTimes = new List<ExperimentResult>();

            for (var size = 16; size <= 512; size *= 2)
            {
                classMethodCallTimes.Add(new ExperimentResult
                    (size, benchmark.MeasureDurationInMs
                        (new MethodCallWithClassArgumentTask(size), repetitionsCount)));
                structMethodCallTimes.Add(new ExperimentResult
                    (size, benchmark.MeasureDurationInMs
                        (new MethodCallWithStructArgumentTask(size), repetitionsCount)));
            }

            return new ChartData
            {
                Title = "Call method with argument",
                ClassPoints = classMethodCallTimes,
                StructPoints = structMethodCallTimes,
            };
        }
    }
}
