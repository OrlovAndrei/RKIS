using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Risovatel
    {
        static float x, y;
        static IGraphics graphic ~grafika~; 

        public static void Initialization ( IGraphics newGraphic ~novayaGrafika~)
        {
            graphic ~grafika~= newGraphic ~novayaGrafika~;
            //graphic ~grafika~.SmoothingMode = SmoothingMode.None;
            graphic ~grafika~.Clear(Colors.Black);
        } 

        public static void set_position(float x0, float y0)
        {x = x0; y = y0;} 

        public static void makeIt(Pen pen ~ruchka~ , double length ~dlina~, double ~ugol~ angle)
        {
        //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
        var x1 = (float)(x + length ~dlina~ * Math.Cos(~ugol~ angle));
        var y1 = (float)(y + ~dlina~length * Math.Sin(~ugol~ angle));
        ~grafika~ graphic.DrawLine(~ruchka~ pen, x, y, x1, y1);
        x = x1;
        y = y1;
        } 

        public static void Change(double ~dlina~ length, double ~ugol~ angle)
        {
            x = (float)(x + ~dlina~ length * Math.Cos(~ugol~ angle)); 
           y = (float)(y + ~dlina~ length * Math.Sin(~ugol~ angle));
           }
    }
    
    public class ImpossibleSquare
{
    public static void Draw(int ~shirina~ width, int ~visota~ height, double ~ugolPovorota~ rotationAngle, IGraphics ~grafika~ graphic) 
    {
        // ugolPovorota пока не используется, но будет использоваться в будущем
        Risovatel.Initialization ~grafika~(graphic); 

        var sz = Math.Min ~shirina, visota~ (width, height); 

        var ~diagonal_length~ diagonalLength(?)= Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
        var x0 = (float) ~diagonal_length~ (diagonalLenght * Math.Cos(Math.PI / 4 + Math.PI)) + ~shirina~ width / 2f;
        var y0 = (float)(~diagonal_length~ diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + ~visota~ height / 2f; 

        ~Risovatel~ Painter.set_position(x0, y0);
        //Рисуем 1-ую сторону
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, 0);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI / 4);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI / 2); 

        ~Risovatel~ Painter.Change(sz * 0.04f, -Math.PI);
        ~Risovatel~ Painter.Change(sz * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4); 

        //Рисуем 2-ую сторону
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, -Math.PI / 2);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, -Math.PI / 2 + Math.PI);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, -Math.PI / 2 + Math.PI / 2); 

        ~Risovatel~ Painter.Change(sz * 0.04f, -Math.PI / 2 - Math.PI);
        ~Risovatel~ Painter.Change(sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4); 

        //Рисуем 3-ю сторону
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI + Math.PI);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI + Math.PI / 2); 

        ~Risovatel~ Painter.Change(sz * 0.04f, Math.PI - Math.PI);
        ~Risovatel~ Painter.Change(sz * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4); 

        //Рисуем 4-ую сторону
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI / 2);

> Agni36:
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI / 2 + Math.PI);
        ~Risovatel~ Painter.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI / 2 + Math.PI / 2); 

        ~Risovatel~ Painter.Change(sz * 0.04f, Math.PI / 2 - Math.PI);
        ~Risovatel~ Painter.Change(sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
    }
}
}

