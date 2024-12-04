using System;

namespace Geometry
{
    public static class Geometry
    {
        public static double GetLength(Vector vector)
        {
            if (vector == null)
                throw new ArgumentNullException(nameof(vector));

            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector v1, Vector v2)
        {
            if (v1 == null)
                throw new ArgumentNullException(nameof(v1));
            if (v2 == null)
                throw new ArgumentNullException(nameof(v2));

            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static double GetLength(Segment segment)
        {
            if (segment == null)
                throw new ArgumentNullException(nameof(segment));

            return GetLength(new Vector(segment.End.X - segment.Begin.X, segment.End.Y - segment.Begin.Y));
        }

        public static bool IsVectorInSegment(Vector point, Segment segment)
        {
            if (point == null)
                throw new ArgumentNullException(nameof(point));
            if (segment == null)
                throw new ArgumentNullException(nameof(segment));

            double crossProduct = (point.Y - segment.Begin.Y) * (segment.End.X - segment.Begin.X) -
                                  (point.X - segment.Begin.X) * (segment.End.Y - segment.Begin.Y);

            if (Math.Abs(crossProduct) > double.Epsilon)
                return false; 

            double dotProduct = (point.X - segment.Begin.X) * (segment.End.X - segment.Begin.X) +
                                (point.Y - segment.Begin.Y) * (segment.End.Y - segment.Begin.Y);
            if (dotProduct < 0)
                return false; 

            double squaredLengthSegment = GetLength(segment) * GetLength(segment);
            return dotProduct <= squaredLengthSegment; 
        }
    }
}
