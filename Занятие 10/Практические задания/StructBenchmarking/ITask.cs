namespace StructBenchmarking;
{
    public interface ITaskFactory
    {
        ITask CreateClassTask();
        ITask CreateStructTask();
    }
}