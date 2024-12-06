namespace Geometry
{
    public class Vector
    {
        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector other)
        {
            return Geometry.Add(this, other);
        }

        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    }

    public class Segment
    {
        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }
}
