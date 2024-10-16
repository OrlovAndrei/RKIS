using System;

namespace DistanceTask;

{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            // лежит ли на отрезке 
            if ((Math.Min(ax, bx) <= x && x <= Math.Max(ax, bx)) && (Math.Min(ay, by) <= y && y <= Math.Max(ay, by)))
                return 0;

        }
    }
}
