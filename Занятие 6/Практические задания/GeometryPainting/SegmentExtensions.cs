using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting;

public class Segment
{
    private Color _color = Colors.Black;

    public Segment(Point a, Point b)
    {
        A = a;
        B = b;
    }

    public Point A { get; }
    public Point B { get; }

    public Color GetColor()
    {
        return _color;
    }

    public void SetColor(Color color)
    {
        _color = color;
    }
}
