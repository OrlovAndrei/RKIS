using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Draw
    {
        private static float currentX, currentY;
        private static IGraphics graphics;

        public static void Initialization ( IGraphics NewGraphics )
        {
            graphics = NewGraphics;
            graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            currentX = x0;
            currentY = y0;
        }

        public static void DrawLine(Pen pen, double length, double angle)
        {
            var newX = (float)(currentX + length * Math.Cos(angle));
            var newY = (float)(currentY + length * Math.Sin(angle));
            graphics.DrawLine(pen, currentX, currentY, newX, newY);
            currentX = newX;
            currentY = newY;
        }

        public static void Move(double length, double angle)
        {
            currentX = (float)(currentX + length * Math.Cos(angle));
            currentY = (float)(currentY + length * Math.Sin(angle));
        }
    }
    
    public class ImpossibleSquare
    {
        private const double SquareFactor = 0.375;
        private const double SmallFactor = 0.04;
        
        public static void Draw(int width, int height, double rotationAngle, IGraphics graphics)
        {
            Draw.Initialize(graphics);
            
            var size = Math.Min(width, height);

            var diagonalLength = CalculateDiagonalLength(size);
            var initialX = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + widt / 2f;
            var initialY = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Draw.SetPosition(initialX, initialY);
            DrawSide(size, rotationAngle, 0);
            DrawSide(size, rotationAngle, -Math.PI / 2);
            DrawSide(size, rotationAngle, Math.PI);
            DrawSide(size, rotationAngle, Math.PI / 2);
        }
        
        private static double CalculateDiagonalLength(int size)
        {
            return Math.Sqrt(2) * (size * SquareFactor + size * SmallFactor) / 2;
        }

        private static void DrawSide(int size, double rotationAngle, double startAngle)
        {
            Draw.DrawLine(new Pen(Brushes.Yellow), size * SquareFactor, startAngle);
            Draw.DrawLine(new Pen(Brushes.Yellow), size * SmallFactor * Math.Sqrt(2), startAngle + Math.PI / 4);
            Draw.DrawLine(new Pen(Brushes.Yellow), size * SquareFactor, startAngle + Math.PI);
            Draw.DrawLine(new Pen(Brushes.Yellow), size * SquareFactor - size * SmallFactor, startAngle + Math.PI / 2);

            Draw.Move(size * SmallFactor, startAngle + Math.PI);
            Draw.Move(size * SmallFactor * Math.Sqrt(2), startAngle + 3 * Math.PI / 4);
        }
    }
}
