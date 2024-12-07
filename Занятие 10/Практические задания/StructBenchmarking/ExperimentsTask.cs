using System.Collections.Generic;

namespace StructBenchmarking;

public class Experiments
{
	public static ChartData BuildChartDataForArrayCreation(
		IBenchmark benchmark, int repetitionsCount)
	{
		var classesTimes = new List<ExperimentResult>();
		var structuresTimes = new List<ExperimentResult>();
            
		foreach (var fieldCount in Constants.FieldCounts)
        {
            var classTask = new ClassArrayCreationTask { FieldCount = fieldCount };
            var structTask = new StructArrayCreationTask { FieldCount = fieldCount };

            var classTime = benchmark.MeasureDurationInMs(classTask, repetitionsCount);
            var structTime = benchmark.MeasureDurationInMs(structTask, repetitionsCount);

            classesTimes.Add(new ExperimentResult { FieldCount = fieldCount, Time = classTime });
            structuresTimes.Add(new ExperimentResult { FieldCount = fieldCount, Time = structTime });
        }

		return new ChartData
		{
			Title = "Create array",
			ClassPoints = classesTimes,
			StructPoints = structuresTimes,
		};
	}

	public static ChartData BuildChartDataForMethodCall(
		IBenchmark benchmark, int repetitionsCount)
	{
		var classesTimes = new List<ExperimentResult>();
		var structuresTimes = new List<ExperimentResult>();
            
		foreach (var fieldCount in Constants.FieldCounts)
        {
            var classTask = createClassTask();
            if (classTask is IFieldCountTask classFieldTask)
                classFieldTask.FieldCount = fieldCount;

            var structTask = createStructTask();
            if (structTask is IFieldCountTask structFieldTask)
                structFieldTask.FieldCount = fieldCount;

            var classTime = benchmark.MeasureDurationInMs(classTask, repetitionsCount);
            var structTime = benchmark.MeasureDurationInMs(structTask, repetitionsCount);

            classesTimes.Add(new ExperimentResult { FieldCount = fieldCount, Time = classTime });
            structuresTimes.Add(new ExperimentResult { FieldCount = fieldCount, Time = structTime });
        }


		return new ChartData
		{
			Title = "Call method with argument",
			ClassPoints = classesTimes,
			StructPoints = structuresTimes,
		};
	}
}