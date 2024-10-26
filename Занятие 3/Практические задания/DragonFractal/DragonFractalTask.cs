using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
        double x = 1;
        double y = 0;

        var randomNum = new Random(seed);

        for (int i = 0; i < iterationsCount; i++)
        { 
            int j = randomNum.Next(2);

            if (j == 1)
            {
                double sin135 = Math.Sin(3 * Math.PI / 4);
                double cos135 = Math.Cos(3 * Math.PI / 4);
                var y2 = (x * sin135 + y * cos135) / Math.Sqrt(2);
                var x2 = (x * cos135 - y * sin135) / Math.Sqrt(2) + 1;

                x = x2;
                y = y2;
            }
            else
            {
                double sin45 = Math.Sin(Math.PI / 4);
                double cos45 = Math.Cos(Math.PI / 4);
                var y2 = (x * sin45 + y * cos45) / Math.Sqrt(2);
                var x2 = (x * cos45 - y * sin45) / Math.Sqrt(2);

                y = y2;
                x = x2;
            }
            pixels.SetPixel(x, y);
        }
    }
}