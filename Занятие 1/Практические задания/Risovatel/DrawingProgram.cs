using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Drawer
    {
        private static float positionX, positionY;
        private static IGraphics graphics;

        private const float LineLengthFactor = 0.375f;
        private const float SmallLineLengthFactor = 0.04f;

        public static void Initialize(IGraphics newGraphics)
        {
            graphics = newGraphics;
            graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x, float y)
        {
            positionX = x;
            positionY = y;
        }

        public static void DrawLine(Pen pen, double length, double angle)
        {
            // Draws a line of a given length in the specified direction
            var endX = (float)(positionX + length * Math.Cos(angle));
            var endY = (float)(positionY + length * Math.Sin(angle));
            graphics.DrawLine(pen, positionX, positionY, endX, endY);
            positionX = endX;
            positionY = endY;
        }

        public static void Move(double length, double angle)
        {
            positionX += (float)(length * Math.Cos(angle));
            positionY += (float)(length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double rotationAngle, IGraphics graphics)
        {
            // rotationAngle is not used yet, but will be used in the future
            Drawer.Initialize(graphics);

            var size = Math.Min(width, height);
            var diagonalLength = CalculateDiagonalLength(size);
            var startX = CalculateStartX(diagonalLength, width);
            var startY = CalculateStartY(diagonalLength, height);

            Drawer.SetPosition(startX, startY);
            DrawSquare(size);
        }

        private static double CalculateDiagonalLength(int size)
        {
            return Math.Sqrt(2) * (size * LineLengthFactor + size * SmallLineLengthFactor) / 2;
        }

        private static float CalculateStartX(double diagonalLength, int width)
        {
            return (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
        }

        private static float CalculateStartY(double diagonalLength, int height)
        {
            return (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;
        }

        private static void DrawSquare(int size)
        {
            // Draw the first side
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor, 0);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * SmallLineLengthFactor * Math.Sqrt(2), Math.PI / 4);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor, Math.PI);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor - size * SmallLineLengthFactor, Math.PI / 2);

            Drawer.Move(size * SmallLineLengthFactor, -Math.PI);
            Drawer.Move(size * SmallLineLengthFactor * Math.Sqrt(2), 3 * Math.PI / 4);

            // Draw the second side
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor, -Math.PI / 2);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * SmallLineLengthFactor * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor, -Math.PI / 2 + Math.PI);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor - size * SmallLineLengthFactor, -Math.PI / 2 + Math.PI / 2);

            Drawer.Move(size * SmallLineLengthFactor, -Math.PI / 2 - Math.PI);
            Drawer.Move(size * SmallLineLengthFactor * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

            // Draw the third side
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor, Math.PI);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * SmallLineLengthFactor * Math.Sqrt(2), Math.PI + Math.PI / 4);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor, Math.PI + Math.PI);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor - size * SmallLineLengthFactor, Math.PI + Math.PI / 2);

            Drawer.Move(size * SmallLineLengthFactor, Math.PI - Math.PI);
            Drawer.Move(size * SmallLineLengthFactor * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

            // Draw the fourth side
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor, Math.PI / 2);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * SmallLineLengthFactor * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor, Math.PI / 2 + Math.PI);
            Drawer.DrawLine(new Pen(Brushes.Yellow), size * LineLengthFactor - size * SmallLineLengthFactor, Math.PI / 2 + Math.PI / 2);

            Drawer.Move(size * SmallLineLengthFactor, Math.PI / 2 - Math.PI);
            Drawer.Move(size * SmallLineLengthFactor * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }
    }
}