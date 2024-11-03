using System;

namespace Geometry
{
    internal class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }
        public static Vector Add(Vector vector, Vector vector2)
        {
            Vector vector3 = new Vector
            {
                X = vector.X + vector2.X,
                Y = vector.Y + vector2.Y
            };
            return vector3;
        }
    }
}