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

    {
     // Метод для проверки, есть ли общие точки
        public bool HasIntersection(Rectangle other)
        {
            return !(other.Left > Right || 
                     other.Right < Left || 
                     other.Top > Bottom || 
                     other.Bottom < Top);
        }

        // Метод для вычисления площади пересечения
        public int GetIntersectionArea(Rectangle other)
        {
            if (!HasIntersection(other)) return 0;

            int intersectLeft = Math.Max(Left, other.Left);
            int intersectRight = Math.Min(Right, other.Right);
            int intersectTop = Math.Max(Top, other.Top);
            int intersectBottom = Math.Min(Bottom, other.Bottom);

            int intersectWidth = intersectRight - intersectLeft;
            int intersectHeight = intersectBottom - intersectTop;

            return intersectWidth * intersectHeight;
        }

        // Метод для проверки, вложен ли один прямоугольник в другой
        public bool IsContainedIn(Rectangle other)
        {
            return Left >= other.Left && 
                   Right <= other.Right && 
                   Top >= other.Top && 
                   Bottom <= other.Bottom;
        }
    }
}   