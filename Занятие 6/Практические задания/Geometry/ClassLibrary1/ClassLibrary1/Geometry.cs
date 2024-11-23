using System;

namespace Geometry
{
    public static class Geometry
    {
        public static double GetLength(Vector vector)
        {
            if (vector == null) throw new ArgumentNullException(nameof(vector));
            return Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            if (vector1 == null) throw new ArgumentNullException(nameof(vector1));
            if (vector2 == null) throw new ArgumentNullException(nameof(vector2));
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }
    }
}