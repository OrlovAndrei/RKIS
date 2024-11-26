using System;

namespace DistanceTask;

public static class DistanceTask
{
    // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
    private static double Sqr(double val) { return val * val; }
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        double t = Math.Clamp(((x - ax) * (bx - ax) + (y - ay) * (by - ay)) / (Sqr(bx - ax) + Sqr(by - ay)), 0, 1);
        return Math.Sqrt(Sqr(ax + (bx - ax) * t - x) + Sqr(ay + (by - ay) * t - y));
    }
}