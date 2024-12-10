using System;

namespace DistanceTask;

public static class DistanceTask
{
    // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        if (ax == bx && ay == by)
            return Math.Sqrt(Math.Pow((x - ax), 2) + Math.Pow((y - ay), 2));

        double t = ((x - ax) * (bx - ax) + (y - ay) * (by - ay)) / (Math.Pow((bx - ax), 2) + Math.Pow((by - ay), 2));
        t = t < 0 ? 0 : t > 1 ? 1 : t;
        return (double)Math.Sqrt(Math.Pow((ax - x + (bx - ax) * t), 2) + Math.Pow((ay - y + (by - ay) * t), 2));
    }
}