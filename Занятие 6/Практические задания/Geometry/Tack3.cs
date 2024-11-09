using System;

namespace Geometry
{
    public class Vector
    {
        public double X;
        public double Y;

        public double GetLength() => Geometry.GetLength(this);

        public Vector Add(Vector other) => Geometry.Add(this, other);

        public bool Belongs(Segment segment) => Geometry.IsVectorInSegment(this, segment);
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public double GetLength() => Geometry.GetLength(this);

        public bool Contains(Vector vector) => Geometry.IsVectorInSegment(vector, this);
    }

    public class Geometry
    {
        public static double GetLength(Vector v) =>
            Math.Sqrt(v.X * v.X + v.Y * v.Y);

        public static Vector Add(Vector v1, Vector v2) =>
            new Vector { X = v1.X + v2.X, Y = v1.Y + v2.Y };

        public static double GetLength(Segment s)
        {
            double lengthX = s.End.X - s.Begin.X;
            double lengthY = s.End.Y - s.Begin.Y;
            return Math.Sqrt(lengthX * lengthX + lengthY * lengthY);
        }

        public static bool IsVectorInSegment(Vector v, Segment s)
        {
            if (s.Begin.X == s.End.X && s.Begin.Y == s.End.Y)
                return v.X == s.Begin.X && v.Y == s.Begin.Y;

            double crossProduct = (v.Y - s.Begin.Y) * (s.End.X - s.Begin.X) -
                                  (v.X - s.Begin.X) * (s.End.Y - s.Begin.Y);
            if (Math.Abs(crossProduct) > 1e-10) return false;

            double dotProduct = (v.X - s.Begin.X) * (s.End.X - s.Begin.X) +
                                (v.Y - s.Begin.Y) * (s.End.Y - s.Begin.Y);
            if (dotProduct < 0) return false;

            double segmentLengthSquared = GetLength(s) * GetLength(s);
            return dotProduct <= segmentLengthSquared;
        }
    }
}
