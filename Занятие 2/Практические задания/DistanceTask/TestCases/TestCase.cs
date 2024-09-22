using System;
using System.Threading.Tasks;

namespace DistanceTask.TestCases;

public abstract class TestCase
{
    public string Name { get; }
    private static int counter;

    public TestResult LastResult { get; private set; } = TestResult.NotRun;
    protected Exception? LastException { get; private set; }

    protected TestCase(string name)
    {
        Name = $"{name} {++counter}";
    }

    public Task Run() => Task.Run(() =>
    {
        try
        {
            LastResult = InternalRun() ? TestResult.Passed : TestResult.Failed;
        }
        catch (Exception? ex)
        {
            LastException = ex;
            LastResult = TestResult.Failed;
        }
    });

    public void Visualize(TestCaseUI ui)
    {
        if (LastResult == TestResult.Passed)
            ui.Log("Success!");
        if (LastResult == TestResult.Failed)
            ui.Log("Failed...");
        InternalVisualize(ui);
        if (LastException == null)
            return;
        ui.Log("");
        ui.Log(this.LastException.ToString());
    }

    protected abstract bool InternalRun();
    protected abstract void InternalVisualize(TestCaseUI ui);
}

public enum TestResult 
{
    NotRun,
    Passed,
    Failed,
}