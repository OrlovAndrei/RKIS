using System;

namespace AngryBirds
{
    public static class AngryBirdsTask
    {
        private const double g = 9.8;
    public static double FindSightAngle(double v, double distance)
        {
            double rightSide = (distance * g) / (v * v);
            if (rightSide > 1)
            {
                return double.NaN;
            }
            if (v == 0 || distance == 0)
            {
                return Math.PI / 4;
            }
            double angleR = 0.5 * Math.Asin(rightSide);
            return angleR;
        }
    }
}