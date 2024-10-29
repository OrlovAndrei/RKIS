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
    }
}