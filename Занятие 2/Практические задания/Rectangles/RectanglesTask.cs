
using System;
 
namespace Rectangles
{
    public static class RectanglesTask
    {
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            return !(r1.Left > r2.Right || r1.Top > r2.Bottom || r1.Right < r2.Left || r1.Bottom < r2.Top);
        }
 
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (AreIntersected(r1, r2))
            {
                if (r1.Left == r2.Right || r1.Top == r2.Bottom || r1.Right == r2.Left || r1.Bottom == r2.Top)
                    return 0;
                else
                {
                    int maximumLeft = Math.Max(r1.Left, r2.Left);
                    int minimumLeftWeight = Math.Min(r1.Right, r2.Right);
                    int maximumTop = Math.Max(r1.Top, r2.Top);
                    int minimumTopHeight = Math.Min(r1.Bottom, r2.Bottom);
                    return (minimumLeftWeight - maximumLeft) * (minimumTopHeight - maximumTop);
                }
            }
            return 0;
        }
 
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (r1.Left <= r2.Left && r1.Right >= r2.Right && r1.Bottom >= r2.Bottom && r1.Top <= r2.Top)
                return 1;
            else if
                (r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Bottom <= r2.Bottom && r1.Top >= r2.Top)
                return 0;
            else
                return -1;              
        }
    }
}
