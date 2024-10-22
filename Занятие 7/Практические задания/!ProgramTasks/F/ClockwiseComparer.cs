namespace F
{
    internal class ClockwiseComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            double angleX = GetAngle(x);
            double angleY = GetAngle(y);

            return angleX.CompareTo(angleY);
        }

        public double GetAngle(Point point)
        {
            double angle = Math.Atan2(point.X, point.Y);
            if (angle < 0) angle += 2 * Math.PI;

            return angle;
        }
    }
}
