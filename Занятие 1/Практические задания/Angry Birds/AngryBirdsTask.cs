using System;

namespace AngryBirds;

public static class AngryBirdsTask
{
    public static double FindSightAngle(double v, double distance)
    {
        const double g = 9.8;

        double sin2Theta = (distance * g) / (v * v);

        if (sin2Theta < -1 || sin2Theta > 1)
            return double.NaN;

        double theta = Math.Asin(sin2Theta) / 2;

        return theta;
    }
}
