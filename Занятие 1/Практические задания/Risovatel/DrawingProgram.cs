using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Risovatel
    {
        static float x, y;
        static IGraphics graphics;

        public static void Initialization ( IGraphics newGraphics )
        {
            graphics = newGraphics;
            //grafika.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        { x = x0; y = y0; }

        public static void MakeStep(Pen pen, double length, double angle)
        {
        //Делает шаг длиной lenght в направлении angle и рисует пройденную траекторию
            var x1 = (float)(x + lenght * Math.Cos(angle));
            var y1 = (float)(y + lenght * Math.Sin(angle));
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
        // double angle пока не используется, но будет использоваться в будущем
        Risovatel.Initialization(graphics);

        var size = Math.Min(width, height);

        var length = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
        var x0 = (float)(length * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
        var y0 = (float)(length * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

        Risovatel.set_position(x0, y0);
        //Рисуем 1-ую сторону
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f, 0);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.04f * Math.Sqrt(2), Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f, Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f - size * 0.04f, Math.PI / 2);

        Risovatel.Change(size * 0.04f, -Math.PI);
        Risovatel.Change(size * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);

        //Рисуем 2-ую сторону
        Risovatel.makeIt(new Pen(Brushes.Yellow), sizez * 0.375f, -Math.PI / 2);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f, -Math.PI / 2 + Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f - size * 0.04f, -Math.PI / 2 + Math.PI / 2);

        Risovatel.Change(size * 0.04f, -Math.PI / 2 - Math.PI);
        Risovatel.Change(size * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

        //Рисуем 3-ю сторону
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f, Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f, Math.PI + Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f - size * 0.04f, Math.PI + Math.PI / 2);

        Risovatel.Change(size * 0.04f, Math.PI - Math.PI);
        Risovatel.Change(size * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

        //Рисуем 4-ую сторону
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f, Math.PI / 2);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f, Math.PI / 2 + Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), size * 0.375f - size * 0.04f, Math.PI / 2 + Math.PI / 2);

        Risovatel.Change(size * 0.04f, Math.PI / 2 - Math.PI);
        Risovatel.Change(size * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
    }
}
}