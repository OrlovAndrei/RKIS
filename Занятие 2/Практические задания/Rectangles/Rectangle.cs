namespace Rectangles;

public class Rectangle
{
    public readonly int Left, Top, Width, Height;

    public Rectangle(int left, int top, int width, int height)
    {
        Left = left;
        Top = top;
        Width = width;
        Height = height;
    }

    public int Bottom => Top + Height;
    public int Right => Left + Width;

    public override string ToString()
    {
        return $"Left: {Left}, Top: {Top}, Width: {Width}, Height: {Height}";
    }
}