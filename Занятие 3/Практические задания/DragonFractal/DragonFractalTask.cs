using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
           double x = 1.0;
        double y = 0.0;
        var random = new Random(seed);
        for (int i = 0; i < iterationsCount; i++) 
        {
            int nextNumber = random.Next(2);
            if (nextNumber == 0) 
            {
                double cos45 = Math.Cos(Math.PI / 4);
                double sin45 = Math.Sin(Math.PI / 4);
                double newX = (x * cos45 - y * sin45) / Math.Sqrt(2);
                double newY = (x * sin45 + y * cos45) / Math.Sqrt(2);
                x = newX;
                y = newY;
            }
            else
            {
                double cos135 = Math.Cos(3 * Math.PI / 4);
                double sin135 = Math.Sin(3 * Math.PI /4);
                double newX = (x * cos135 - y * sin135) / Math.Sqrt(2) + 1;
                double newY = (x * sin135 + y * cos135) / Math.Sqrt(2);
                x = newX; y = newY;
            }
            pixels.SetPixel((int)Math.Round(x), (int)Math.Round(y));
        }
    }
}