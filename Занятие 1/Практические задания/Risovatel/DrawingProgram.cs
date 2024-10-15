using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe {
    class Risovatel {
        private float x, y;
        private IGraphics graphics;

        public void Initialization(IGraphics graphics) {
            graphics.Clear(Colors.Black);
        }

        public void SetPosition(float x0, float y0) {
            x = x0;
            y = y0;
        }

        public void MakeStep(Pen pen, double length, double corner) {
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
        public static void Draw(int canvasWidth, int canvasHeight, double angle, IGraphics graphics) {
        var drawer = new Risovatel();
        drawer.Initialization(graphics);

        var squareSize = Math.Min(canvasWidth, canvasHeight);
        var sideLength = Math.Sqrt(2) * (squareSize * 0.375f + squareSize * 0.04f) / 2;

        var centerX = (float)(sideLength * Math.Cos(Math.PI / 4 + Math.PI)) + canvasWidth / 2f;
        var centerY = (float)(sideLength * Math.Sin(Math.PI / 4 + Math.PI)) + canvasHeight / 2f;
        drawer.SetPosition(centerX, centerY);

        DrawSide(drawer, squareSize, Math.PI);
        DrawSide(drawer, squareSize, Math.PI + Math.PI / 2);
        DrawSide(drawer, squareSize, Math.PI + Math.PI);
        DrawSide(drawer, squareSize, Math.PI / 2);
    }

    private static void DrawSide(Risovatel drawer, float size, double startingAngle) {
        var pen = new Pen(Brushes.Yellow);

        drawer.MakeStep(pen, size * 0.375f, startingAngle);
        drawer.MakeStep(pen, size * 0.04f * Math.Sqrt(2), startingAngle + Math.PI / 4);
        drawer.MakeStep(pen, size * 0.375f, startingAngle + Math.PI);
        drawer.MakeStep(pen, size * 0.375f - size * 0.04f, startingAngle + Math.PI / 2);

        drawer.ChangePosition(size * 0.04f, startingAngle - Math.PI);
        drawer.ChangePosition(size * 0.04f * Math.Sqrt(2), startingAngle + 3 * Math.PI / 4);
    }
}
}
