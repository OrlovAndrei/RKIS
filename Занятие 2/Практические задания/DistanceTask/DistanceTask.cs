using System;
 
namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double ak = Math.Sqrt(((x - ax)*(x - ax))+((y-ay)*(y-ay)));
            double kb = Math.Sqrt(((x - bx)*(x - bx))+((y-by)*(y-by)));
            double ab = Math.Sqrt(((ax - bx)*(ax - bx))+((ay-by)*(ay-by)));
            
            if(x >= ax && x <= bx && ab != 0 )
            {
                
                double p = (ak + kb + ab)/2;
                double s = Math.Sqrt((p*(p - ak)*(p - kb)*(p - ab)));
                
                return (2 * s)/ab;
            }
            
            else if((x <= ax || x >= bx) && ab != 0)
            {
                return Math.Min(ak,kb);
            }else return 0;
        }
    }
}
