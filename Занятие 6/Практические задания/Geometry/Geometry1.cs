namespace Geometry
{
    public class Vector
    {
        public double X;
        public double Y;

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public static class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }
    }
}

// Segment.cs
namespace Geometry
{
    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public Segment(Vector begin, Vector end)
        {
            Begin = begin;
            End = end;
        }
    }
}
