namespace Geometry
{
    public static class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        public static double GetLength(Segment segment)
        {
            double dx = segment.End.X - segment.Begin.X;
            double dy = segment.End.Y - segment.Begin.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static bool IsVectorInSegment(Vector point, Segment segment)
        {
            double crossProduct = (point.Y - segment.Begin.Y) * (segment.End.X - segment.Begin.X) - 
                                  (point.X - segment.Begin.X) * (segment.End.Y - segment.Begin.Y);

            if (Math.Abs(crossProduct) > double.Epsilon)
                return false;

            double dotProduct = (point.X - segment.Begin.X) * (segment.End.X - segment.Begin.X) + 
                                (point.Y - segment.Begin.Y) * (segment.End.Y - segment.Begin.Y);
            if (dotProduct < 0)
                return false;

            double squaredSegmentLength = Math.Pow(segment.End.X - segment.Begin.X, 2) + 
                                          Math.Pow(segment.End.Y - segment.Begin.Y, 2);
            if (dotProduct > squaredSegmentLength)
                return false;

            return true;
        }
    }
}