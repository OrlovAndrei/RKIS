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
            double deltaX = segment.End.X - segment.Begin.X;
            double deltaY = segment.End.Y - segment.Begin.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public static bool IsVectorInSegment(Vector point, Segment segment)
        {
            double segmentLength = GetLength(segment);
            double distanceToBegin = GetLength(new Segment(segment.Begin, point));
            double distanceToEnd = GetLength(new Segment(segment.End, point));

            return Math.Abs(segmentLength - (distanceToBegin + distanceToEnd)) < 1e-6;
        }
    }
}