using System.Collections.Generic;

namespace StructBenchmarking;

public class Experiments
{
	// Общий метод для измерений
        private static ChartData MeasureTaskPerformance(
            IBenchmark benchmark,
            int repetitionsCount,
            ITaskFactory taskFactory,
            string title)
        {
            var classPoints = new List<ExperimentResult>();
            var structPoints = new List<ExperimentResult>();

            // Перебираем все значения размеров массива
            foreach (var fieldCount in Constants.FieldCounts)
            {
                var classTask = taskFactory.CreateClassTask();
                var structTask = taskFactory.CreateStructTask();

                classPoints.Add(new ExperimentResult
                {
                    FieldCount = fieldCount,
                    Time = benchmark.MeasureDuration(classTask, repetitionsCount)
                });

                structPoints.Add(new ExperimentResult
                {
                    FieldCount = fieldCount,
                    Time = benchmark.MeasureDuration(structTask, repetitionsCount)
                });
            }

            return new ChartData
            {
                Title = title,
                ClassPoints = classPoints,
                StructPoints = structPoints
            };
        }

        // Метод для эксперимента 1 (создание массива)
        public static ChartData BuildChartDataForArrayCreation(
            IBenchmark benchmark, int repetitionsCount)
        {
            return MeasureTaskPerformance(
                benchmark,
                repetitionsCount,
                new ArrayCreationTaskFactory(),
                "Create array"
            );
        }

        // Метод для эксперимента 2 (передача в метод).
        public static ChartData BuildChartDataForMethodCall(
            IBenchmark benchmark, int repetitionsCount)
        {
            return MeasureTaskPerformance(
                benchmark,
                repetitionsCount,
                new MethodCallTaskFactory(),
                "Call method with argument"
            );
        }
}