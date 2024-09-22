using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using Mazes.TestCases;

namespace Mazes.UI;

public partial class MainWindow : Window
{
    private ObservableCollection<string> TestCasesDisplay { get; }
    private List<TestCase> TestCasesContexts { get; }

    private readonly Brush passTest = new SolidColorBrush(new Color(255, 0x7f, 0xff, 0xd4));
    private readonly Brush failTest = new SolidColorBrush(new Color(255, 0xff, 0xb6, 0xc1));

    private readonly TestCaseUI testCaseUi;
    private readonly Canvas canvas;
    private readonly ListBox list;

    private int failedCount;
    private int passedCount;

    public MainWindow()
    {
        InitializeComponent();
        canvas = this.Find<Canvas>("TestView");
        list = this.Find<ListBox>("Tests");
        testCaseUi = new TestCaseUI(this.Find<TextBlock>("Log"), canvas);
        TestCasesDisplay = new ObservableCollection<string>();
        TestCasesContexts = new List<TestCase>();
        list.Items = TestCasesDisplay;
        list.SelectionChanged += (_, __) => TestCaseClick();
        Opened += (_, __) => OnOpen();
    }

    private void OnOpen()
    {
        var firstFailed = TestCasesContexts.FindIndex(c => c.LastResult != TestResult.Passed);
        list.SelectedIndex = firstFailed > -1
            ? firstFailed
            : TestCasesContexts.Count - 1;
        list.SelectedIndex = 0;
    }

    private void TestCaseClick()
    {
        var testCase = TestCasesContexts[list.SelectedIndex];
        testCaseUi.Clear();
        testCase.Run().Wait();
        testCase.Visualize(testCaseUi);
        canvas.Background = testCase.LastResult == TestResult.Passed ? passTest : failTest;
    }

    public void CreateTestsCases(IEnumerable<TestCase> testCases)
    {
        foreach (var testCase in testCases)
        {
            testCase.Run().Wait();
            var passed = testCase.LastResult == TestResult.Passed;
            TestCasesDisplay.Add((passed ? "✅" : "❌") + testCase.Name);
            TestCasesContexts.Add(testCase);
            if (passed)
                passedCount++;
            else
                failedCount++;
        }

        Title += $"(passed: {passedCount}, failed: {failedCount})";
    }
}