namespace GeometryTasks
{
    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public static double GetLength(Vector vector)
        {
            return Geometry.GetLength(vector);
        }
        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }
}