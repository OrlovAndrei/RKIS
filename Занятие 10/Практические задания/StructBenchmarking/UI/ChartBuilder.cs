using System.Linq;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;

namespace StructBenchmarking.UI;

public class ChartBuilder
{
	public PlotModel CreateTimeOfObjectSizeChart(ChartData chartData)
	{
		var model = new PlotModel { Title = chartData.Title };
		
		model.Legends.Add(new Legend { 
			LegendPosition = LegendPosition.LeftTop,
		});

		model.Axes.Add(
			new LinearAxis
				{ Position = AxisPosition.Left, Title = "Time" });
		model.Axes.Add(
			new LinearAxis
				{ Position = AxisPosition.Bottom, Title = "Size" });

		model.Series.Add(new LineSeries
		{
			StrokeThickness = 2,
			Color = OxyColors.Red,
			Title = "Classes",
			ItemsSource = chartData.ClassPoints.Select(p => new DataPoint(p.FieldsCount, p.AverageTime))
		});
		model.Series.Add(new LineSeries
		{
			StrokeThickness = 2,
			Color = OxyColors.Blue, 
			RenderInLegend = true,
			Title = "Structures",
			ItemsSource = chartData.StructPoints.Select(p => new DataPoint(p.FieldsCount, p.AverageTime))
		});

		return model;
	}
}