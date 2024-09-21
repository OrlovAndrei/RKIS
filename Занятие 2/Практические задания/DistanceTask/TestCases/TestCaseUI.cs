using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace DistanceTask.TestCases;

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
            [Canvas.LeftProperty] = canvas.Bounds.Size.Width / 2,
            [Canvas.TopProperty] = canvas.Bounds.Size.Height / 2
        };

        canvas.Children.Add(line);
    }

    public void Circle(double x, double y, double radius, Pen pen, AvaloniaList<double> dashArray = null)
    {
        var circle = new Ellipse
        {
            Stroke = pen.Brush,
            StrokeDashArray = dashArray,
            StrokeThickness = pen.Thickness,
            Width = radius * 2,
            Height = radius * 2,
            [Canvas.LeftProperty] = canvas.Bounds.Size.Width / 2 + x - radius,
            [Canvas.TopProperty] = canvas.Bounds.Size.Height / 2 + y - radius
        };
        canvas.Children.Add(circle);
    }

    public void Dot(double dotItem1, double distance, IBrush red)
    {
        dotItem1 *= 2;
        distance *= 2;
        var circle = new Ellipse
        {
            Fill = red,
            Width = 2,
            Height = 2,
            [Canvas.LeftProperty] = canvas.Bounds.Size.Width / 2 + dotItem1 - 1,
            [Canvas.TopProperty] = canvas.Bounds.Size.Height / 2 + distance - 1
        };
        canvas.Children.Add(circle);
    }

    public void Rect(int left, int top, int width, int height, IBrush brush)
    {
        var rectangle = new Avalonia.Controls.Shapes.Rectangle
        {
            Width = width,
            Stroke = brush,
            StrokeThickness = 1,
            Height = height,
            [Canvas.LeftProperty] = canvas.Bounds.Size.Width / 2 + left - 1,
            [Canvas.TopProperty] = canvas.Bounds.Size.Height / 2 + top - 1
        };
        canvas.Children.Add(rectangle);
    }
}