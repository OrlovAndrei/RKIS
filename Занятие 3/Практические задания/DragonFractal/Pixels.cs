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
            var x = (pixel.Item1 - minX - width / 2) * scale + image.Width / 2.0;
            var y = (pixel.Item2 - minY - height / 2) * scale + image.Height / 2.0;
            image.SetPixel((int) x, (int) y, Color.Yellow);
            image.SetPixel((int) x, (int) y, Color.LightPink);
        }
    }
}
