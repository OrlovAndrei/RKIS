using System.Collections.Generic;

namespace StructBenchmarking;

public class Experiments
    {
        public static ChartData BuildChartDataForArrayCreation(IBenchmark benchmark, int repetitionsCount)
        {
            var classesTimes = new List<ExperimentResult>();
            var structuresTimes = new List<ExperimentResult>();

            foreach (int fieldCount in Constants.FieldCounts)
            {
                var classTask = new ClassArrayCreationTask(fieldCount);
                var structTask = new StructArrayCreationTask(fieldCount);

                double classTime = benchmark.MeasureDurationInMs(classTask, repetitionsCount);
                double structTime = benchmark.MeasureDurationInMs(structTask, repetitionsCount);

                classesTimes.Add(new ExperimentResult(fieldCount, classTime));
                structuresTimes.Add(new ExperimentResult(fieldCount, structTime));
            }

            return new ChartData
            {
                Title = "Create array",
                ClassPoints = classesTimes,
                StructPoints = structuresTimes
            };
        }

        public static ChartData BuildChartDataForMethodCall(IBenchmark benchmark, int repetitionsCount)
        {
            var classesTimes = new List<ExperimentResult>();
            var structuresTimes = new List<ExperimentResult>();

            foreach (int fieldCount in Constants.FieldCounts)
            {
                var classTask = new ClassMethodCallTask(fieldCount);
                var structTask = new StructMethodCallTask(fieldCount);

                double classTime = benchmark.MeasureDurationInMs(classTask, repetitionsCount);
                double structTime = benchmark.MeasureDurationInMs(structTask, repetitionsCount);

                classesTimes.Add(new ExperimentResult(fieldCount, classTime));
                structuresTimes.Add(new ExperimentResult(fieldCount, structTime));
            }

            return new ChartData
            {
                Title = "Call method with argument",
                ClassPoints = classesTimes,
                StructPoints = structuresTimes
            };
        }
    }
}
