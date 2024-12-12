namespace StructBenchmarking;

public interface IBenchmark
{
	double MeasureDurationInMs(ITask task, int repetitionCount);
}