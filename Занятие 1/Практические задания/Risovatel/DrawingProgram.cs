using System;
using Avalonia.Media;

namespace RefactorMe
{
    class Painter
    {
        private static float currentX, currentY;
        private static IGraphics graphics;

        private const float SquareSideRatio = 0.375f;
        private const float LineThickness = 0.04f;

        public static void Initialize(IGraphics newGraphics)
        {
            graphics = newGraphics;
            graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x, float y)
        {
            currentX = x;
            currentY = y;
        }

        public static void DrawLine(Pen pen, double length, double angle)
        {
            var xEnd = (float)(currentX + length * Math.Cos(angle));
            var yEnd = (float)(currentY + length * Math.Sin(angle));
            graphics.DrawLine(pen, currentX, currentY, xEnd, yEnd);
            currentX = xEnd;
            currentY = yEnd;
        }

        public static void ChangePosition(double length, double angle)
        {
            currentX += (float)(length * Math.Cos(angle));
            currentY += (float)(length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double rotationAngle, IGraphics graphics)
        {
            Painter.Initialize(graphics);

            var squareSize = Math.Min(width, height);
            var diagonalLength = Math.Sqrt(2) * (squareSize * SquareSideRatio + squareSize * LineThickness) / 2;
            var centerX = width / 2f;
            var centerY = height / 2f;

            var startX = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + centerX;
            var startY = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + centerY;

            Painter.SetPosition(startX, startY);

            for (int i = 0; i < 4; i++)
            {
                DrawSquareSide(squareSize, i * Math.PI / 2);
            }
        }

        private static void DrawSquareSide(int size, double startAngle)
        {
            Painter.DrawLine(new Pen(Brushes.Yellow), size * SquareSideRatio, startAngle);
            Painter.DrawLine(new Pen(Brushes.Yellow), size * LineThickness * Math.Sqrt(2), startAngle + Math.PI / 4);
            Painter.DrawLine(new Pen(Brushes.Yellow), size * SquareSideRatio, startAngle + Math.PI);
            Painter.DrawLine(new Pen(Brushes.Yellow), size * SquareSideRatio - size * LineThickness, startAngle + Math.PI / 2);

            Painter.ChangePosition(size * LineThickness, startAngle + Math.PI);
            Painter.ChangePosition(size * LineThickness * Math.Sqrt(2), startAngle + 3 * Math.PI / 4);
        }
    }
}