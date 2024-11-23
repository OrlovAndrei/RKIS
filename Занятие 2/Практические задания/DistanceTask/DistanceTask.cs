using System;

namespace DistanceTask;

public static class DistanceTask
{
    // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        double dABx = bx - ax;
        double dABy = by - ay;

        double dAPointx = x - ax;
        double dAPointy = y - ay;

        double dBPointx = x - bx;
        double dBPointy = y - by;

        double ab2 = dABx * dABx + dABy * dABy; 
        double ap_ab = dAPointx * dABx + dAPointy * dABy; 

        if (ab2 == 0) 
            return Math.Sqrt(dAPointx * dAPointx + dAPointy * dAPointy); 

        double t = ap_ab / ab2;

        if (t < 0) 
            return Math.Sqrt(dAPointx * dAPointx + dAPointy * dAPointy);
        else if (t > 1)
            return Math.Sqrt(dBPointx * dBPointx + dBPointy * dBPointy);

        
        double projx = ax + t * dABx;
        double projy = ay + t * dABy;

        double dx = projx - x;
        double dy = projy - y;

        return Math.Sqrt(dx * dx + dy * dy);
    }
}