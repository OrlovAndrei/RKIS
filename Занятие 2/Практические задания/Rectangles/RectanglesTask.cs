using System;

namespace Rectangles
{
    public struct Rectangle
    {
        public int X1, Y1, X2, Y2;

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public int Left => X1;
        public int Top => Y1;
        public int Right => X2;
        public int Bottom => Y2;
    }

    public static class RectanglesTask
    {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            return r1.Left <= r2.Right && r1.Right >= r2.Left &&
                   r1.Top <= r2.Bottom && r1.Bottom >= r2.Top;
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (!AreIntersected(r1, r2))
                return 0;

            int interLeft = Math.Max(r1.Left, r2.Left);
            int interTop = Math.Max(r1.Top, r2.Top);
            int interRight = Math.Min(r1.Right, r2.Right);
            int interBottom = Math.Min(r1.Bottom, r2.Bottom);

            int width = interRight - interLeft;
            int height = interBottom - interTop;

            // Проверка на вырожденный случай
            if (width <= 0 || height <= 0)
                return 0;

            return width * height;
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            bool r1InsideR2 = r1.Left >= r2.Left && r1.Right <= r2.Right &&
                              r1.Top >= r2.Top && r1.Bottom <= r2.Bottom;

            bool r2InsideR1 = r2.Left >= r1.Left && r2.Right <= r1.Right &&
                              r2.Top >= r1.Top && r2.Bottom <= r1.Bottom;

            if (r1InsideR2)
                return 1; // r1 внутри r2
            if (r2InsideR1)
                return 0; // r2 внутри r1

            return -1; // Нет вложенности
        }
    }
}
