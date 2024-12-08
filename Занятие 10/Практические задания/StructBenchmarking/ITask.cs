namespace StructBenchmarking;
master
{
    public interface ITaskFactory
    {
        ITask CreateClassTask();
        ITask CreateStructTask();
    }
}


public interface ITask
{
	void Run();
}
master
