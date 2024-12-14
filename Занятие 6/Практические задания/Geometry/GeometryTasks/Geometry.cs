namespace GeometryTasks
{
    public static class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }

        public static double GetLength(Segment segment)
        {
            double deltaX = segment.End.X - segment.Begin.X;
            double deltaY = segment.End.Y - segment.Begin.Y;
            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }

        public static Vector Add(Vector firstVector, Vector secondVector)
        {
            Vector resultVector = new Vector();
            resultVector.X = firstVector.X + secondVector.X;
            resultVector.Y = firstVector.Y + secondVector.Y;
            return resultVector;
        }

        public static bool IsVectorInSegment(Vector point, Segment segment)
        {
            double segmentLength = Geometry.GetLength(segment);
            double lengthToBegin = Math.Sqrt(Math.Pow(point.X - segment.Begin.X, 2) + Math.Pow(point.Y - segment.Begin.Y, 2));
            double lengthToEnd = Math.Sqrt(Math.Pow(point.X - segment.End.X, 2) + Math.Pow(point.Y - segment.End.Y, 2));
            return Equal((lengthToEnd + lengthToBegin), segmentLength);
        }

        public static bool Equal(double firstValue, double secondValue)
        {
            const double epsilon = 0.1;
            return Math.Abs(firstValue - secondValue) < epsilon;
        }
    }
}
