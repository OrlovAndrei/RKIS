sing System;

namespace AngryBirds;

public static class AngryBirdsTask
namespace AngryBirds
{
    public static double FindSightAngle(double v, double distance)
    public static class AngryBirdsTask
    {
        return Math.PI / 4;

        public static double FindSightAngle(double v, double distance)
        {

            double g = 9.8;

            return 0.5 * Math.Asin(distance * g / Math.Pow(v, 2));
        }
    }
}
