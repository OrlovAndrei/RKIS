using System;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            // Начальная точка
            float x = 1.0f;
            float y = 0.0f;

            // Создание генератора случайных чисел с указанным seed
            var random = new Random(seed);
            const double sqrt2 = Math.Sqrt(2);
            const double angle45 = Math.PI / 4; // 45°
            const double angle135 = 3 * Math.PI / 4; // 135°

            for (int i = 0; i < iterationsCount; i++)
            {
                // Выбор случайного преобразования
                int transformation = random.Next(2); // 0 или 1

                if (transformation == 0)
                {
                    // Преобразование 1
                    float newX = (float)((x * Math.Cos(angle45) - y * Math.Sin(angle45)) / sqrt2);
                    float newY = (float)((x * Math.Sin(angle45) + y * Math.Cos(angle45)) / sqrt2);
                    x = newX;
                    y = newY;
                }
                else
                {
                    // Преобразование 2
                    float newX = (float)((x * Math.Cos(angle135) - y * Math.Sin(angle135)) / sqrt2) + 1;
                    float newY = (float)((x * Math.Sin(angle135) + y * Math.Cos(angle135)) / sqrt2);
                    x = newX;
                    y = newY;
                }

                pixels.SetPixel((int)(x * 100), (int)(y * 100)); // Умножаем на 100 для масштабирования
            }
        }
    }
}
