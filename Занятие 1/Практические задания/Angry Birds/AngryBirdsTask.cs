using System;

namespace AngryBirds
{
    public static class AngryBirdsTask
    {
        public static double FindSightAngle(double v, double distance)
        {
            const double g = 9.81; // Ускорение свободного падения
            
            // Проверка на допустимость
            if (v <= 0 || distance < 0)
            {
                return double.NaN;
            }

            // Вычисляем дискриминант
            double discriminant = v * v * v * v - g * (g * distance * distance);
            
            // Если дискриминант меньше нуля, решения не существует
            if (discriminant < 0)
            {
                return double.NaN;
            }

            // Вычисляем два возможных угла
            double angle1 = Math.Atan((v * v + Math.Sqrt(discriminant)) / (g * distance));
            double angle2 = Math.Atan((v * v - Math.Sqrt(discriminant)) / (g * distance));

            // Возвращаем наименьший угол
            return Math.Min(angle1, angle2);
        }
    }
}