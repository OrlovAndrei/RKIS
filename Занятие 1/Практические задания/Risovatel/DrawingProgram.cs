using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Draw
    {
        static float x, y;
        static IGraphics graphic;

        public static void Initialization(IGraphics newGraphic)
        {
            graphic = newGraphic;
            graphic.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        { x = x0; y = y0; }

        public static void MakeStep(Pen pen, double length, double corner)
        {
            var x1 = (float)(x + length * Math.Cos(corner));
            var y1 = (float)(y + length * Math.Sin(corner));
            graphic.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void MakeStep(double dlina, double corner)
        {
            x = (float)(x + dlina * Math.Cos(corner));
            y = (float)(y + dlina * Math.Sin(corner));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int canvasWidth, int canvasHeight, double corner, IGraphics graphics)
        {
            var drawer = new Draw();
            RefactorMe.Draw.Initialization(graphics);

            var squareSize = Math.Min(canvasWidth, canvasHeight);
            var sideLength = Math.Sqrt(2) * (squareSize * 0.375f + squareSize * 0.04f) / 2;

            var centerX = (float)(sideLength * Math.Cos(Math.PI / 4 + Math.PI)) + canvasWidth / 2f;
            var centerY = (float)(sideLength * Math.Sin(Math.PI / 4 + Math.PI)) + canvasHeight / 2f;
            RefactorMe.Draw.SetPosition(centerX, centerY);

            DrawSide(drawer, squareSize, 0);
            DrawSide(drawer, squareSize, -Math.PI / 2);
            DrawSide(drawer, squareSize, Math.PI);
            DrawSide(drawer, squareSize, Math.PI / 2);
        }
        private static void DrawSide(Draw drawer, float size, double startingAngle)
        {
            var pen = new Pen(Brushes.Yellow);

            RefactorMe.Draw.MakeStep(pen, size * 0.375f, 0 + startingAngle);
            RefactorMe.Draw.MakeStep(pen, size * 0.04f * Math.Sqrt(2), Math.PI / 4 + startingAngle);
            RefactorMe.Draw.MakeStep(pen, size * 0.375f, Math.PI + startingAngle);
            RefactorMe.Draw.MakeStep(pen, size * 0.375f - size * 0.04f, Math.PI / 2 + startingAngle);

            RefactorMe.Draw.MakeStep(size * 0.04f, Math.PI + startingAngle);
            RefactorMe.Draw.MakeStep(size * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4 + startingAngle);
        }
    }
}
