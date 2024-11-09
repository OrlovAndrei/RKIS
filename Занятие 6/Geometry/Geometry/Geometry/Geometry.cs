using System;

namespace Geometry
{
    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector
            {
                X = vector1.X + vector2.X,
                Y = vector1.Y + vector2.Y
            };
        }

        public static double GetLength(Segment segment)
        {
            return Math.Sqrt(Math.Pow(segment.End.X - segment.Begin.X, 2) + Math.Pow(segment.End.Y - segment.Begin.Y, 2));
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            var segmentLength = Geometry.GetLength(segment);
            var length1 = Math.Sqrt(Math.Pow(vector.X - segment.Begin.X, 2) + Math.Pow(vector.Y - segment.Begin.Y, 2));
            var length2 = Math.Sqrt(Math.Pow(vector.X - segment.End.X, 2) + Math.Pow(vector.Y - segment.End.Y, 2));

            return AlmostEqual((length2 + length1), segmentLength);
        }

        public static bool AlmostEqual(double a, double b)
        {
            const double e = 0.1;
            return Math.Abs(a - b) < e;
        }

    }
}
