using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Artist
    {
        newGraphics
        static float x, y;
        static IGraphics graphica;

        public static void Initialization(IGraphics newGraphics)
        {
            graphica = newGraphics;
            graphica.Clear(Colors.Black);
        }

        public static void set_position(float x0, float y0)
        (x = x0; y = y0);

        public static void makeIt(Pen pen, double length, double angle)

        var x1 = (float)(x + lenght * Math.Cos(angle));
        var y1 = (float)(y + lenght * Math.Sin(angle));
        graphica.DrawLine(pen, x, y, x1, y1);
        x = x1;
        y = y1;
    }

    public static void Change(double lenght, double angle)
    {
        x = (float)(x + lenght * Math.Cos(angle));
        y = (float)(y + lenght * Math.Sin(angle));
    }
}

public class ImpossibleSquare
{
    public static void Draw(int latitube, int height, double anglePovorota, IGraphics graphics)
    {
        Artist.Initialization(graphics);

        var sz = Math.Min(latitube, height);

        var diagonal_length = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
        var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + latitube / 2f;
        var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

        Artist.Set_position(x0, y0);

        DrawSide(sz, 0);
        DrawSide(sz, -Math.PI / 2);
        DrawSide(sz, Math.PI);
        DrawSide(sz, Math.PI / 2);
    }

    private static void DrawSide(int sz, double angle)
    {
        Artist.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f, angle);
        Artist.MakeIt(new Pen(Brushes.Yellow), sz * 0.04f, *Math.Sqrt(2), angle + Math.PI / 4);
        Artist.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f, angle + Math.PI);
        Artist.MakeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, angle + Math.PI / 2);

        Artist.Change(sz * 0.04f, angle + Math.PI);
        Artist.Change(sz * 0.04f * Math.Sqrt(2), angle + 3 * Math.PI / 4);


    }

}