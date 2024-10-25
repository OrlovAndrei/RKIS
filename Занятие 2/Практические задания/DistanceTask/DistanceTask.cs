using System;

namespace DistanceTask;

public static class DistanceTask
{
    // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        double abx = bx - ax;
        double aby = by - ay;
        double apx = x - ax;
        double apy = y - ay;
        double bpx = x - bx;
        double bpy = y - by;

        double squareLengthAB = abx * abx + aby * aby;
        double projectionAPonAB = apx * abx + apy * aby;

        if (squareLengthAB == 0)
            return Math.Sqrt(apx * apx + apy * apy);

        double k = projectionAPonAB / squareLengthAB;

        if (k < 0)
            return Math.Sqrt(apx * apx + apy * apy);
        else if (k > 1)
            return Math.Sqrt(bpx * bpx + bpy * bpy);

        double projx = ax + k * abx;
        double projy = ay + k * aby;
        double dx = projx - x;
        double dy = projy - y;

        return Math.Sqrt(dx * dx + dy * dy);
    }
}