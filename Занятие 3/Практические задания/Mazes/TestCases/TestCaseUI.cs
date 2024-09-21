using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace Mazes.TestCases;

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

    public void Line(double p0, double p1, double p2, double p3, Pen color)
    {
        p0 *= 2;
        p1 *= 2;
        p2 *= 2;
        p3 *= 2;
        var line = new Line
        {
            StartPoint = new Point(p0, p1),
            EndPoint = new Point(p2, p3),
            Stroke = color.Brush,
            StrokeThickness = color.Thickness,
            [Canvas.LeftProperty] = canvas.Bounds.Size.Width / 2,
            [Canvas.TopProperty] = canvas.Bounds.Size.Height / 2
        };

        canvas.Children.Add(line);
    }

    public void Circle(double p0, double p1, double p2, Pen p3)
    {
        p0 *= 2;
        p1 *= 2;
        var circle = new Ellipse
        {
            Stroke = p3.Brush,
            StrokeThickness = p3.Thickness,
            Width = p2 * 4,
            Height = p2 * 4,
            [Canvas.LeftProperty] = canvas.Bounds.Size.Width / 2 + p0 - p2 * 2,
            [Canvas.TopProperty] = canvas.Bounds.Size.Height / 2 + p1 - p2 * 2
        };
        canvas.Children.Add(circle);
    }

    public void Dot(double x, double y, IBrush red)
    {
        x *= 2;
        y *= 2;
        var circle = new Ellipse
        {
            Fill = red,
            Width = 2,
            Height = 2,
            [Canvas.LeftProperty] = canvas.Bounds.Size.Width / 2 + x - 1,
            [Canvas.TopProperty] = canvas.Bounds.Size.Height / 2 + y - 1
        };
        canvas.Children.Add(circle);
    }

    public void Rect(Point position, Size size, Pen pen)
    {
        position *= 2;
        size *= 2;
        var rectangle = new Rectangle()
        {
            [Canvas.LeftProperty] = canvas.Bounds.Size.Width / 2 + position.X,
            [Canvas.TopProperty] = canvas.Bounds.Size.Height / 2 + position.Y,
            Width = size.Width,
            Height = size.Height,
            Stroke = pen.Brush,
            StrokeThickness = pen.Thickness
        };
        canvas.Children.Add(rectangle);
    }
}