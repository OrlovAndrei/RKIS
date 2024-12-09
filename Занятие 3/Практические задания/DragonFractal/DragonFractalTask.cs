using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
        /*
        Начните с точки (1, 0)
        Создайте генератор рандомных чисел с сидом seed
        
        На каждой итерации:

        1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

            Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
            x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
            y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

            Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
            x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
            y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)
    
        2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)

        */
        double x = 1;
        double y = 0;

        var random = new Random(seed);

        for (int i = 0; i < iterationsCount; i++)
        {
            int z = random.Next(2);

            if (z == 0)
            {
                double sin45 = Math.Sin(Math.PI / 4);
                double cos45 = Math.Cos(Math.PI / 4);
                var y2 = (x * sin45 + y * cos45) / Math.Sqrt(2);
                var x2 = (x * cos45 - y * sin45) / Math.Sqrt(2);

                y = y2;
                x = x2;
            }
            else
            {
                double sin135 = Math.Sin(3 * Math.PI / 4);
                double cos135 = Math.Cos(3 * Math.PI / 4);
                var y2 = (x * sin135 + y * cos135) / Math.Sqrt(2);
                var x2 = (x * cos135 - y * sin135) / Math.Sqrt(2) + 1;

                x = x2;
                y = y2;
            }
            pixels.SetPixel(x, y);
        }
    }
}