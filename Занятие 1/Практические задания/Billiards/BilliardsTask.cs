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
        var angle = 2 * wallInclinationRadians - directionRadians;

        return angle;
    }
}