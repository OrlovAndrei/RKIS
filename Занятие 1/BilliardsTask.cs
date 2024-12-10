using System;

namespace Billiards
{

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
            double angleOI= directionRadians - wallInclinationRadians;
            double angleOR = -angleOI;
            double reflectedD= angleOR + wallInclinationRadians;
            return reflectedD;
        }
    }
}