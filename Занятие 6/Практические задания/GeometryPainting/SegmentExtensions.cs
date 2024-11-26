using System.Collections.Generic;
using Avalonia.Media;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GeometryPainting;


public class Segment : Geometry.Segment
{
    public Color Color = Colors.Black;
    public Color GetColor() => Color;
    public void SetColor(Color color) => Color = color;
}