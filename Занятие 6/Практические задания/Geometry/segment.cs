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
            return Begin.DistanceTo(End);
        }

        public bool IsVectorInSegment(Vector point)
        {
            Vector segmentVec = Vector.Subtract(End, Begin);
            Vector toPointVec = Vector.Subtract(point, Begin);
            Vector toEndVec = Vector.Subtract(End, point);

            double crossProduct = Vector.CrossProduct(segmentVec, toPointVec);

        if (Math.Abs(crossProduct) > 1e-6)
        {
            return false;
        }

            double segmentLength = GetLength();
            double lengthToPoint = Begin.DistanceTo(point) + point.DistanceTo(End);

            return Math.Abs(segmentLength - lengthToPoint) < 1e-6;
        }
    }
}