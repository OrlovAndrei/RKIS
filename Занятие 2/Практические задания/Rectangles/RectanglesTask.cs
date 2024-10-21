using System;

namespace Rectangles;
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
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        return r1.Left <= r2.Right && r1.Right >= r2.Left &&
               r1.Top <= r2.Bottom && r1.Bottom >= r2.Top;
    }
    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        if (!AreIntersected(r1, r2))
        {
            return 0;
        }
        int intersectionLeft = Math.Max(r1.Left, r2.Left);
        int intersectionTop = Math.Max(r1.Top, r2.Top);
        int intersectionRight = Math.Min(r1.Right, r2.Right);
        int intersectionBottom = Math.Min(r1.Bottom, r2.Bottom);

        int width = intersectionRight - intersectionLeft;
        int height = intersectionBottom - intersectionTop;
        return Math.Max(0, width) * Math.Max(0, height);
    }
    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        bool r1InsideR2 = r1.Left >= r2.Left && r1.Right <= r2.Right &&
                          r1.Top >= r2.Top && r1.Bottom <= r2.Bottom;

        bool r2InsideR1 = r2.Left >= r1.Left && r2.Right <= r1.Right &&
                              r2.Top >= r1.Top && r2.Bottom <= r1.Bottom;

        if (r1InsideR2) return 1;  
        if (r2InsideR1) return 0;  

        return -1;  
    }
}
}











