﻿using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Artist
    {
        static float x, y;
        static IGraphics graphics;

        public static void Initialize(IGraphics NewGraphics)
        {
            graphics = NewGraphics;
            graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void MakeIt(Pen pen, double length, double angle)
        {
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double angle, IGraphics graphics)
        {
            Artist.Initialize(graphics);

            var size = Math.Min(width, height);

            var diagonal_length = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Artist.Set_position(x0, y0);
            DrawSide(size, 0);
            DrawSide(size, -Math.PI / 2);
            DrawSide(size, Math.PI);
            DrawSide(size, Math.PI / 2);
        }

        private static void DrawSide(int size, double angle)
        {
            Artist.MakeIt(new Pen(Brushes.Yellow), size * 0.375f, angle);
            Artist.MakeIt(new Pen(Brushes.Yellow), size * 0.04f * Math.Sqrt(2), angle + Math.PI / 4);
            Artist.MakeIt(new Pen(Brushes.Yellow), size * 0.375f, angle + Math.PI);
            Artist.MakeIt(new Pen(Brushes.Yellow), size * 0.375f - size * 0.04f, angle + Math.PI / 2);
            Artist.Change(size * 0.04f, angle + Math.PI);
            Artist.Change(size * 0.04f * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }
    }
}