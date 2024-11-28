namespace StructBenchmarking;

public class ExperimentResult
{
	public readonly int FieldsCount;
	public readonly double AverageTime;

	public ExperimentResult(int fieldsCount, double averageTime)
	{
		FieldsCount = fieldsCount;
		AverageTime = averageTime;
	}
}