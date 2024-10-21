using System;

namespace Billiards
{
    public static class BilliardsTask
    {
        static double radToDeg(double rad)// радианы в градусы
        {
            return (rad * 180) / Math.PI;
        }

        static double degToRad(double deg)// градусы в радианы
        {
            return (Math.PI * deg) / 180;
        }

        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {

            return degToRad(360.0 - radToDeg(directionRadians) + 2.0 * radToDeg(wallInclinationRadians));
        }
    }
}