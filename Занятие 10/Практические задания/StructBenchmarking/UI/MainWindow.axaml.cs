using System.Collections.Generic;
using Avalonia.Controls;

namespace StructBenchmarking.UI;

public partial class MainWindow : Window
{
	public static List<TabItemModel> Tabs = new();

	public MainWindow()
	{
		DataContext = Tabs;
		var chartBuilder = new ChartBuilder();
		var arraysData = Experiments.BuildChartDataForArrayCreation(new Benchmark(), 100);
		var callsData = Experiments.BuildChartDataForMethodCall(new Benchmark(), 1000000);
		var arraysChart = chartBuilder.CreateTimeOfObjectSizeChart(arraysData);
		var callsChart = chartBuilder.CreateTimeOfObjectSizeChart(callsData);
		Tabs.Add(new TabItemModel(arraysChart.Title, arraysChart));
		Tabs.Add(new TabItemModel(callsChart.Title, callsChart));
		
		InitializeComponent();
	}
}