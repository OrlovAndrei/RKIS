using Geometry;

namespace Geometry
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }


        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector vector)
        {
            return Geometry.Add(vector, this);
        }

        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    }
}