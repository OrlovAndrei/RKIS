using System;
namespace Billiards
{
    public static class BilliardsTask
    {
        static double radToDeg (double rad)
        {
            return (rad * 180) / Math.PI;
        }
        static double degToRad(double deg)
        {
            return (Math.PI * deg) / 180;
        }
        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {
            return degToRad(180.0 - radToDeg(directionRadians) + 2.0 * radToDeg(wallInclinationRadians));
        }
        static void Main(string[] args)
        {
            Console.WriteLine(radToDeg(BounceWall(degToRad(45.0), degToRad(0.0))));
            Console.WriteLine(radToDeg(BounceWall(degToRad(45.0), degToRad(90.0))));
            Console.ReadLine();
        }
    }
}
