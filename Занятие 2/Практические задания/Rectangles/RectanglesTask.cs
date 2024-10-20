using System;

namespace Rectangles;

public static class RectanglesTask
{
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
        var left = Math.Max(Math.Min(r1!.Left, r1!.Right), Math.Min(r2.Left, r2.Right));
        var right = Math.Min(Math.Max(r1!.Left, r1!.Right), Math.Max(r2.Left, r2.Right));
        var bottom = Math.Min(Math.Max(r1!.Top, r1!.Bottom), Math.Max(r2.Top, r2.Bottom));
        var top = Math.Max(Math.Min(r1.Top, r1.Bottom), Math.Min(r2.Top, r2.Bottom));
        if (right < left || bottom < top)
        {
            return false;
        }
        return true;
    }
    // Площадь пересечения прямоугольников
    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        if (AreIntersected(r1, r2))
        {
            var left = Math.Max(Math.Min(r1.Left, r1.Right), Math.Min(r2.Left, r2.Right));
            var right = Math.Min(Math.Max(r1.Left, r1.Right), Math.Max(r2.Left, r2.Right));
            var bottom = Math.Min(Math.Max(r1.Top, r1.Bottom), Math.Max(r2.Top, r2.Bottom));
            var top = Math.Max(Math.Min(r1.Top, r1.Bottom), Math.Min(r2.Top, r2.Bottom));
            var height = Math.Max(right, left) - Math.Min(left, right);
            var width = Math.Max(bottom, top) - Math.Min(top, bottom);
            return height * width;
        }
        return 0;
    }

	    @@ -22,6 + 39,17 @@ public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        if (r1.Top >= r2.Top && r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Bottom <= r2.Bottom)
        {
            return 0;
        }
        else if (r2.Top >= r1.Top && r2.Left >= r1.Left && r2.Right <= r1.Right && r2.Bottom <= r1.Bottom)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}