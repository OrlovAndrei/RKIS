using System;

namespace Billiards
{
    public static class BilliardsTask
    {
        /// <summary>
        /// Вычисляет угол отражения шарика от стены.
        /// </summary>
        /// <param name="directionRadians">Угол направления движения шара.</param>
        /// <param name="wallInclinationRadians">Угол наклона стены.</param>
        /// <returns>Угол отражения в радианах.</returns>
        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {
            // Вычисляем угол отражения
            double angleOfReflection = 2 * wallInclinationRadians - directionRadians;

            // Приводим угол к диапазону [0, 2π) для удобства
            while (angleOfReflection < 0)
            {
                angleOfReflection += 2 * Math.PI;
            }
            while (angleOfReflection >= 2 * Math.PI)
            {
                angleOfReflection -= 2 * Math.PI;
            }

            return angleOfReflection;
        }
    }
}