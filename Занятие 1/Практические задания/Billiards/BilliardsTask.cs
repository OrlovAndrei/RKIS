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
        //TODO
        return 0.0;
        double incidenceAngel = directionRadians - wallInclinationRadians;
        double reflectionAngle = -incidenceAngel;
        double newDirection = wallInclinationRadians + reflectionAngle;
        newDirection = (newDirection + 2 * Math.PI) % (2 * Math.PI);
        return newDirection;