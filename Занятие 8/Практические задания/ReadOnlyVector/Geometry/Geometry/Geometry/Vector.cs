using ReadOnlyVector;

namespace Geometry
{
    public class Vector
    {
        private readonly ReadOnlyVector.ReadOnlyVector _readOnlyVector;

        public double X => _readOnlyVector.X;
        public double Y => _readOnlyVector.Y;

        public Vector(double x, double y)
        {
            _readOnlyVector = new ReadOnlyVector.ReadOnlyVector(x, y);
        }

        public double GetLength()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public Vector Add(Vector vector)
        {
            var sum = _readOnlyVector.Add(new ReadOnlyVector.ReadOnlyVector(vector.X, vector.Y));
            return new Vector(sum.X, sum.Y);
        }

        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    }
}



// добавить методы Vector.GetLength(),
// Vector.Add(Vector), Vector.Belongs(Segment)
// не вместо, а вместе с соответствующими методами класса Geometry.

