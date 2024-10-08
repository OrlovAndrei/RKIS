using Avalonia;
using System;

namespace AngryBirds;

public static class AngryBirdsTask
{
    public static double FindSightAngle(double v, double distance)
    {
        // Ускорение свободного падения
        const double g = 9.8;
        double corner = 0.5 * Math.Asin(distance * g / (Math.Pow(v, 2)));
        return corner;
    }
}