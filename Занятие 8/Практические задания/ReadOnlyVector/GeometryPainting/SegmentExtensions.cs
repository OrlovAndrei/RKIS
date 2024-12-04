using System.Collections.Generic;
using Avalonia.Media;
using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Geometry;

namespace GeometryPainting;


public class Segment : Geometry.Segment
{
   public Color Color = Colors.Black;

    public Color GetColor() => Color;
    public void SetColor(Color color) => Color = color;
}

//Напишите здесь код, который заставит работать методы segment.GetColor и segment.SetColor