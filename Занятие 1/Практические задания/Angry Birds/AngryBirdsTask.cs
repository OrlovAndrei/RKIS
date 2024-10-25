using System;

namespace AngryBirds;

public static class AngryBirdsTask
{
    public static double FindSightAngle(double v, double distance)
    {
        return 0.5 * Math.Asin(distance * 9.8 / (v * v));
    }
}
{
