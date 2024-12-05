using System;
using Avalonia.Media;
using Risovalka.Common;

namespace Risovalka
{
    class Drawer
    {
        static float x, y;
        static IGraphics graphics;

        public static void Initialization ( IGraphics newGraphics )
        {
            graphics = newGraphics;
            //graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float newX, float newY)
        {
            x = newX;
            y = newY;
        }

        public static void DrawStep(Pen pen, double length, double angle)
        {
        var newX = (float)(x + length * Math.Cos(angle));
            var newY = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, newX, newY);
            x = newX;
            y = newY;
        }

        public static void MoveWithoutDrawing(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle)); 
            y = (float)(y + length * Math.Sin(angle));
        }
    }
    
    public class ImpossibleSquare
    {
        const double SideProportion = 0.375;
        const double DiagonalProportion = 0.04;
        const double PiOverFour = Math.PI / 4;

        public static void Draw(int width, int height, double rotationAngle, IGraphics graphics)
        {
            Drawer.Initialization(graphics);

            var size = Math.Min(width, height);
            var diagonalLength = Math.Sqrt(2) * (size * SideProportion + size * DiagonalProportion) / 2;
            var xStart = (float)(diagonalLength * Math.Cos(PiOverFour + Math.PI)) + width / 2f;
            var yStart = (float)(diagonalLength * Math.Sin(PiOverFour + Math.PI)) + height / 2f;

            Drawer.set_position(xStart, yStart);

            //Рисуем стороны квадрата
            DrawSide(size, pen, 0);
            DrawSide(size, pen, -Math.PI / 2);
            DrawSide(size, pen, Math.PI);
            DrawSide(size, pen, Math.PI / 2);
        }

        private static void DrawSide(int size, Pen pen, double angle)
        {
            Drawer.DrawStep(pen, size * SideProportion, angle);
            Drawer.DrawStep(pen, size * DiagonalProportion * Math.Sqrt(2), angle + PiOverFour);
            Drawer.DrawStep(pen, size * SideProportion, angle + Math.PI);
            Drawer.DrawStep(pen, size * (SideProportion - DiagonalProportion), angle + Math.PI / 2);

            Drawer.MoveWithoutDrawing(size * DiagonalProportion, angle + Math.PI);
            Drawer.MoveWithoutDrawing(size * DiagonalProportion * Math.Sqrt(2), angle + 3 * PiOverFour);
        }
    }
}