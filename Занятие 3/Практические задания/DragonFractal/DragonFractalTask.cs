﻿using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
        var x = 1.0;
var y = 0.0;
var angle45 = Math.PI * 45 / 180;
var angle135 = Math.PI * 135 / 180;
var random = new Random(seed);
for (int i = 0; i < iterationsCount; i++)
{
    var nextNumber = random.Next(1, 3);
    if (nextNumber == 1)
    {
        var x1 = (x * Math.Cos(angle45) - y * Math.Sin(angle45)) / Math.Sqrt(2);
        var y1 = (x * Math.Sin(angle45) + y * Math.Cos(angle45)) / Math.Sqrt(2);
        x = x1; // !!!
        y = y1; // !!!
    }
    if (nextNumber == 2)
    {
        var x1 = (x * Math.Cos(angle135) - y * Math.Sin(angle135)) / Math.Sqrt(2) + 1;
        var y1 = (x * Math.Sin(angle135) + y * Math.Cos(angle135)) / Math.Sqrt(2);
        x = x1; // !!!
        y = y1; // !!!
    }
    pixels.SetPixel(x, y);
    }
}
