using System.Collections.Generic;

namespace StructBenchmarking;

public class PerformanceExperiments
{
    // Общий метод для измерений
    private static ChartData MeasurePerformanceMetrics(
        IBenchmark benchmark,
        int numberOfRepetitions,
        ITaskFactory taskFactory,
        string chartTitle)
    {
        var classMeasurementPoints = new List<ExperimentResult>();
        var structMeasurementPoints = new List<ExperimentResult>();

        // Перебираем все значения размеров массива
        foreach (var fieldSize in Constants.FieldCounts)
        {
            var classTask = taskFactory.CreateClassTask();
            var structTask = taskFactory.CreateStructTask();

            classMeasurementPoints.Add(new ExperimentResult
            {
                FieldCount = fieldSize,
                Time = benchmark.MeasureDuration(classTask, numberOfRepetitions)
            });

            structMeasurementPoints.Add(new ExperimentResult
            {
                FieldCount = fieldSize,
                Time = benchmark.MeasureDuration(structTask, numberOfRepetitions)
            });
        }

        return new ChartData
        {
            Title = chartTitle,
            ClassPoints = classMeasurementPoints,
            StructPoints = structMeasurementPoints
        };
    }

    // Метод для эксперимента 1 (создание массива)
    public static ChartData GenerateChartDataForArrayCreation(
        IBenchmark benchmark, int numberOfRepetitions)
    {
        return MeasurePerformanceMetrics(
            benchmark,
            numberOfRepetitions,
            new ArrayCreationTaskFactory(),
            "Create array"
        );
    }

    // Метод для эксперимента 2 (передача в метод).
    public static ChartData GenerateChartDataForMethodCall(
        IBenchmark benchmark, int numberOfRepetitions)
    {
        return MeasurePerformanceMetrics(
            benchmark,
            numberOfRepetitions,
            new MethodCallTaskFactory(),
            "Call method with argument"
        );
    }
}
