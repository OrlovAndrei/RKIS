using System;

namespace Rectangles;

public static class RectanglesTask
{
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        if (r1.Right < r2.Left) {
            return false;
        }
        if (r1.Left > r2.Right) {
            return false;
        }
        if (r1.Bottom < r2.Top) {
            return false;
        }
        if (r1.Top > r2.Bottom) {
            return false;
        }
    }

    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        if (!AreIntersected(r1, r2)) {
            return 0;
        }

        int intersectionLeft = Math.Max(r1.Left, r2.Left);
        int intersectionTop = Math.Max(r1.Top, r2.Top);
        int intersectionRight = Math.Min(r1.Right, r2.Right);
        int intersectionBottom = Math.Min(r1.Bottom, r2.Bottom);

        int width = intersectionRight - intersectionLeft;
        int height = intersectionBottom - intersectionTop;

        return width * height;
    }

    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        bool isR1InsideR2 = r1.Left >= r2.Left && r1.Right <= r2.Right &&
                            r1.Top >= r2.Top && r1.Bottom <= r2.Bottom;

        bool isR2InsideR1 = r2.Left >= r1.Left && r2.Right <= r1.Right &&
                            r2.Top >= r1.Top && r2.Bottom <= r1.Bottom;

        if (isR1InsideR2) {
            return 1;
        } else if (isR2InsideR1) {
            return 0;
        }
        return -1;
    }
}
