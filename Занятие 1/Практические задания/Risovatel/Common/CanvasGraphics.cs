using Avalonia.Controls;
using Avalonia.Media;
using Color = Avalonia.Media.Color;
using Pen = Avalonia.Media.Pen;
using Point = Avalonia.Point;

namespace RefactorMe.Common;

public class CanvasGraphics : IGraphics
{
	private readonly Canvas canvas;

	public CanvasGraphics(Canvas canvas)
	{
		this.canvas = canvas;
	}

	public void Clear(Color color)
	{
		canvas.Children.Clear();
		canvas.Background = new SolidColorBrush(color);
	}

	public void DrawLine(Pen pen, float x, float y, float x1, float y1)
	{
		var line = new Avalonia.Controls.Shapes.Line
		{
			StartPoint = new Point(x, y),
			EndPoint = new Point(x1, y1),
			Stroke = pen.Brush,
			StrokeThickness = pen.Thickness,
		};

		canvas.Children.Add(line);
	}
}