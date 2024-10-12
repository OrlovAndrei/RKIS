using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Risovatel
    {
        static float x, y;
        static IGraphics graphic;

        public static void Initialization(IGraphics newGraphic)
        {
            graphic = newGraphic;
            //grafika.SmoothingMode = SmoothingMode.None;
            graphic.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        { x = x0; y = y0; }

        public static void MakeStep(Pen pen, double length, double angle)
        {
            //Делает шаг длиной length в направлении и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphic.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void ChangePositione(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double RotationAngle, IGraphics graphic)
        {
            // RotationAngle пока не используется, но будет использоваться в будущем
            Risovatel.Initialization(graphic);

            var size = Math.Min(width, height);

            var diagonal_length = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Risovatel.SetPosition(x0, y0);

            DrawSide(size, 0);
            DrawSide(size, -Math, PI / 2);
            DrawSide(size, Math.PI);
            DrawSide(size, Math.PI / 2)
        }

        private static void DrawSide(int size, double angle)
        {
            Risovatel.MakeStep(new Pen(Brushes.Yellow), size * 0.375f, 0 + angle);
            Risovatel.MakeStep(new Pen(Brushes.Yellow), size * 0.04f * Math.Sqrt(2), Math.PI / 4 + angle);
            Risovatel.MakeStep(new Pen(Brushes.Yellow), size * 0.375f, Math.PI + angle);
            Risovatel.MakeStep(new Pen(Brushes.Yellow), size * 0.375f - size * 0.04f, Math.PI / 2 + angle);

            Risovatel.ChangePosition(size * 0.04f, angle - Math.PI);
            Risovatel.ChangePosition(size * 0.04f * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }

     }
}
