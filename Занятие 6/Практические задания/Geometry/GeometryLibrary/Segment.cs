using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibrary
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