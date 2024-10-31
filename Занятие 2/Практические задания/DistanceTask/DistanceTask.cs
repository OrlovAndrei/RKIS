using System;

namespace DistanceTask;

public static class DistanceTask
{
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        double abx = bx - ax;
        double aby = by - ay;
        double apx = x - ax;
        double apy = y - ay;

        double ab_ab = abx * abx + aby * aby;
        double ab_ap = abx * apx + aby * apy;
        double t = Math.Max(0, Math.Min(1, ab_ap / ab_ab));

        double nearestX = ax + t * abx;
        double nearestY = ay + t * aby;

        double dx = x - nearestX;
        double dy = y - nearestY;

        return Math.Sqrt(dx * dx + dy * dy);
    }
}