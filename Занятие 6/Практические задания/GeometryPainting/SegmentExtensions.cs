using System.Collections.Generic;
using Avalonia.Media;

namespace GeometryPainting;

// Наследование класса
// Создание класса обертки и все объекты уже в ней
public class Segment : Geometry.Segment
{
    public Color _color = Colors.Black;
    public Color GetColor() => _color;
    public void SetColor(Color color) => _color = color;
}