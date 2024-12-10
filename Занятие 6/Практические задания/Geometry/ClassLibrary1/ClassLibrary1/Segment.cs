using System;

namespace Geometry
{
    public class Segment
    {
        public Vector Begin { get; set; }
        public Vector End { get; set; }

        public Segment(Vector begin, Vector end)
        {
            Begin = begin;
            End = end;
        }
        public double GetLength()
        {
            return Vector.Distance(Begin, End);
        }

        public static bool IsVectorInSegment(Vector point, Segment segment)
        {
            double segmentLength = segment.GetLength();

            double length1 = Vector.Distance(segment.Begin, point);
            double length2 = Vector.Distance(point, segment.End);

            return Math.Abs(segmentLength - (length1 + length2)) < 1e-10;
        }
    }
}