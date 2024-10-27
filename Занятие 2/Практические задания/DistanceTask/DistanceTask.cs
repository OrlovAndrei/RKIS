using System;

namespace DistanceTask;

public static class DistanceTask
{
    // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        double am = Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
        double mb = Math.Sqrt((x - bx) * (x - bx) + (y - by) * (y - by));
        double ab = Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));

        //скалярное произведение векторов
        double scalarAMAB = (x - ax) * (bx - ax) + (y - ay) * (by - ay);
        double scalarMBAB = (x - bx) * (-bx + ax) + (y - by) * (-by + ay);

        if (ab == 0) return am;
        else if (scalarAMAB >= 0 && scalarMBAB >= 0)
        {
            double p = (am + mb + ab) / 2.0;
            double s = Math.Sqrt(Math.Abs((p * (p - am) * (p - mb) * (p - ab))));
            return (2.0 * s) / ab;
        }
        else if (scalarAMAB < 0 || scalarMBAB < 0)
        {
            return Math.Min(am, mb);

        }
        else return 0;
    }
}