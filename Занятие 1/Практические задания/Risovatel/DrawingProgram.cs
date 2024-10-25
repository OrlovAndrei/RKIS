using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Risovatel
    {
        static float x, y;
        static IGraphics Graphics;

        public static void Initialization ( IGraphics newGraphics )
        {
            Graphics = newGraphics;
            //grafika.SmoothingMode = SmoothingMode.None;
            Graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        {x = x0; y = y0; }

        public static void makestep(Pen pen, double lenght, double corner)
        {
        //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
        var x1 = (float)(x + lenght * Math.Cos(corner));
        var y1 = (float)(y + lenght * Math.Sin(corner));
        graphics.DrawLine(pen, x, y, x1, y1);
        x = x1;
        y = y1;
        }

        public static void ChangePosition(double lenght, double corner)
        {
            x = (float)(x + lenght * Math.Cos(corner)); 
           y = (float)(y + lenght * Math.Sin(corner));
           }
    }
    
    public class ImpossibleSquare
{
    public static void Draw(int width, int height, double cornerPovorota, IGraphics graphics)
    {
        // ugolPovorota пока не используется, но будет использоваться в будущем
        Risovatel.Initialization(graphics);

        var sz = Math.Min(width, height);

        var diagonal_length = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
        var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + width/ 2f;
        var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

        Risovatel.set_position(x0, y0);
        //Рисуем 1-ую сторону
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, 0);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI / 2);

        var size = Math.Min(width, height);
        var Length = Math.Sqrt(2) * (Size * 0.375f + Size * 0.04f) / 2;

        //Рисуем 2-ую сторону
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, -Math.PI / 2);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, -Math.PI / 2 + Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, -Math.PI / 2 + Math.PI / 2);

        Risovatel.Change(sz * 0.04f, -Math.PI / 2 - Math.PI);
        Risovatel.Change(sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

        //Рисуем 3-ю сторону
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI + Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI + Math.PI / 2);

        Risovatel.Change(sz * 0.04f, Math.PI - Math.PI);
        Risovatel.Change(sz * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

        //Рисуем 4-ую сторону
        DrawSide(size, 0);
        DrawSide(size, -Math.PI / 2);
        DrawSide(size, Math.PI);
        DrawSide(size, Math.PI / 2);

        Risovatel.Change(sz * 0.04f, Math.PI / 2 - Math.PI);
        Risovatel.Change(sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
    }
}
}