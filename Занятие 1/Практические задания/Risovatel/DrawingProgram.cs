using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Risovatel
    {
        static float x, y;
        static IGraphics grafika;

        public static void Initialization(IGraphics novayaGrafika)
        {
            grafika = novayaGrafika;
            grafika.Clear(Colors.Black);
        }

        public static void set_position(float x0, float y0)
        { x = x0; y = y0; }

        public static void makeIt(Pen ruchka, double dlina, double ugol)
        {
            var x1 = (float)(x + dlina * Math.Cos(ugol));
            var y1 = (float)(y + dlina * Math.Sin(ugol));
            grafika.DrawLine(ruchka, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double dlina, double ugol)
        {
            x = (float)(x + dlina * Math.Cos(ugol));
            y = (float)(y + dlina * Math.Sin(ugol));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double rotationAngle, IGraphics grafika)
        {
            Risovatel.Initialization(grafika);

            var size = Math.Min(width, height);
            var diagonalLength = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Risovatel.set_position(x0, y0);

            DrawSide(size, 0);
            DrawSide(size, -Math.PI / 2);
            DrawSide(size, Math.PI);
            DrawSide(size, Math.PI / 2);
        }

        private static void DrawSide(int size, double angle)
        {
            Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f, angle);
            Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.04f * Math.Sqrt(2), angle + Math.PI / 4);
            Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f, angle + Math.PI);
            Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f - size * 0.04f, angle + Math.PI / 2);
            Risovatel.Change(size * 0.04f, angle + Math.PI);
            Risovatel.Change(size * 0.04f * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }
    }
}