using System;

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
        double directionAngle = directionRadians*(180/Math.PI);
        double wallIncAngle = wallInclinationRadians*(180/Math.PI);
        double WallDirectionAngle = wallIncAngle-directionAngle;
        double Required_angle = WallDirectionAngle+directionAngle;
        return Required_angle*(Math.PI/180);
    }
}