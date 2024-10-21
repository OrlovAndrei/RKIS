using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Risovatel
    {
        static float x, y;
        static IGraphics Graphics;

        public static void Initialization ( IGraphics NewGraphics )
        {
            Graphics = NewGraphics;
            //grafika.SmoothingMode = SmoothingMode.None;
            Graphics.Clear(Colors.Black);
        }

        public static void set_position(float x0, float y0)
        {x = x0; y = y0;}

        public static void makeIt(Pen pen, double Length, double Angle)
        {
        //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
        var x1 = (float)(x + Length * Math.Cos(Angle));
        var y1 = (float)(y + Length * Math.Sin(Angle));
        Graphics.DrawLine(pen, x, y, x1, y1);
        x = x1;
        y = y1;
        }

        public static void Change(double Length, double Angle)
        {
            x = (float)(x + Length * Math.Cos(Angle)); 
           y = (float)(y + Length * Math.Sin(Angle));
           }
    }
    
    public class ImpossibleSquare
{
    public static void Draw(int Width, int Height, IGraphics grafika)
        {
            // ugolPovorota пока не используется, но будет использоваться в будущем
            Risovatel.Initialization(grafika);

            var sz = Math.Min(Width, Height);

            var diagonal_length = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + Width / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + Height / 2f;

            Risovatel.set_position(x0, y0);
            //Рисуем 1-ую сторону
            DrawingFirstWall(sz);

            //Рисуем 2-ую сторону
            DrawingSecondWall(sz);

            //Рисуем 3-ю сторону
            DrawingThirdWall(sz);

            //Рисуем 4-ую сторону
            DrwingFourthWall(sz);

            static void DrawingFirstWall(int sz)
            {
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, 0);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI / 4);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI / 2);

                Risovatel.Change(sz * 0.04f, -Math.PI);
                Risovatel.Change(sz * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);
            }

            static void DrawingSecondWall(int sz)
            {
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, -Math.PI / 2);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, -Math.PI / 2 + Math.PI);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, -Math.PI / 2 + Math.PI / 2);

                Risovatel.Change(sz * 0.04f, -Math.PI / 2 - Math.PI);
                Risovatel.Change(sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);
            }

            static void DrawingThirdWall(int sz)
            {
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI + Math.PI);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI + Math.PI / 2);

                Risovatel.Change(sz * 0.04f, Math.PI - Math.PI);
                Risovatel.Change(sz * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);
            }

            static void DrwingFourthWall(int sz)
            {
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI / 2);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f, Math.PI / 2 + Math.PI);
                Risovatel.makeIt(new Pen(Brushes.Yellow), sz * 0.375f - sz * 0.04f, Math.PI / 2 + Math.PI / 2);

                Risovatel.Change(sz * 0.04f, Math.PI / 2 - Math.PI);
                Risovatel.Change(sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
            }
        }
    }
}