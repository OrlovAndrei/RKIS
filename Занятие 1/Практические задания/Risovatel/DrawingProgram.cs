using System;
using System.Runtime.Intrinsics;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Risovatel
    {
        static float x, y;
        static IGraphics graphic;

        public static void Initialization ( IGraphics newGraphic )
        {
            graphic = newGraphic;
            //graphic.SmoothingMode = SmoothingMode.None;
            graphic.Clear(Colors.Black);
        }

        public static void set_position(float x0, float y0)
        {x = x0; y = y0;}

        public static void makeIt(Pen pen, double length, double corner)
        {
        //Делает шаг длиной length в направлении corner и рисует пройденную траекторию
        var x1 = (float)(x + length * Math.Cos(corner));
        var y1 = (float)(y + length * Math.Sin(corner));
        graphic.DrawLine(pen, x, y, x1, y1);
        x = x1;
        y = y1;
        }

        public static void Change(double length, double corner)
        {
           x = (float)(x + length * Math.Cos(corner)); 
           y = (float)(y + length * Math.Sin(corner));
        }
    }
    
    public class ImpossibleSquare
{
    public static void Draw(int width, int height, double AngleOfRotation, IGraphics graphic)
    {
            // AngleOfRotation пока не используется, но будет использоваться в будущем
            Risovatel.Initialization(graphic);

        var sz = Math.Min(width, height);

        var diagonal_length = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
        var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
        var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

        Risovatel.set_position(x0, y0);

        //Рисуем 1-ую сторону
        Risovatel.makeIt(new Pen(Brushes.Red), sz * 0.375f, 0);
        Risovatel.makeIt(new Pen(Brushes.Red), sz * 0.04f * Math.Sqrt(2), Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Red), sz * 0.375f, Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Red), sz * 0.375f - sz * 0.04f, Math.PI / 2);

        Risovatel.Change(sz * 0.04f, -Math.PI);
        Risovatel.Change(sz * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);

        //Рисуем 2-ую сторону
        Risovatel.makeIt(new Pen(Brushes.Blue), sz * 0.375f, -Math.PI / 2);
        Risovatel.makeIt(new Pen(Brushes.Blue), sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Blue), sz * 0.375f, -Math.PI / 2 + Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Blue), sz * 0.375f - sz * 0.04f, -Math.PI / 2 + Math.PI / 2);

        Risovatel.Change(sz * 0.04f, -Math.PI / 2 - Math.PI);
        Risovatel.Change(sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

        //Рисуем 3-ю сторону
        Risovatel.makeIt(new Pen(Brushes.Orange), sz * 0.375f, Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Orange), sz * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Orange), sz * 0.375f, Math.PI + Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Orange), sz * 0.375f - sz * 0.04f, Math.PI + Math.PI / 2);

        Risovatel.Change(sz * 0.04f, Math.PI - Math.PI);
        Risovatel.Change(sz * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

        //Рисуем 4-ую сторону
        Risovatel.makeIt(new Pen(Brushes.BlueViolet), sz * 0.375f, Math.PI / 2);
        Risovatel.makeIt(new Pen(Brushes.BlueViolet), sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.BlueViolet), sz * 0.375f, Math.PI / 2 + Math.PI);
        Risovatel.makeIt(new Pen(Brushes.BlueViolet), sz * 0.375f - sz * 0.04f, Math.PI / 2 + Math.PI / 2);

        //Risovatel.Change(sz * 0.04f, Math.PI / 2 - Math.PI);
        //Risovatel.Change(sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
    }
}
}