using System;


namespace Rectangles
{
    public static class RectanglesTask
    {
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {

            var left = Math.Max(Math.Min(r1.Left, r1.Right), Math.Min(r2.Right, r2.Left));
            var right = Math.Min(Math.Max(r1.Left, r1.Right), Math.Max(r2.Right, r2.Left));
            var top = Math.Max(Math.Min(r1.Top, r1.Bottom), Math.Min(r2.Top, r2.Bottom));
            var bottom = Math.Min(Math.Max(r1.Top, r1.Bottom), Math.Max(r2.Top, r2.Bottom));
            var width = Math.Max(right, left) - Math.Min(left, right);
            var height = Math.Max(top, bottom) - Math.Min(top, bottom);
            if (right < left || bottom < top) return false;
            return true;
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (AreIntersected(r1, r2))
            {
                 
                var left = Math.Max(Math.Min(r1.Left, r1.Right), Math.Min(r2.Right, r2.Left));
                var right = Math.Min(Math.Max(r1.Left, r1.Right), Math.Max(r2.Right, r2.Left));
                var top = Math.Max(Math.Min(r1.Top, r1.Bottom), Math.Min(r2.Top, r2.Bottom));
                var bottom = Math.Min(Math.Max(r1.Top, r1.Bottom), Math.Max(r2.Top, r2.Bottom));
                var width = Math.Max(right, left) - Math.Min(left, right);
                var height = Math.Max(top, bottom) - Math.Min(top, bottom);
                return width * height;
            }
            return 0;
        }
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (r2.Top >= r1.Top && r2.Left >= r1.Left && r2.Right <= r1.Right && r2.Bottom <= r1.Bottom) return 1;// r2 внутри
            else if (r1.Top >= r2.Top && r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Bottom <= r2.Bottom) return 0;// r1 внутри
            else return -1;
        }
    }
}