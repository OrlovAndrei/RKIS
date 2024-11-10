using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibrary
{
    public class Vector
    {
        public double X;
        public double Y;


        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double GetLength()
        {
            return Geometry.GetLength(this);   
        }


        public Vector Add(Vector other)
        {
            return Geometry.Add(this, other);   
        }


        public double DistanceTo(Vector other)
        {
            return Math.Sqrt(Math.Pow(this.X - other.X, 2) + Math.Pow(this.Y - other.Y, 2));
        }
    }
}
