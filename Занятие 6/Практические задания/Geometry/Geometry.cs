using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Geometry
{
    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return (Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y)));
        }
        public static Vector Add(Vector vector1, Vector vector2)
        {
            return (new Vector { X = vector1.X + vector2.X, Y = vector1.Y + vector2.Y });
        }
        public static double GetLength(Segment segment)
        {
            Vector difference = new Vector(segment.End.X - segment.Begin.X, segment.End.Y - segment.Begin.Y);
            return GetLength(difference);
        }


        public static bool IsVectorInSegment(Vector point, Segment segment)
        {
            double segmentLength = GetLength(segment);
            double lengthToPointBegin = GetLength(new Vector(point.X - segment.Begin.X, point.Y - segment.Begin.Y));
            double lengthToPointEnd = GetLength(new Vector(point.X - segment.End.X, point.Y - segment.End.Y));


            return Math.Abs((lengthToPointBegin + lengthToPointEnd) - segmentLength) < 1e-9;
        }
    }
}