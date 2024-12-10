namespace Billiards;

public static class BilliardsTask
{
    public static double BounceWall(double directionRadians, double wallInclinationRadians)
    {
        double incidenceAngle = directionRadians - wallInclinationRadians;

        double reflectionAngle = -incidenceAngle;

        double newDirection = wallInclinationRadians + reflectionAngle;

        newDirection = (newDirection + 2 * Math.PI) % (2 * Math.PI);

        return newDirection;
    }
}