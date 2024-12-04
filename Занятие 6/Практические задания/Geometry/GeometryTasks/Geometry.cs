namespace GeometryTasks 
{ 
    public static class Geometry 
    { public static double GetLength(Vector inputVector) 
        { 
            return Math.Sqrt(Math.Pow(inputVector.X, 2) + Math.Pow(inputVector.Y, 2)); 
        } 
        public static double GetLength(Segment inputSegment) 
        { 
            double changeX = inputSegment.End.X - inputSegment.Begin.X; 
            double changeY = inputSegment.End.Y - inputSegment.Begin.Y; 
            return Math.Sqrt(Math.Pow(changeX, 2) + Math.Pow(changeY, 2)); 
        } 
        public static Vector Add(Vector firstInputVector, Vector secondInputVector) 
        { 
            Vector outputVector = new Vector(); 
            outputVector.X = firstInputVector.X + secondInputVector.X; 
            outputVector.Y = firstInputVector.Y + secondInputVector.Y; 
            return outputVector; 
        } 
        public static bool IsVectorInSegment(Vector inputPoint, Segment inputSegment) 
        { 
            double segmentTotalLength = Geometry.GetLength(inputSegment); 
            double distanceToBegin = Math.Sqrt(Math.Pow(inputPoint.X - inputSegment.Begin.X, 2) + Math.Pow(inputPoint.Y - inputSegment.Begin.Y, 2)); 
            double distanceToEnd = Math.Sqrt(Math.Pow(inputPoint.X - inputSegment.End.X, 2) + Math.Pow(inputPoint.Y - inputSegment.End.Y, 2)); 
            return Equal((distanceToEnd + distanceToBegin), segmentTotalLength); 
        } 
        public static bool Equal(double firstComparisonValue, double secondComparisonValue) 
        { 
            const double tolerance = 0.1; return Math.Abs(firstComparisonValue - secondComparisonValue) < tolerance; 
        } 
    } 
}