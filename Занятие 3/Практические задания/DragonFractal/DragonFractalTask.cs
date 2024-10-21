using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
        double x = 1.0f;
        double y = 0.0f;

        var random = new Random(seed);
        const double sqrt2 = Math.Sqrt(2);
        const double angle45 = Math.PI / 4;
        const double angle135 = 3 * Math.PI / 4;

        for (int i = 0; i < iterationsCount; i++)
        {
            int transformation = random.Next(2);

            if (transformation == 0)
            {
                float newX = (float)((x * Math.Cos(angle45) - y * Math.Sin(angle45)) / sqrt2);
                float newY = (float)((x * Math.Sin(angle45) + y * Math.Cos(angle45)) / sqrt2);
                x = newX; y = newY;
            }
            else
            {
                float newX = (float)((x * Math.Cos(angle135) - y * Math.Sin(angle135)) / sqrt2) + 1;
                float newY = (float)((x * Math.Sin(angle135) + y * Math.Cos(angle135)) / sqrt2);
                x = newX; y = newY;
            }

            pixels.SetPixel((int)Math.Round(x), (int)Math.Round(y));
        }   
    }
}