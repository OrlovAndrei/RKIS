using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;

namespace GeometryPainting;

public class Segment : Geometry.Segment
{
    public Color Color = Colors.Black;
    public Color GetColor() => Color;
    public void SetColor(Color color) => Color = color;
}
