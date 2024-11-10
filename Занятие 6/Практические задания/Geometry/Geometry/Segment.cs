using System;

namespace Geometry
{
    public class Segment
    {
        public Vector Begin { get; set; }
        public Vector End { get; set; }

        public static double GetLength(Vector vector)
        {
            return Geometry.GetLength(vector);
        }

        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }

    }
}