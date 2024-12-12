namespace Billiards;

public static class BilliardsTask
{
    public static double BounceWall(double directionRadians, double wallInclinationRadians)
    {
        double result = (2 * wallInclinationRadians) - directionRadians;
        
            return result;
    }
}