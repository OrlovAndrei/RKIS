using System;
namespace AngryBirds;

public static class AngryBirdsTask
{
    public static double FindSightAngle(double v, double distance)
    {
        int g = 9.8
       return 0.5 * Math.Asin(distance * g / (v * v));
    }
}