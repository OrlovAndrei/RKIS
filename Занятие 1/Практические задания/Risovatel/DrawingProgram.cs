using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Risovatel
    {
        static float x, y;
        static IGraphics grafika;

        public static void Initialization ( IGraphics novayaGrafika )
        {
            grafika = novayaGrafika;
            //grafika.SmoothingMode = SmoothingMode.None;
            grafika.Clear(Colors.Black);
        }

        public static void set_position(float x0, float y0)
        {x = x0; y = y0;}

        public static void makeIt(Pen ruchka, double dlina, double ugol)
        {
        //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
        var x1 = (float)(x + dlina * Math.Cos(ugol));
        var y1 = (float)(y + dlina * Math.Sin(ugol));
        grafika.DrawLine(ruchka, x, y, x1, y1);
        x = x1;
        y = y1;
        }

        public static void Change(double dlina, double ugol)
        {
            x = (float)(x + dlina * Math.Cos(ugol)); 
           y = (float)(y + dlina * Math.Sin(ugol));
           }
    }
    
    public class ImpossibleSquare
{
    public static void Draw(int shirina, int visota, double ugolPovorota, IGraphics grafika)
    {
        // ugolPovorota пока не используется, но будет использоваться в будущем
        Risovatel.Initialization(grafika);

        var sz = Math.Min(shirina, visota);

        var diagonal_length = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
        var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + shirina / 2f;
        var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + visota / 2f;

        Risovatel.set_position(x0, y0);
        //Рисуем 1-ую сторону
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, 0);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI / 2);

        Risovatel.Change(sz * 0.04f, -Math.PI);
        Risovatel.Change(sz * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);

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
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI / 2);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI / 2 + Math.PI);
        Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI / 2 + Math.PI / 2);

        Risovatel.Change(sz * 0.04f, Math.PI / 2 - Math.PI);
        Risovatel.Change(sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
    }
}
}