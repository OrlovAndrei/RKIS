using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe {
    // думал поменять название класса, но не стал этого делать
    class Risovatel {
        private float x, y;
        private IGraphics graphics;

        public void Initialization(IGraphics graphics) {
            // graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Colors.Black);
        }

        public void SetPosition(float x0, float y0) {
            x = x0;
            y = y0;
        }

        public void MakeStep(Pen pen, double length, double corner) {
            // Делает шаг длиной length в направлении corner и рисует пройденную
            // траекторию
            var x1 = (float)(x + length * Math.Cos(corner));
            var y1 = (float)(y + length * Math.Sin(corner));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public void ChangePosition(double length, double corner) {
            x = (float)(x + length * Math.Cos(corner));
            y = (float)(y + length * Math.Sin(corner));
        }
    }

    public class ImpossibleSquare {
        public static void Draw(
            int width, int height, double angle, IGraphics graphics) {
            // angle пока не используется, но будет использоваться в будущем
            var risovatel = new Risovatel();
            risovatel.Initialization(graphics);

            var sz = Math.Min(width, height);

            var sideLength = Math.Sqrt(2) * (sz * 0.375 f + sz * 0.04 f) / 2;
            var x0 = (float)(sideLength * Math.Cos(Math.PI / 4 + Math.PI)) +
                width / 2 f;
            var y0 = (float)(sideLength * Math.Sin(Math.PI / 4 + Math.PI)) +
                height / 2 f;

            risovatel.SetPosition(x0, y0);

            // Рисуем 1-ую сторону
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.375 f, 0);
            risovatel.MakeStep(
                new Pen(Brushes.Yellow), sz * 0.04 f * Math.Sqrt(2), Math.PI / 4);
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.375 f, Math.PI);
            risovatel.MakeStep(
                new Pen(Brushes.Yellow), sz * 0.375 f - sz * 0.04 f, Math.PI / 2);

            risovatel.ChangePosition(sz * 0.04 f, -Math.PI);
            risovatel.ChangePosition(sz * 0.04 f * Math.Sqrt(2), 3 * Math.PI / 4);

            // Рисуем 2-ую сторону
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.375 f, -Math.PI / 2);
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.04 f * Math.Sqrt(2),
                -Math.PI / 2 + Math.PI / 4);
            risovatel.MakeStep(
                new Pen(Brushes.Yellow), sz * 0.375 f, -Math.PI / 2 + Math.PI);
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.375 f - sz * 0.04 f,
                -Math.PI / 2 + Math.PI / 2);

            risovatel.ChangePosition(sz * 0.04 f, -Math.PI / 2 - Math.PI);
            risovatel.ChangePosition(
                sz * 0.04 f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);

            // Рисуем 3-ю сторону
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.375 f, Math.PI);
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.04 f * Math.Sqrt(2),
                Math.PI + Math.PI / 4);
            risovatel.MakeStep(
                new Pen(Brushes.Yellow), sz * 0.375 f, Math.PI + Math.PI);
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.375 f - sz * 0.04 f,
                Math.PI + Math.PI / 2);

            risovatel.ChangePosition(sz * 0.04 f, Math.PI - Math.PI);
            risovatel.ChangePosition(
                sz * 0.04 f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);

            // Рисуем 4-ую сторону
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.375 f, Math.PI / 2);
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.04 f * Math.Sqrt(2),
                Math.PI / 2 + Math.PI / 4);
            risovatel.MakeStep(
                new Pen(Brushes.Yellow), sz * 0.375 f, Math.PI / 2 + Math.PI);
            risovatel.MakeStep(new Pen(Brushes.Yellow), sz * 0.375 f - sz * 0.04 f,
                Math.PI / 2 + Math.PI / 2);

            risovatel.ChangePosition(sz * 0.04 f, Math.PI / 2 - Math.PI);
            risovatel.ChangePosition(
                sz * 0.04 f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }
    }
}
