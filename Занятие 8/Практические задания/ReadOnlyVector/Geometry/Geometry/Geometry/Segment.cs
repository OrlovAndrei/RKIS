using System;

namespace Geometry
{
    public class Segment
    {
        public Vector Begin { get; }
        public Vector End { get; }

        public Segment(Vector begin, Vector end)
        {
            Begin = begin;
            End = end;
        }

        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }
}


// добавить методы 
// Segment.GetLength() ✔
// и Segment.Contains(Vector) ✔ не вместо, а вместе с соответствующими методами класса Geometry.




