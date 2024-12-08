using System;
using System.Runtime.CompilerServices;

namespace StructBenchmarking;

public class ExperimentsTask
{
    private const int NumIterations = 100; // Количество измерений

    public ChartData BuildChartDataForArrayCreation()
    {
        var results = new Dictionary<int, (long structTime, long classTime)>();

        foreach (var size in Constants.FieldCounts)
        {
            long structTime = MeasureExecutionTime(() => new StructArrayCreationTask(size).Run(), NumIterations);
            long classTime = MeasureExecutionTime(() => new ClassArrayCreationTask(size).Run(), NumIterations);

            results[size] = (structTime, classTime);
        }

        return CreateChartData(results);
    }

    private long MeasureExecutionTime(Action action, int numIterations)
    {
        long totalTime = 0;
        for (int i = 0; i < numIterations; i++)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                action();
                stopwatch.Stop();
                totalTime += stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при измерении времени: {ex.Message}");
            }
        }
        return totalTime / numIterations; // Возвращаем среднее время
    }

    private ChartData CreateChartData(Dictionary<int, (long structTime, long classTime)> results)
    {
        var chartData = new ChartData();
        foreach (var entry in results)
        {
            chartData.AddPoint(entry.Key, entry.Value.structTime, entry.Value.classTime);
        }
        return chartData;
    }


public class StructArrayCreationTask : ITask
{
	private readonly int size;
	private object array;

	public StructArrayCreationTask(int size)
	{
		this.size = size;
	}
	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	public void Run()
	{
		switch (size)
		{
			case 16:
				array = new S16[Constants.ArraySize];
				break;
			case 32:
				array = new S32[Constants.ArraySize];
				break;
			case 64:
				array = new S64[Constants.ArraySize];
				break;
			case 128:
				array = new S128[Constants.ArraySize];
				break;
			case 256:
				array = new S256[Constants.ArraySize];
				break;
			case 512:
				array = new S512[Constants.ArraySize];
				break;
			default:
				throw new ArgumentException();
		}
	}
}


public class ClassArrayCreationTask : ITask
{
	private readonly int size;
	public C16[] c16;
	public C32[] c32;
	public C64[] c64;
	public C128[] c128;
	public C256[] c256;
	public C512[] c512;

}


public class ChartData
{
    public List<ChartPoint> Points { get; } = new List<ChartPoint>();

    public void AddPoint(int fieldCount, long structTime, long classTime) => Points.Add(new ChartPoint(fieldCount, structTime, classTime));

    public string ToJson() => Newtonsoft.Json.JsonConvert.SerializeObject(Points); // Пример сериализации в JSON
}

public ClassArrayCreationTask(int size)
	{
		this.size = size;
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	public void Run()
	{
		switch (size)
		{
			case 16:
				c16 = new C16[Constants.ArraySize];
				for (int i = 0; i < Constants.ArraySize; i++) c16[i] = new C16();
				break;
			case 32:
				c32 = new C32[Constants.ArraySize];
				for (int i = 0; i < Constants.ArraySize; i++) c32[i] = new C32();
				break;
			case 64:
				c64 = new C64[Constants.ArraySize];
				for (int i = 0; i < Constants.ArraySize; i++) c64[i] = new C64();
				break;
			case 128:
				c128 = new C128[Constants.ArraySize];
				for (int i = 0; i < Constants.ArraySize; i++) c128[i] = new C128();
				break;
			case 256:
				c256 = new C256[Constants.ArraySize];
				for (int i = 0; i < Constants.ArraySize; i++) c256[i] = new C256();
				break;
			case 512:
				c512 = new C512[Constants.ArraySize];
				for (int i = 0; i < Constants.ArraySize; i++) c512[i] = new C512();
				break;
			default:
				throw new ArgumentException();
		}
	}
}
