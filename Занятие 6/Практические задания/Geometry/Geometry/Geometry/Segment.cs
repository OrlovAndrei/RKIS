using System;

namespace Geometry
{
    internal class Segment
    {
        public Vector Begin {get; set;}
        public Vector End {get; set;}
        public Segment(Vector begin, Vector end)
        {
            Begin = begin;
            End = end;
        }

        public static double GetLength(Vector vector) // ✔
        {
            return Geometry.GetLength(vector);
        }

        public bool Contains(Vector vector) // ✔
        {
            return Geometry.IsVectorInSegment(vector, this);
        }

    }
}

// добавить методы 
// Segment.GetLength() ✔
// и Segment.Contains(Vector) ✔ не вместо, а вместе с соответствующими методами класса Geometry.




