namespace Billiards;

public static class BilliardsTask
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="directionRadians">Угол направления движения шара</param>
    /// <param name="wallInclinationRadians">Угол</param>
    /// <returns></returns>
    public static double BounceWall(double directionRadians, double wallInclinationRadians)
    {
        double incidenceAngle = directionRadians - wallInclinationRadians;

        double reflectionAngle = -incidenceAngle;

        double newDirection = wallInclinationRadians + reflectionAngle;

        newDirection = (newDirection + 2 * Math.PI) % (2 * Math.PI);

        return newDirection
    }
}