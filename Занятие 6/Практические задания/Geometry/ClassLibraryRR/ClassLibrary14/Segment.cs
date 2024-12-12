using System;

namespace Geometry;
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

        // Метод для получения длины текущего отрезка
        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        // Метод для проверки, содержит ли отрезок заданный вектор
        public bool Contains(Vector point)
        {
            return Geometry.IsVectorInSegment(point, this);
        }
    }
}