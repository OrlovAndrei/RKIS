namespace Geometry
{
    public static class Geometry
    {
        public static double GetLength(Segment segment)
        {
            return GetLength(new Vector(segment.End.X - segment.Begin.X, segment.End.Y - segment.Begin.Y));
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            double crossProduct = (segment.End.Y - segment.Begin.Y) * (vector.X - segment.Begin.X) - 
                                (segment.End.X - segment.Begin.X) * (vector.Y - segment.Begin.Y);
            return Math.Abs(crossProduct) < 1e-6 &&
                   Math.Min(segment.Begin.X, segment.End.X) <= vector.X && vector.X <= Math.Max(segment.Begin.X, segment.End.X) &&
                   Math.Min(segment.Begin.Y, segment.End.Y) <= vector.Y && vector.Y <= Math.Max(segment.Begin.Y, segment.End.Y);
        }
    }
}
