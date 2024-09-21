using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;

namespace RefactorMe.Common;

public class MockedGraphics : IGraphics
{
	protected List<Line> lines = new();
	protected uint backgroundColor;

	public void Clear(Color color)
	{
		lines = new();
		backgroundColor = color.ToUInt32();
	}

	public void DrawLine(Pen pen, float x, float y, float x1, float y1)
	{
		var color = (pen.Brush as IImmutableSolidColorBrush).Color.ToUInt32();
		lines.Add(new Line(color, x, y, x1, y1));
	}

	public string? CompareTo(MockedGraphics correct)
	{
		if (backgroundColor != correct.backgroundColor)
			return "Incorrect background color";
		var linesCountDiff = Math.Abs(lines.Count - correct.lines.Count);
		if (linesCountDiff > 0)
		{
			if (lines.Count < correct.lines.Count)
				return $"Missing {linesCountDiff} line(s)";
			if (lines.Count > correct.lines.Count)
				return $"Found extra {linesCountDiff} line(s)";
		}

		if (lines.Any(l => l.Color != correct.lines[0].Color))
			return "Incorrect color of line(s)";

		foreach (var line in lines)
			if (correct.lines.All(l => l.GetDistanceDiff(line) > 0.001f))
				return $"Incorrectly placed line, X={line.X};Y={line.Y};X1={line.X1};Y1={line.Y1}";

		return null;
	}
}

public record Line(uint Color, float X, float Y, float X1, float Y1)
{
	public float GetDistanceDiff(Line other)
	{
		return X - other.X +
			Y - other.Y +
			X1 - other.X1 +
			Y1 - other.Y1;
	}
}