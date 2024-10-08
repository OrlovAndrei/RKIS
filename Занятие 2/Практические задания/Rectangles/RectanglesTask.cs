using System;
 
namespace Rectangles
{
    public static class RectanglesTask
    {
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            return !(tooLeft || tooRight || tooHigh || tooLow);
        }
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (AreIntersected(r1, r2) == true)
            {
                return xPere * yPere;
            }
            else return 0;
            int SearchIntersection(int aLeft, int aRight, int bLeft, int bRight)
            {
                int left = Math.Max(aLeft, bLeft);
                int right = Math.Min(aRight, bRight);
 
                return Math.Max(right - left, 0);
            }
        }
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if ((IntersectionSquare(r1, r2)) > 0)
            {
                if ((IntersectionSquare(r1, r2)) == (r1.Left * r1.Top) && (r1.Left * r1.Top >= r1.Width * r1.Height))
                {
                    if ((r1.Left == 1) || (r1.Top == 1)) return -1;
                    else return 0;
                }
                if ((IntersectionSquare(r1, r2)) == (r2.Left * r2.Top) && (r2.Left * r2.Top >= r2.Width * r2.Height))
                {
                    if ((r2.Left == 1) || (r2.Top == 1)) return 1;
                    else return 1;
                }
                if ((IntersectionSquare(r1, r2)) == (r1.Width * r1.Height) && (r1.Width * r1.Height >= r1.Left * r1.Top))
                {
                    if ((r1.Width == 1) || (r1.Height == 1)) return -1;
                    else return 0;
                }
                if ((IntersectionSquare(r1, r2)) == (r2.Width * r2.Height) && (r2.Width * r2.Height >= r2.Left * r2.Top))
                {
                    if ((r2.Width == 1) || (r2.Height == 1)) return -1;
                    else return 1;
                }
                else return -1;
            }
            if (r2.Height == 0 && r2.Width == 0) return 1;
            if (r1.Height == 0 && r1.Width == 0) return 0;
            if ((IntersectionSquare(r1, r2)) == (r2.Width * r2.Height) ^ (r2.Width * r2.Height >= r2.Left * r2.Top)) return -1;
            
            else return -1;
        }
    }
}
