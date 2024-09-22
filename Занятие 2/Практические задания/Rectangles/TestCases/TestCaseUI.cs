using Avalonia.Controls;
using Avalonia.Media;

namespace Rectangles.TestCases;

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

	public void Rect(int left, int top, int width, int height, IBrush brush)
	{
		switch (left)
		{
			case < 0 when left + width == 0:
				left += 1;
				break;
			case > 0 when left - width == 0:
				left -= 1;
				break;
		}

		switch (top)
		{
			case < 0 when top + height == 0:
				top += 1;
				break;
			case > 0 when top - height == 0:
				top -= 1;
				break;
		}

		var rectangle = new Avalonia.Controls.Shapes.Rectangle
		{
			Width = width,
			Height = height,

			Stroke = brush,
			StrokeThickness = 1,

			[Canvas.LeftProperty] = canvas.Bounds.Size.Width / 2 + left,
			[Canvas.TopProperty] = canvas.Bounds.Size.Height / 2 + top
		};
		canvas.Children.Add(rectangle);
	}
}