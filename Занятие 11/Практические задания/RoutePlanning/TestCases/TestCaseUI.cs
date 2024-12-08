using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace RoutePlanning.TestCases;

public class TestCaseUI
{
	private readonly TextBlock textBlock;
	private readonly Canvas canvas;

	public TestCaseUI(TextBlock textBlock, Canvas canvas)
	{
		this.textBlock = textBlock;
		this.canvas = canvas;
	}

	public void Clear()
	{
		textBlock.Text = "";
		canvas.Children.Clear();
	}

	public void Log(string text)
	{
		textBlock.Text += $"{text}\n";
	}

	public void Line(double x0, double y0, double x1, double y1, Pen color)
	{
		var line = new Line
		{
			StartPoint = new Point(x0, y0),
			EndPoint = new Point(x1, y1),
			Stroke = color.Brush,
			StrokeThickness = color.Thickness,
		};

		canvas.Children.Add(line);
	}

	public void Circle(double x, double y, double radius, Pen p3)
	{
		var circle = new Ellipse
		{
			Stroke = p3.Brush,
			StrokeThickness = p3.Thickness,
			Width = radius * 2,
			Height = radius * 2,
			[Canvas.LeftProperty] = x - radius,
			[Canvas.TopProperty] = y - radius,
			Fill =Brushes.DarkRed
		};
		canvas.Children.Add(circle);
	}
}