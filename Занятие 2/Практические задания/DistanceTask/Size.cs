using System;

namespace DistanceTask;
{

    public static class DistanceTask
       {

    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y) public static double static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y) x, double y)
        {
    двойной abx = bx - ax;
    double aby = by - ay;

    двойной apx = x - ax;
    double apy = y - ay;

    double bpx = x - bx;
    double bpy = y - by;

    double ab2 = abx * abx + aby * aby; // Квадрат длины отрезка AB
    double ap_ab = apx * abx + apy * aby; // Проекция AP на AB

            if (ab2 == 0) // A и B совпадают
                return Math.Sqrt(apx* apx + apy* apy); // Расстояние до точки A

    double t = ap_ab / ab2;

            if (t< 0) // Проекция за пределами A
 return Math.Sqrt(apx* apx + apy* apy); // Расстояние до точки AA
 else if (t > 1) // Проекция за пределами BB
 return Math.Sqrt(bpx* bpx + bpy* bpy); // Расстояние до точки BB

    // Проекция на отрезок
    double projx = ax + t * abx;
    double projy = ay + t * aby;

    // Расстояние до проекции
    double dx = projx - x;
    double dy = projy - y;

 return Math.Sqrt(dx* dx + dy* dy);
        }
    }
}