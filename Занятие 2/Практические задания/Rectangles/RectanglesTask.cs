using System;

namespace Rectangles;

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
            }
            return 0;
    }
if (AreIntersected(r1, r2))
            {
            var left = Math.Max(Math.Min(r1.Left, r1.Right), Math.Min(r2.Right, r2.Left));
            var right = Math.Min(Math.Max(r1.Left, r1.Right), Math.Max(r2.Right, r2.Left));
            var top = Math.Max(Math.Min(r1.Top, r1.Bottom), Math.Min(r2.Top, r2.Bottom));
            var bottom = Math.Min(Math.Max(r1.Top, r1.Bottom), Math.Max(r2.Top, r2.Bottom));
            var width = Math.Max(right, left) - Math.Min(left, right);
            var height = Math.Max(top, bottom) - Math.Min(top, bottom);
            }
            return 0;
    
    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        return -1;
    }
}