using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Fractals;

public class Pixels
{
    public readonly List<Tuple<double, double>> PixelsSet;

    public Pixels()
    {
        PixelsSet = new List<Tuple<double, double>>();
    }

    public void SetPixel(double x, double y)
    {
        PixelsSet.Add(Tuple.Create(x, y));
    }

    public void DrawToBitmap(Bitmap image)
    {
        if (PixelsSet.Count == 0) return;
        var maxX = PixelsSet.Max(p => p.Item1);
        var maxY = PixelsSet.Max(p => p.Item2);
        var minX = PixelsSet.Min(p => p.Item1);
        var minY = PixelsSet.Min(p => p.Item2);
        var width = maxX - minX;
        var height = maxY - minY;
        var scaleX = (image.Width - 20) / width;
        var scaleY = (image.Height - 20) / height;
        var scale = Math.Min(scaleX, scaleY);
        foreach (var pixel in PixelsSet)
        {
            var x = (pixel.Item1 - minX - width / 2) * scale + image.Width / 2.0;
            var y = (pixel.Item2 - minY - height / 2) * scale + image.Height / 2.0;
            image.SetPixel((int) x, (int) y, Color.Yellow);
        }
    }
}