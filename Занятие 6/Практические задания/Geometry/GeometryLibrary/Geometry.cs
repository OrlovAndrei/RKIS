using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibrary
{
    public static class Geometry
    {
        public static double GetLength(Vector v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

        public static Vector Add(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static double GetLength(Segment s)
        {
            return s.Begin.DistanceTo(s.End);
        }

        public static bool IsVectorInSegment(Vector point, Segment segment)
        {

            double segmentLength = GetLength(segment);
            double distToBegin = segment.Begin.DistanceTo(point);
            double distToEnd = segment.End.DistanceTo(point);


            return Math.Abs((distToBegin + distToEnd) - segmentLength) < 1e-6;
        }
    }
}