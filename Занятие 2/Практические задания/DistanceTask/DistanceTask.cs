using System;

namespace DistanceTask;

public static class DistanceTask
{
    // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        double ABx = bx - ax;
        double ABy = by - ay;
        double APx = x - ax;
        double APy = y - ay;

        double AB_AB = ABx * ABx + ABy * ABy;

        if (AB_AB == 0) return Math.Sqrt(APx * APx + APy * APy);

        double t = (APx * ABx + APy * ABy) / AB_AB;
        t = Math.Max(0, Math.Min(1, t));

        double projectionX = ax + t * ABx;
        double projectionY = ay + t * ABy;

        double dx = x - projectionX;
        double dy = y - projectionY;

        return Math.Sqrt(dx * dx + dy * dy);
    }
}
