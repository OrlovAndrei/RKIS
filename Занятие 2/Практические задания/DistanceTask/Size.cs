using Avalonia;

namespace DistanceTask;

public record Size(double Width, double Height)
{
    public static Point operator +(Point point, Size size)
    {
        return new Point(point.X + size.Width, point.Y + size.Height);
    }
}