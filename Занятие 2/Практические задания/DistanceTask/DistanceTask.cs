using System;

namespace DistanceTask

{
    public static class DistanceTask
    {
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            if (ax == bx && ay == by)
            {
                return Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
            }

            double abx = bx - ax;
            double aby = by - ay;

            double apx = x - ax;
            double apy = y - ay;

            double bpx = x - bx;
            double bpy = y - by;

            double ab_ap = abx * apx + aby * apy;

            double ab_squared = abx * abx + aby * aby;

            double t = ab_ap / ab_squared;

            if (t < 0)
            {
                return Math.Sqrt(apx * apx + apy * apy);
            }
            else if (t > 1)
            {
                return Math.Sqrt(bpx * bpx + bpy * bpy);
            }
            else
            {
                double closestX = ax + t * abx;
                double closestY = ay + t * aby;

                return Math.Sqrt((x - closestX) * (x - closestX) + (y - closestY) * (y - closestY));
            }
        }
    }
}
