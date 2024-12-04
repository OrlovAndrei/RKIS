using System;

namespace Geometry
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            return Geometry.Add(this, other);
        }

        public bool Belongs(Segment segment)
        {
            if (segment == null)
                throw new ArgumentNullException(nameof(segment));
            return Geometry.IsVectorInSegment(this, segment);
        }
    }
}
