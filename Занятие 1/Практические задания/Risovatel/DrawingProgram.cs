using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Risovatel
    {
        static float x, y;
        static IGraphics graphics;

        public static void Initialization(IGraphics graphics)
        {
            //graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        { x = x0; y = y0; }

        public static void MakeStep(Pen pen, double Length, double corner)
        {
            //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(x + Length * Math.Cos(corner));
            var y1 = (float)(y + Length * Math.Sin(corner));
            grafika.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void ChangePosition(double dlina, double corner)
        {
            x = (float)(x + dlina * Math.Cos(corner));
            y = (float)(y + dlina * Math.Sin(corner));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int canvasWidth, int canvasHeight, double corner, IGraphics graphics)
        {
            var drawer = new Risovatel();
            Risovatel.Initialization(graphics);

            var squareSize = Math.Min(canvasWidth, canvasHeight);
            var sideLength = Math.Sqrt(2) * (squareSize * 0.375f + squareSize * 0.04f) / 2;

            var centerX = (float)(sideLength * Math.Cos(Math.PI / 4 + Math.PI)) + canvasWidth / 2f;
            var centerY = (float)(sideLength * Math.Sin(Math.PI / 4 + Math.PI)) + canvasHeight / 2f;
            Risovatel.SetPosition(centerX, centerY);

            DrawSide(drawer, squareSize, 0);
            DrawSide(drawer, squareSize, -Math.PI / 2);
            DrawSide(drawer, squareSize, Math.PI);
            DrawSide(drawer, squareSize, Math.PI / 2);
        }
        private static void DrawSide(Risovatel drawer, float size, double startingAngle)
        {
            var pen = new Pen(Brushes.Yellow);

            Risovatel.MakeStep(pen, size * 0.375f, 0 + startingAngle);
            Risovatel.MakeStep(pen, size * 0.04f * Math.Sqrt(2), Math.PI / 4 + startingAngle);
            Risovatel.MakeStep(pen, size * 0.375f, Math.PI + startingAngle);
            Risovatel.MakeStep(pen, size * 0.375f - size * 0.04f, Math.PI / 2 + startingAngle);

            Risovatel.ChangePosition(size * 0.04f, Math.PI + startingAngle);
            Risovatel.ChangePosition(size * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4 + startingAngle);
        }
    }
}
