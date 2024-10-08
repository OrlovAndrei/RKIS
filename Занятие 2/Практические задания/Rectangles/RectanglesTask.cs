using System;

namespace Rectangles
{
    public class Rectangle
    {
        public int Left { get; }
        public int Top { get; }
        public int Right { get; }
        public int Bottom { get; }

        public Rectangle(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }

    public static class RectanglesTask
    {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            // Проверяем, не находятся ли прямоугольники друг за другом
            return !(r1.Right < r2.Left || r1.Left > r2.Right || r1.Bottom < r2.Top || r1.Top > r2.Bottom);
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            // Если прямоугольники не пересекаются, площадь равна 0
            if (!AreIntersected(r1, r2))
            {
                return 0;
            }

            // Вычисляем координаты пересечения
            int intersectLeft = Math.Max(r1.Left, r2.Left);
            int intersectTop = Math.Max(r1.Top, r2.Top);
            int intersectRight = Math.Min(r1.Right, r2.Right);
            int intersectBottom = Math.Min(r1.Bottom, r2.Bottom);

            // Ширина и высота пересечения
            int width = Math.Max(0, intersectRight - intersectLeft);
            int height = Math.Max(0, intersectBottom - intersectTop);

            return width * height;
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            bool r1InsideR2 = r1.Left >= r2.Left && r1.Top >= r2.Top && r1.Right <= r2.Right && r1.Bottom <= r2.Bottom;
            bool r2InsideR1 = r2.Left >= r1.Left && r2.Top >= r1.Top && r2.Right <= r1.Right && r2.Bottom <= r1.Bottom;

            if (r1InsideR2) return 1; // r1 находится внутри r2
            if (r2InsideR1) return 0; // r2 находится внутри r1
            return -1; // нет вложенности
        }
    }
}
