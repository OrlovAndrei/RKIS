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

        double bpx = x - bx;
        double bpy = y - by;

        double ab2 = abx * abx + aby * aby;
        double ap_ab = apx * abx + apy * aby;


        if (ab2 == 0)
            return Math.Sqrt(apx * apx + apy * apy);

        double t = ap_ab / ab2;

        if (t < 0)
            return Math.Sqrt(apx * apx + apy * apy);
        else if (t > 1)
            return Math.Sqrt(bpx * bpx + bpy * bpy);

        double projx = ax + t * abx;
        double projy = ay + t * aby;

        double dx = projx - x;
        double dy = projy - y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}