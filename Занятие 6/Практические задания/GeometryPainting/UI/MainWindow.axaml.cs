using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using GeometryTasks;
using Vector = GeometryTasks.Vector;

namespace GeometryPainting.UI;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		Opened += (_, __) =>
		{
			DrawSegments();
		};
	}
	
	private List<Segment> CreateSegments()
	{
		var result = new List<Segment>();
		for (byte i = 0; i <= 254; i++)
		{
			var segment = new Segment
			{
				Begin = new Vector {X = 0, Y = i},
				End = new Vector {X = 255, Y = i}
			};
			if (i != 0) segment.SetColor(Color.FromArgb(255, i, i, i));
			result.Add(segment);
		}

		return result;
	}

	private void DrawSegments()
	{
		var segments = CreateSegments();
		foreach (var segment in segments)
		{
			var pen = new Pen(segment.GetColor().ToUint32());

			var line = new Line
			{
				StartPoint = new Point(segment.Begin.X, segment.Begin.Y),
				EndPoint = new Point(segment.End.X, segment.End.Y),
				Stroke = pen.Brush
			};

			Canvas.Children.Add(line);
		}
	}
}