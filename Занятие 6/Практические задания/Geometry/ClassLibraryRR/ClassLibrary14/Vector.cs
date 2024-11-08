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

        // Метод для получения длины текущего вектора
        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        // Метод для сложения текущего вектора с другим вектором
        public Vector Add(Vector other)
        {
            return Geometry.Add(this, other);
        }

        // Метод для проверки принадлежности точки (вектора) отрезку
        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    }
}