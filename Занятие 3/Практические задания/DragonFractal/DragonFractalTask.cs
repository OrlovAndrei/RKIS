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
            double x = 1.0;
            double y = 0.0;

        1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:
            var random = new Random(seed);


            Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
            x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
            y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)
            for (int i = 0; i < iterationsCount; i++) {
                int nextNumber = random.Next(2);

            Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
            x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
            y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)
    
        2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)
        if (nextNumber == 0) {
                    double cos45 = Math.Cos(Math.PI / 4);
                    double sin45 = Math.Sin(Math.PI / 4);
                    double newX = (x * cos45 - y * sin45) / Math.Sqrt(2);
                    double newY = (x * sin45 + y * cos45) / Math.Sqrt(2);
                    x = newX;
                    y = newY;
                } else {
                    double cos135 = Math.Cos(3 * Math.PI / 4);
                    double sin135 = Math.Sin(3 * Math.PI / 4);
                    double newX = (x * cos135 - y * sin135) / Math.Sqrt(2) + 1;
                    double newY = (x * sin135 + y * cos135) / Math.Sqrt(2);
                    x = newX;
                    y = newY;
                }

        */
            pixels.SetPixel((int)Math.Round(x), (int)Math.Round(y));
    }
}
