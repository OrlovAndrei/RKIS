using System;

namespace Geometry
{
    public class Vector
    {
        public double X;
        public double Y;
    }

    public class Geometry
    {
        public static double GetLength(Vector vec)
        {
            return Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
        }

        public static Vector Add(Vector vec1, Vector vec2)
        {
            return new Vector { X = vec1.X + vec2.X, Y = vec1.Y + vec2.Y };
        }
    }
}