using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting;

public class Segment
{
    public Point A { get; set; }
    public Point B { get; set; }
    private IBrush color = Brushes.Black; 

    public Segment(Point a, Point b)
    {
        A = a;
        B = b;
    }

    public IBrush GetColor()
    {
        return color; 
    }

    public void SetColor(IBrush newColor)
    {
        color = newColor; 
    }
}
