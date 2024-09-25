namespace Billiards;

public static class BilliardsTask
{
    public static double BounceWall(double directionRadians, double wallInclinationRadians)
    {
        wallInclinationRadians += 90;
        directionRadians += 180;

        double diff = wallInclinationRadians - directionRadians;
        double res = directionRadians + 2 * diff + 360 * 5;

        res %= 360;
        if (res > 180)
        {
            res -= 360;
        }
        return res;                         
    }
}