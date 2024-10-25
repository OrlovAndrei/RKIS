namespace Rectangles;

public class Rectangle
{
    public readonly int Left, Top, Width, Height;

    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        if (r1.Left >= r2.Left &&
            r1.Right <= r2.Right &&
            r1.Top >= r2.Top &&
            r1.Bottom <= r2.Bottom)
        {
            return 0;
        }
 
        else if
            (r1.Left <= r2.Left &&
            r1.Right >= r2.Right &&
            r1.Top <= r2.Top &&
            r1.Bottom >= r2.Bottom)
        {
            return 1;
        }
 
        return -1;
    }
