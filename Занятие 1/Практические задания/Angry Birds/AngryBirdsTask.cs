using System;

namespace AngryBirds;

public static class AngryBirdsTask
{
    public static double FindSightAngle(double v, double distance)
    {
        const double g = 9.8;
        double angle = 0.5 * Math.Asin(distance * g / (Math.Pow(v, 2)));
        return angle;
    }
}