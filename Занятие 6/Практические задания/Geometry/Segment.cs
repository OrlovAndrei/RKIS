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
            return Geometry.GetLength(this);
        }
        public bool Contains(Vector point)
        {
            return Geometry.IsVectorInSegment(point, this);
        }
    }
}