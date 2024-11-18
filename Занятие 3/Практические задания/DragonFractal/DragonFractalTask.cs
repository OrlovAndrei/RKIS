using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
        double x = 1.0, y = 0.0;

        var random = new Random(seed);

        double sqrt2 = Math.Sqrt(2);
        double cos45 = Math.Cos(Math.PI / 4);
        double sin45 = Math.Sin(Math.PI / 4);
        double cos135 = Math.Cos(3 * Math.PI / 4);
        double sin135 = Math.Sin(3 * Math.PI / 4);

        for (int i = 0; i < iterationsCount; i++)
        {
            if (random.Next(2) == 0)
            {
                double newX = (x * cos45 - y * sin45) / sqrt2;
                double newY = (x * sin45 + y * cos45) / sqrt2;
                x = newX;
                y = newY;
            }
            else
            {
                double newX = (x * cos135 - y * sin135) / sqrt2 + 1;
                double newY = (x * sin135 + y * cos135) / sqrt2;
                x = newX;
                y = newY;
            }

            pixels.SetPixel(x, y);
        }
    }
}